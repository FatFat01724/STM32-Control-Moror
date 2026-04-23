using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;

namespace frmBKRAw1
{
    public partial class bttime : Form
    {
        private byte[] buffer = new byte[256]; // Chứa data của frame truyền
        private byte[] data = new byte[32]; // Chứa data của frame truyền
        private bool isReceiving = false; //Biến để kiểm tra xem là có đang nhận data hay không, nếu = 0 đã nhận xong hoặc chưa nhận
        private bool SRAM_flag = false; //Biến để kiểm tra xem là có đang nhận data hay không, nếu = 0 đã nhận xong hoặc chưa nhận
        private byte bSTX = 0x02,bETX = 0x03;
        private int calibrated_span;
        private int currentPulseValue;
        private List<byte> receiveBuffer = new List<byte>(); // Sử dụng List<byte> thay vì mảng cố định
        private readonly object bufferLock = new object(); // Khóa để đồng bộ hóa truy cập buffer
        private double pwmValue2;
        private double DAC_data;
        private List<byte> allPagesData = new List<byte>();
        private List<List<int>> allDecodedValues = new List<List<int>>();


        public bttime()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnZeroCalib.Enabled = false;
            btnSpanCalib.Enabled = false;
            //Đọc các port khả dụng trên PC
            cbPortName.DataSource = System.IO.Ports.SerialPort.GetPortNames();

            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cbBaudRate.Items.AddRange(BaudRate);
            // Cài đặt cho DataBits
            string[] Databits = { "6", "7", "8" };
            cbDataBits.Items.AddRange(Databits);
            //Cho Parity
            string[] Parity = { "None", "Odd", "Even" };
            cbParity.Items.AddRange(Parity);
            //Cho Stop bit
            string[] stopbit = { "1", "1.5", "2" };
            cbStopBits.Items.AddRange(stopbit);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen is false)
                {
                    serialPort.Open();
                }
                else
                {
                    //Hiện thông báo là port đã mở rồi
                    MessageBox.Show("USART ĐÃ ĐƯỢC KẾT NỐI");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtConnectUSBCDC_Click(object sender, EventArgs e)
        {
            string vid = txtVendorID.Text.Trim();
            string pid = txtProductID.Text.Trim();

            if (string.IsNullOrEmpty(vid) || string.IsNullOrEmpty(pid))
            {
                MessageBox.Show("Vui lòng nhập VendorID và ProductID!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string comPort = GetCOMPort(vid, pid);
            if (comPort != null)
            {
                txtVendor.Text = comPort; // Hiển thị cổng COM lên TextBox Vendor
                MessageBox.Show($"Thiết bị được tìm thấy trên cổng {comPort}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thiết bị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (serialPort.IsOpen is false)
                {
                    serialPort.Open();
                }
                else
                {
                    //Hiện thông báo là port đã mở rồi
                    MessageBox.Show("USART ĐÃ ĐƯỢC KẾT NỐI");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetCOMPort(string vid, string pid)
        {
            string deviceID = $"VID_{vid}&PID_{pid}";
            string comPort = null;

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity"))
            {
                foreach (ManagementObject device in searcher.Get())
                {
                    string deviceName = device["Name"]?.ToString();
                    string deviceIDString = device["PNPDeviceID"]?.ToString();

                    if (!string.IsNullOrEmpty(deviceIDString) && deviceIDString.Contains(deviceID) && deviceName.Contains("COM"))
                    {
                        int startIndex = deviceName.IndexOf("(COM") + 1;
                        int endIndex = deviceName.IndexOf(")", startIndex);
                        if (startIndex > 0 && endIndex > startIndex)
                        {
                            comPort = deviceName.Substring(startIndex, endIndex - startIndex);
                            break;
                        }
                    }
                }
            }
            return comPort; // Trả về giá trị tìm được (nếu có)
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen is true)
                {
                    serialPort.Close();
                }
                else
                {
                    //Hiện thông báo là port đã mở rồi
                    MessageBox.Show("USART ĐÃ NGẮT KẾT NỐI");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<int> DecodePageDataOptimized(byte[] pageData)
        {
            List<int> decodedValues = new List<int>();
            int length = pageData.Length - (pageData.Length % 4);

            for (int i = 0; i < length; i += 4)
            {
                // Chuyển ASCII digit sang giá trị số (0-9)
                int digit1 = pageData[i] - 0x30;
                int digit2 = pageData[i + 1] - 0x30;
                int digit3 = pageData[i + 2] - 0x30;
                int digit4 = pageData[i + 3] - 0x30;

                // Kiểm tra hợp lệ (0-9)
                if (digit1 >= 0 && digit1 <= 9 &&
                    digit2 >= 0 && digit2 <= 9 &&
                    digit3 >= 0 && digit3 <= 9 &&
                    digit4 >= 0 && digit4 <= 9)
                {
                    int value = digit1 * 1000 + digit2 * 100 + digit3 * 10 + digit4;
                    decodedValues.Add(value);
                }
                else
                {
                    decodedValues.Add(0); // Giá trị mặc định khi lỗi
                }
            }

            return decodedValues;
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] tempBuffer = new byte[bytesToRead];
                serialPort.Read(tempBuffer, 0, bytesToRead);

                lock (bufferLock)
                {
                    foreach (byte receivedByte in tempBuffer)
                    {
                        if (receivedByte == bSTX)
                        {
                            // Bắt đầu khung dữ liệu mới
                            isReceiving = true;
                            receiveBuffer.Clear();
                        }
                        else if (receivedByte == bETX && isReceiving)
                        {
                            isReceiving = false;

                            if (receiveBuffer.Count >= 61) // 1 byte dataType + 60 byte data
                            {
                                byte dataType = receiveBuffer[0]; // Byte ngay sau STX

                                // Cắt phần dữ liệu chính (60 byte) sau dataType
                                if (dataType == (byte)'A' || dataType == (byte)'C')
                                {
                                    byte[] payload = receiveBuffer.Skip(1).Take(20).ToArray();
                                    this.Invoke((MethodInvoker)delegate {
                                        DisplayData(payload);
                                    });
                                }
                                else if (dataType == (byte)'P')
                                {
                                    byte[] payload = receiveBuffer.Skip(1).Take(60).ToArray();
                                    allPagesData.AddRange(payload);

                                    if (allPagesData.Count >= 10 * 60)
                                    {
                                        this.Invoke((MethodInvoker)delegate {
                                            ProcessCompleteData(allPagesData);
                                        });
                                        allPagesData.Clear();
                                    }
                                }
                            }
                            else if(receiveBuffer.Count < 10)
                            {
                                byte dataType = receiveBuffer[0]; // Byte ngay sau STX

                                if (dataType == (byte)'D')
                                {
                                    byte[] payload = receiveBuffer.Skip(1).Take(4).ToArray();
                                    this.Invoke((MethodInvoker)delegate {
                                        DisplayData2(payload);
                                    });
                                }
                                else if (dataType == (byte)'E')
                                {
                                    // Dữ liệu hiệu chuẩn
                                    byte[] payload = receiveBuffer.Skip(1).Take(4).ToArray();
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        string asciiString = Encoding.ASCII.GetString(payload);

                                        if (int.TryParse(asciiString, out int spanValue))
                                        {
                                            calibrated_span = spanValue;
                                            currentPulseValue = spanValue;

                                            Debug.WriteLine($"[Calibrated] calibrated_span = {calibrated_span}");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Dữ liệu hiệu chuẩn không hợp lệ.");
                                        }
                                    });
                                }
                                else if (dataType == (byte)'T')
                                {
                                    byte[] payload = receiveBuffer.Skip(1).Take(4).ToArray();
                                                string asciiString = Encoding.ASCII.GetString(payload);

                                    this.Invoke((MethodInvoker)delegate {
                                        DisplayData6(payload);
                                    });
                                }    
                            }

                            receiveBuffer.Clear(); // Clear sau xử lý
                        }
                        else if (isReceiving)
                        {
                            if (receiveBuffer.Count < 61) // 1 byte dataType + 60 byte dữ liệu
                            {
                                receiveBuffer.Add(receivedByte);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
        private void ProcessCompleteData(List<byte> data)
        {
            // Chia thành 10 page riêng biệt
            var pages = new List<byte[]>();
            allDecodedValues.Clear();

            for (int i = 0; i < 10; i++)
            {
                byte[] page = data.Skip(i * 60).Take(60).ToArray();
                pages.Add(page);

                List<int> decodedValues = DecodePageDataOptimized(page);
                allDecodedValues.Add(decodedValues);

                // Hiển thị từng page
                Debug.Write($"Page {i + 1}: ");
                Debug.WriteLine($"{string.Join(", ", decodedValues)}");
            }
            int max_data = FindMaxValueFromAllPages();
            //Debug.WriteLine($"Giá trị lớn nhất trong tất cả các page: {max_data}");
            var mostFrequentValue = FindMostFrequentValue();
            var establish_data = mostFrequentValue.Value;
            //Debug.WriteLine($"Giá trị xuất hiện nhiều nhất: {mostFrequentValue.Value} ({mostFrequentValue.Count} lần)");
            double POT = ((max_data - establish_data)*100.0) / establish_data;
            DisplayData4(POT);

            // Tính cận trên - cận dưới theo 2%
            double tolerance = mostFrequentValue.Value * 0.02;
            double lowerBound = mostFrequentValue.Value - tolerance;
            double upperBound = mostFrequentValue.Value + tolerance;

            //Debug.WriteLine($"Cận dưới = {lowerBound:F2}, Cận trên = {upperBound:F2}");

            // Tìm thời gian quá độ
            int settlingIndex = FindSettlingTime(lowerBound, upperBound);

            if (settlingIndex != -1)
            {
                double sampleTimeMs = 20.0; // giả sử mỗi mẫu đo cách nhau 20ms
                double settlingTime = (settlingIndex + 1) * sampleTimeMs;
                DisplayData5(settlingTime);
                //Debug.WriteLine($"Thời gian quá độ (2%) = {settlingTime} ms");
            }
            else
            {
                //Debug.WriteLine("Không tìm thấy thời gian quá độ!");
            }
        }

        // Hàm tìm giá trị lớn nhất
        private int FindMaxValueFromAllPages()
        {
            int maxValue = int.MinValue; // Bắt đầu bằng giá trị nhỏ nhất

            foreach (var page in allDecodedValues) // Duyệt qua 10 page
            {
                if (page.Count > 0)
                {
                    int pageMax = page.Max(); // Max của từng page
                    if (pageMax > maxValue)
                    {
                        maxValue = pageMax; // Cập nhật nếu lớn hơn max hiện tại
                    }
                }
            }

            return maxValue; // Trả về giá trị lớn nhất toàn bộ 10 page
        }

        private (int Value, int Count) FindMostFrequentValue()
        {
            var allValues = allDecodedValues.SelectMany(page => page); // Gom tất cả giá trị thành 1 danh sách

            var groups = allValues
                .GroupBy(x => x) // Nhóm theo giá trị
                .Select(g => new { Value = g.Key, Count = g.Count() }) // Đếm số lần xuất hiện
                .OrderByDescending(g => g.Count) // Sắp xếp giảm dần theo số lượng
                .First(); // Lấy giá trị xuất hiện nhiều nhất

            return (groups.Value, groups.Count);
        }

        // Hàm tìm thời gian xác lập
        private int FindSettlingTime(double lowerBound, double upperBound)
        {
            var allValues = allDecodedValues.SelectMany(page => page).ToList();

            for (int i = 0; i < allValues.Count; i++)
            {
                bool allInside = true;
                for (int j = i; j < allValues.Count; j++)
                {
                    if (allValues[j] < lowerBound || allValues[j] > upperBound)
                    {
                        allInside = false;
                        break;
                    }
                }

                if (allInside)
                {
                    return i; // Tìm được index bắt đầu ổn định
                }
            }

            return -1; // Không tìm được
        }
        //private void Displaydata1()
        //{
        //    txttempvalue.Invoke((MethodInvoker)delegate
        //    {
        //        txttempvalue.Text = string.Empty;
        //    });
        //    //Dịch từ byte sang string
        //    string message = Encoding.ASCII.GetString(buffer, 0, index - 1);

        //    //Hiển thị data lên textbox
        //    txttempvalue.Invoke((MethodInvoker)delegate { txttempvalue.AppendText(message + Environment.NewLine); });
        //}

        private void DisplayData(byte[] data)
        {
            StringBuilder hexString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hexString.Append(data[i].ToString("X2") + " ");
            }

            txtReceivedMessages.Invoke((MethodInvoker)delegate
            {
                txtReceivedMessages.AppendText(hexString.ToString() + Environment.NewLine);
            });
        }

        private void DisplayData2(byte[] data)
        {
            try
            {
                // Giải mã 4 byte ASCII thành số nguyên
                string asciiString = Encoding.ASCII.GetString(data);

                if (int.TryParse(asciiString, out int result))
                {
                    currentPulseValue = result;
                    DisplayData3(currentPulseValue);
                    txtPulse.Invoke((MethodInvoker)delegate
                    {

                        txtPulse.Text = result.ToString(); // Ghi đè nội dung cũ
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayData3(double data)
        {
            try
            {
                if(calibrated_span != 0)
                {
                    double angle = data * (360.0 / calibrated_span);
                    txtAngle.Invoke((MethodInvoker)delegate
                    {
                        txtAngle.Text = angle.ToString("F2"); // Hiển thị với 2 số thập phân
                    });
                }
                else
                {
                    string angle = "Calibrating";
                    txtAngle.Invoke((MethodInvoker)delegate
                    {
                        txtAngle.Text = angle.ToString(); // Hiển thị với 2 số thập phân
                    });
                }    
                // Tính toán góc dựa trên currentPulseValue và calibratedSpan      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayData4(double data)
        {
            try
            {
                txtPOT.Invoke((MethodInvoker)delegate
                {
                    txtPOT.Text = data.ToString("F4") + " %"; // Hiển thị với 2 số thập phân
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayData5(double data)
        {
            try
            {
                txtTxl.Invoke((MethodInvoker)delegate
                {
                    txtTxl.Text = data.ToString() + " ms"; // Hiển thị với thời gian xác lập
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayData6(byte[] data)
        {

            string digitString = ((char)data[0]).ToString()
                           + ((char)data[1]).ToString()
                           + ((char)data[2]).ToString()
                           + ((char)data[3]).ToString();
            if (int.TryParse(digitString, out int intValue))
            {
                // Thực hiện phép tính
                double result = ((intValue * 3.3) / (4096 * 0.2) - 4) / 0.04;

                // Hiển thị kết quả lên txttempvalue
                txttempvalue.Invoke((MethodInvoker)delegate
                {
                    txttempvalue.Text = "PT100: " + result.ToString("0.00") + " deg C";
                });
            }
        }
        //-------------------------------------------------------
        // --------------DO OUTPUT | MODE 000--------------------
        //-------------------------------------------------------
        private void btnLed1_on_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x30;
                data[4] = 0x7A;             
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLed1_off_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x30;
                data[4] = 0x7B;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLed2_on_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x30;
                data[5] = 0x7A;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLed2_off_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x30;
                data[5] = 0x7B;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLed3_on_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x30;
                data[6] = 0x7A;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLed3_off_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x30;
                data[6] = 0x7B;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_updatetime(object sender, EventArgs e)
        {
            try

            {
                DateTime currentTime = DateTime.Now;
                byte[] timeData = new byte[3];

                timeData[0] = (byte)currentTime.Hour;
                timeData[1] = (byte)currentTime.Minute;
                timeData[2] = (byte)currentTime.Second;
                serialPort.Write(new byte[] { 0x31 }, 0, 1);
                serialPort.Write(new byte[] { 0x00 }, 0, 1);
                serialPort.Write(new byte[] { 0x00 }, 0, 1);
                serialPort.Write(timeData, 0, 3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        //-------------------------------------------------------
        //--------------DUTY CIRCLE | MODE 001-------------------
        //-------------------------------------------------------

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x30;
                data[3] = 0x31;
                string S_value = trackBar1.Value.ToString().PadLeft(3, '0');   // Convert số sang "001"
                data[4] = (byte)S_value[0];
                data[5] = (byte)S_value[1];
                data[6] = (byte)S_value[2];

                int pwmValue = int.Parse(S_value);

                data[data.Length - 1] = bETX;
                pwmValue2 = pwmValue * 100 / 999;

                lbSpeed.Text = "Duty Cycle: " + pwmValue2.ToString() + " %";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-------------------------------------------------------
        //---------POSITION CONTROL NONE PID | MODE 010----------
        //-------------------------------------------------------

        private void btn_90_click_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x30;
                data[4] = 0x30;
                data[5] = 0x39;
                data[6] = 0x30;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_180_click_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x30;
                data[4] = 0x31;
                data[5] = 0x38;
                data[6] = 0x30;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_360_click_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x30;
                data[4] = 0x33;
                data[5] = 0x36;
                data[6] = 0x30;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_270_click_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x30;
                data[4] = 0x32;
                data[5] = 0x37;
                data[6] = 0x30;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendNonePID_Click(object sender, EventArgs e)
        {
            try
            {
                //Chuyển những data mình nhập sang mảng byte
                byte[] dataToSend = Encoding.ASCII.GetBytes(txtNonePID.Text);

                //Kiểm tra data cần gửi có hợp lệ hay không
                if (dataToSend != null)
                {
                    // Gửi frame
     
                    data[0] = bSTX;
                    data[1] = 0x30;
                    data[2] = 0x31;
                    data[3] = 0x30;
                    data[4] = dataToSend[0];
                    data[5] = dataToSend[1];
                    data[6] = dataToSend[2];
                    data[data.Length - 1] = bETX;
                    serialPort.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x32;
                data[data.Length - 1] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGraphPos_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có dữ liệu chưa
            if (allDecodedValues == null || allDecodedValues.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để vẽ đồ thị!");
                return;
            }

            // Xóa dữ liệu cũ trước khi vẽ mới
            this.POScontrolGraph.Series["Position"].Points.Clear();

            // Biến thời gian (ms)
            double timeMs = 0;
            const double samplingInterval = 20.0; // 20ms mỗi giá trị

            // Duyệt qua từng page
            foreach (List<int> pageData in allDecodedValues)
            {
                // Duyệt qua từng giá trị trong page
                foreach (int value in pageData)
                {
                    // Thêm điểm dữ liệu vào đồ thị với trục X là thời gian
                    this.POScontrolGraph.Series["Position"].Points.AddXY(timeMs, value);
                    timeMs += samplingInterval;

                    // Dừng khi đạt 3 giây (3000ms)
                    if (timeMs > 3000) break;
                }
                if (timeMs > 3000) break;
            }

            // Tùy chỉnh đồ thị
            CustomizeGraph();
        }

        private void CustomizeGraph()
        {
            // Thiết lập style cho đồ thị
            this.POScontrolGraph.Series["Position"].ChartType = SeriesChartType.Line;
            this.POScontrolGraph.Series["Position"].Color = Color.Red;
            this.POScontrolGraph.Series["Position"].BorderWidth = 2;
            this.POScontrolGraph.Series["Position"].MarkerStyle = MarkerStyle.Circle;
            this.POScontrolGraph.Series["Position"].MarkerSize = 3;

            // Thiết lập trục X (Thời gian)
            this.POScontrolGraph.ChartAreas[0].AxisX.Title = "Time (ms)";
            this.POScontrolGraph.ChartAreas[0].AxisX.Interval = 300; // Mỗi 300ms hiển thị 1 mốc
            this.POScontrolGraph.ChartAreas[0].AxisX.Minimum = 0;
            this.POScontrolGraph.ChartAreas[0].AxisX.Maximum = 3000; // 3 giây
            this.POScontrolGraph.ChartAreas[0].AxisX.MajorGrid.Interval = 300;

            // Thiết lập trục Y (Giá trị vị trí)
            this.POScontrolGraph.ChartAreas[0].AxisY.Title = "Pulse Value";
            this.POScontrolGraph.ChartAreas[0].AxisY.Interval = 200;
            this.POScontrolGraph.ChartAreas[0].AxisY.Minimum = 0;
            this.POScontrolGraph.ChartAreas[0].AxisY.Maximum = 1200;
            this.POScontrolGraph.ChartAreas[0].AxisY.MajorGrid.Interval = 100;

            // Làm mới đồ thị
            this.POScontrolGraph.Invalidate();
        }

        private void CBCalibration_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBCalibration.Checked)
                {
                    btnZeroCalib.Enabled = CBCalibration.Checked;
                    btnSpanCalib.Enabled = CBCalibration.Checked;
     
                    data[0] = bSTX;
                    data[1] = 0x30;
                    data[2] = 0x31;
                    data[3] = 0x34;
                    serialPort.Write(data, 0, data.Length);
                }
                else
                {
                    btnZeroCalib.Enabled = CBCalibration.Checked;
                    btnSpanCalib.Enabled = CBCalibration.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnZeroCalib_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x34;
                data[4] = 0x31;
                data[5] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            try
            {
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x33;
                data[4] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSpanCalib_Click(object sender, EventArgs e)
        {
            try
            {
                Array.Clear(data, 0, data.Length);
 
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x31;
                data[3] = 0x34;
                data[4] = 0x32;
                data[5] = bETX;
                serialPort.Write(data, 0, data.Length);
                calibrated_span = currentPulseValue;
                Debug.WriteLine($"Calibrated Span set to: {calibrated_span}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar_RED_Scroll(object sender, EventArgs e)
        {
            try
            {
                 data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x32;
                data[3] = 0x30;
                data[4] = 0x52;
                string Color_value = trackBar_RED.Value.ToString().PadLeft(3, '0');   // Convert số sang "001"
                data[5] = (byte)Color_value[0];
                data[6] = (byte)Color_value[1];
                data[7] = (byte)Color_value[2];

                int pwmValue = int.Parse(Color_value);

                data[8] = bETX;
                pwmValue2 = pwmValue * 100 / 999;

                lbRED.Text = pwmValue2.ToString() + " %";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar_GREEN_Scroll(object sender, EventArgs e)
        {
            try
            {
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x32;
                data[3] = 0x30;
                data[4] = 0x47;
                string Color_value = trackBar_GREEN.Value.ToString().PadLeft(3, '0');   // Convert số sang "001"
                data[5] = (byte)Color_value[0];
                data[6] = (byte)Color_value[1];
                data[7] = (byte)Color_value[2];

                int pwmValue = int.Parse(Color_value);

                data[8] = bETX;
                pwmValue2 = pwmValue * 100 / 999;

                lbGREEN.Text = pwmValue2.ToString() + " %";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar_BLUE_Scroll(object sender, EventArgs e)
        {
            try
            {
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x32;
                data[3] = 0x30;
                data[4] = 0x42;
                string Color_value = trackBar_BLUE.Value.ToString().PadLeft(3, '0');   // Convert số sang "001"
                data[5] = (byte)Color_value[0];
                data[6] = (byte)Color_value[1];
                data[7] = (byte)Color_value[2];

                int pwmValue = int.Parse(Color_value);

                data[8] = bETX;
                pwmValue2 = pwmValue * 100 / 999;

                lbBLUE.Text = pwmValue2.ToString() + " %";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            string DAC_value = trackBar2.Value.ToString().PadLeft(4, '0');   // Convert số sang "001"
            int DAC = int.Parse(DAC_value);
            DAC_data = DAC * 5 / 4095.0;
            lbDAC.Text = DAC_data.ToString("F4") + " V";
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x32;
                data[3] = 0x32;
                data[4] = 0x31;
                data[5] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x32;
                data[3] = 0x32;
                data[4] = 0x32;
                data[5] = bETX;
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbSRAM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSRAM.Checked)
                {
                    SRAM_flag = true;
                }
                else
                {
                    SRAM_flag = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendDAC_Click(object sender, EventArgs e)
        {
            try
            {
                data[0] = bSTX;
                data[1] = 0x30;
                data[2] = 0x32;
                data[3] = 0x31;
                if (SRAM_flag) { data[4] = 0x31; }
                else { data[4] = 0x30; }
                string DAC_value = trackBar2.Value.ToString().PadLeft(4, '0');   // Convert số sang "001"
                data[5] = (byte)DAC_value[0];
                data[6] = (byte)DAC_value[1];
                data[7] = (byte)DAC_value[2];
                data[8] = (byte)DAC_value[3];

                int DAC = int.Parse(DAC_value);

                data[9] = bETX;
                DAC_data = DAC * 5 / 4095.0;

                lbDAC.Text = DAC_data.ToString("F4") + " V";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSendDAC_V1_Click(object sender, EventArgs e)
        {
            try
            {
                string DAC_value = trackBar2.Value.ToString().PadLeft(4, '0');   // Convert số sang "0001"

                data[0] = bSTX;
                data[1] = 0x05;
                data[2] = 0x01;
                data[3] = 0x31;
                data[4] = (byte)DAC_value[0];
                data[5] = (byte)DAC_value[1];
                data[6] = (byte)DAC_value[2];
                data[7] = (byte)DAC_value[3];

                int DAC = int.Parse(DAC_value);

                data[8] = bETX;
                DAC_data = DAC * 5 / 4095.0;

                lbDAC.Text = DAC_data.ToString("F4") + " V";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendDAC_V2_Click(object sender, EventArgs e)
        {
            try
            {
                string DAC_value = trackBar2.Value.ToString().PadLeft(4, '0');   // Convert số sang "0001"

                data[0] = bSTX;
                data[1] = 0x05;
                data[2] = 0x01;
                data[3] = 0x31;
                data[4] = (byte)DAC_value[0];
                data[5] = (byte)DAC_value[1];
                data[6] = (byte)DAC_value[2];
                data[7] = (byte)DAC_value[3];

                int DAC = int.Parse(DAC_value);

                data[8] = bETX;
                DAC_data = DAC * 5 / 4095.0;

                lbDAC.Text = DAC_data.ToString("F4") + " V";

                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendPos_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị nhập
            if (string.IsNullOrEmpty(txtKpPos.Text) ||
                string.IsNullOrEmpty(txtKiPos.Text) ||
                string.IsNullOrEmpty(txtKdPos.Text))
            {
                MessageBox.Show("Please enter all PID parameters");
                return;
            }

            try
            {
                // Tạo chuỗi dữ liệu
                string dataString = $"{txtKpPos.Text}/{txtKiPos.Text}/{txtKdPos.Text}/";
                byte[] dataToSend = Encoding.ASCII.GetBytes(dataString);

                // Kiểm tra kích thước mảng
                if (dataToSend.Length > (data.Length - 6)) // 4 byte header + 1 ETX
                {
                    MessageBox.Show("Data too long");
                    return;
                }
 
                data[0] = bSTX; 
                data[1] = 0x30; 
                data[2] = 0x31; 
                data[3] = 0x31; 
                Array.Copy(dataToSend, 0, data, 4, dataToSend.Length);
                data[4 + dataToSend.Length] = bETX;
                serialPort.Write(data, 0, 5 + dataToSend.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}