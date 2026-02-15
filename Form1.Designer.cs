namespace frmBKRAw1
{
    partial class bttime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.UART_Config = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.txtReceivedMessages = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbBLUE = new System.Windows.Forms.Label();
            this.lbGREEN = new System.Windows.Forms.Label();
            this.lbRED = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.trackBar_GREEN = new System.Windows.Forms.TrackBar();
            this.trackBar_RED = new System.Windows.Forms.TrackBar();
            this.trackBar_BLUE = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txttempvalue = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnResetCounter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_90_click = new System.Windows.Forms.Button();
            this.btn_180_click = new System.Windows.Forms.Button();
            this.btn_360_click = new System.Windows.Forms.Button();
            this.btn_270_click = new System.Windows.Forms.Button();
            this.txtNonePID = new System.Windows.Forms.TextBox();
            this.txtKdPos = new System.Windows.Forms.TextBox();
            this.btnSendNonePID = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKiPos = new System.Windows.Forms.TextBox();
            this.txtKpPos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSendPos = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.txtPOT = new System.Windows.Forms.TextBox();
            this.txtTxl = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.CBCalibration = new System.Windows.Forms.CheckBox();
            this.btnZeroCalib = new System.Windows.Forms.Button();
            this.btnSpanCalib = new System.Windows.Forms.Button();
            this.POScontrolGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGraphPos = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtConnectUSBCDC = new System.Windows.Forms.Button();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.Timer_Position = new System.Windows.Forms.Timer(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lbDAC = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.cbSRAM = new System.Windows.Forms.CheckBox();
            this.btnSendDAC = new System.Windows.Forms.Button();
            this.UART_Config.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_GREEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BLUE)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.POScontrolGraph)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // UART_Config
            // 
            this.UART_Config.Controls.Add(this.btnDisconnect);
            this.UART_Config.Controls.Add(this.btnConnect);
            this.UART_Config.Controls.Add(this.label5);
            this.UART_Config.Controls.Add(this.cbStopBits);
            this.UART_Config.Controls.Add(this.label3);
            this.UART_Config.Controls.Add(this.cbDataBits);
            this.UART_Config.Controls.Add(this.label4);
            this.UART_Config.Controls.Add(this.cbParity);
            this.UART_Config.Controls.Add(this.label2);
            this.UART_Config.Controls.Add(this.cbPortName);
            this.UART_Config.Controls.Add(this.label1);
            this.UART_Config.Controls.Add(this.cbBaudRate);
            this.UART_Config.Location = new System.Drawing.Point(9, 10);
            this.UART_Config.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UART_Config.Name = "UART_Config";
            this.UART_Config.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UART_Config.Size = new System.Drawing.Size(197, 243);
            this.UART_Config.TabIndex = 0;
            this.UART_Config.TabStop = false;
            this.UART_Config.Text = "UART Configuration";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Red;
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDisconnect.Location = new System.Drawing.Point(15, 205);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(166, 32);
            this.btnDisconnect.TabIndex = 13;
            this.btnDisconnect.Text = "DISCONNECT";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Lime;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(15, 158);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(166, 33);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "StopBits";
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(70, 124);
            this.cbStopBits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(111, 21);
            this.cbStopBits.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DataBits";
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(70, 75);
            this.cbDataBits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(111, 21);
            this.cbDataBits.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Parity";
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(70, 99);
            this.cbParity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(111, 21);
            this.cbParity.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(70, 26);
            this.cbPortName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(111, 21);
            this.cbPortName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BaudRate";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(70, 50);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(111, 21);
            this.cbBaudRate.TabIndex = 0;
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM5";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // txtReceivedMessages
            // 
            this.txtReceivedMessages.Location = new System.Drawing.Point(4, 15);
            this.txtReceivedMessages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReceivedMessages.Name = "txtReceivedMessages";
            this.txtReceivedMessages.Size = new System.Drawing.Size(580, 108);
            this.txtReceivedMessages.TabIndex = 1;
            this.txtReceivedMessages.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(532, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbBLUE);
            this.groupBox1.Controls.Add(this.lbGREEN);
            this.groupBox1.Controls.Add(this.lbRED);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.trackBar_GREEN);
            this.groupBox1.Controls.Add(this.trackBar_RED);
            this.groupBox1.Controls.Add(this.trackBar_BLUE);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(211, 143);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(259, 110);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digital Output";
            // 
            // lbBLUE
            // 
            this.lbBLUE.AutoSize = true;
            this.lbBLUE.Location = new System.Drawing.Point(206, 79);
            this.lbBLUE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBLUE.Name = "lbBLUE";
            this.lbBLUE.Size = new System.Drawing.Size(24, 13);
            this.lbBLUE.TabIndex = 33;
            this.lbBLUE.Text = "0 %";
            // 
            // lbGREEN
            // 
            this.lbGREEN.AutoSize = true;
            this.lbGREEN.Location = new System.Drawing.Point(206, 54);
            this.lbGREEN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGREEN.Name = "lbGREEN";
            this.lbGREEN.Size = new System.Drawing.Size(24, 13);
            this.lbGREEN.TabIndex = 32;
            this.lbGREEN.Text = "0 %";
            // 
            // lbRED
            // 
            this.lbRED.AutoSize = true;
            this.lbRED.Location = new System.Drawing.Point(206, 29);
            this.lbRED.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRED.Name = "lbRED";
            this.lbRED.Size = new System.Drawing.Size(24, 13);
            this.lbRED.TabIndex = 24;
            this.lbRED.Text = "0 %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "B";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(199, 82);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = " ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "G";
            // 
            // trackBar_GREEN
            // 
            this.trackBar_GREEN.AutoSize = false;
            this.trackBar_GREEN.Location = new System.Drawing.Point(35, 53);
            this.trackBar_GREEN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar_GREEN.Maximum = 999;
            this.trackBar_GREEN.Name = "trackBar_GREEN";
            this.trackBar_GREEN.Size = new System.Drawing.Size(173, 22);
            this.trackBar_GREEN.TabIndex = 28;
            this.trackBar_GREEN.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_GREEN.Scroll += new System.EventHandler(this.trackBar_GREEN_Scroll);
            // 
            // trackBar_RED
            // 
            this.trackBar_RED.AutoSize = false;
            this.trackBar_RED.Location = new System.Drawing.Point(35, 28);
            this.trackBar_RED.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar_RED.Maximum = 999;
            this.trackBar_RED.Name = "trackBar_RED";
            this.trackBar_RED.Size = new System.Drawing.Size(173, 22);
            this.trackBar_RED.TabIndex = 27;
            this.trackBar_RED.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_RED.Scroll += new System.EventHandler(this.trackBar_RED_Scroll);
            // 
            // trackBar_BLUE
            // 
            this.trackBar_BLUE.AutoSize = false;
            this.trackBar_BLUE.Location = new System.Drawing.Point(35, 79);
            this.trackBar_BLUE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar_BLUE.Maximum = 999;
            this.trackBar_BLUE.Name = "trackBar_BLUE";
            this.trackBar_BLUE.Size = new System.Drawing.Size(173, 22);
            this.trackBar_BLUE.TabIndex = 26;
            this.trackBar_BLUE.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_BLUE.Scroll += new System.EventHandler(this.trackBar_BLUE_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(91, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "RGB Color";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "R";
            // 
            // txttempvalue
            // 
            this.txttempvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttempvalue.Location = new System.Drawing.Point(16, 28);
            this.txttempvalue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txttempvalue.Name = "txttempvalue";
            this.txttempvalue.Size = new System.Drawing.Size(179, 28);
            this.txttempvalue.TabIndex = 6;
            this.txttempvalue.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReceivedMessages);
            this.groupBox2.Location = new System.Drawing.Point(474, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(588, 128);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received Messages";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(236, 25);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(81, 13);
            this.lbSpeed.TabIndex = 3;
            this.lbSpeed.Text = "Duty Cycle: 0 %";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(186, 39);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar1.Maximum = 999;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(178, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnResetCounter);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox12);
            this.groupBox4.Controls.Add(this.POScontrolGraph);
            this.groupBox4.Controls.Add(this.btnGraphPos);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Location = new System.Drawing.Point(11, 258);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(1050, 419);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Position";
            // 
            // btnResetCounter
            // 
            this.btnResetCounter.BackColor = System.Drawing.Color.Yellow;
            this.btnResetCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCounter.Location = new System.Drawing.Point(19, 151);
            this.btnResetCounter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetCounter.Name = "btnResetCounter";
            this.btnResetCounter.Size = new System.Drawing.Size(91, 71);
            this.btnResetCounter.TabIndex = 40;
            this.btnResetCounter.Text = "RESET COUNTER";
            this.btnResetCounter.UseVisualStyleBackColor = false;
            this.btnResetCounter.Click += new System.EventHandler(this.btnResetCounter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btn_90_click);
            this.groupBox3.Controls.Add(this.btn_180_click);
            this.groupBox3.Controls.Add(this.btn_360_click);
            this.groupBox3.Controls.Add(this.btn_270_click);
            this.groupBox3.Controls.Add(this.txtNonePID);
            this.groupBox3.Controls.Add(this.txtKdPos);
            this.groupBox3.Controls.Add(this.btnSendNonePID);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtKiPos);
            this.groupBox3.Controls.Add(this.txtKpPos);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnSendPos);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(14, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 185);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "None PID";
            // 
            // btn_90_click
            // 
            this.btn_90_click.Location = new System.Drawing.Point(11, 37);
            this.btn_90_click.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_90_click.Name = "btn_90_click";
            this.btn_90_click.Size = new System.Drawing.Size(40, 28);
            this.btn_90_click.TabIndex = 11;
            this.btn_90_click.Text = "90°";
            this.btn_90_click.UseVisualStyleBackColor = true;
            this.btn_90_click.Click += new System.EventHandler(this.btn_90_click_Click);
            // 
            // btn_180_click
            // 
            this.btn_180_click.Location = new System.Drawing.Point(59, 37);
            this.btn_180_click.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_180_click.Name = "btn_180_click";
            this.btn_180_click.Size = new System.Drawing.Size(40, 28);
            this.btn_180_click.TabIndex = 13;
            this.btn_180_click.Text = "180°";
            this.btn_180_click.UseVisualStyleBackColor = true;
            this.btn_180_click.Click += new System.EventHandler(this.btn_180_click_Click);
            // 
            // btn_360_click
            // 
            this.btn_360_click.Location = new System.Drawing.Point(59, 70);
            this.btn_360_click.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_360_click.Name = "btn_360_click";
            this.btn_360_click.Size = new System.Drawing.Size(40, 28);
            this.btn_360_click.TabIndex = 14;
            this.btn_360_click.Text = "360°";
            this.btn_360_click.UseVisualStyleBackColor = true;
            this.btn_360_click.Click += new System.EventHandler(this.btn_360_click_Click);
            // 
            // btn_270_click
            // 
            this.btn_270_click.Location = new System.Drawing.Point(11, 70);
            this.btn_270_click.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_270_click.Name = "btn_270_click";
            this.btn_270_click.Size = new System.Drawing.Size(40, 28);
            this.btn_270_click.TabIndex = 15;
            this.btn_270_click.Text = "270°";
            this.btn_270_click.UseVisualStyleBackColor = true;
            this.btn_270_click.Click += new System.EventHandler(this.btn_270_click_Click);
            // 
            // txtNonePID
            // 
            this.txtNonePID.Location = new System.Drawing.Point(11, 119);
            this.txtNonePID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNonePID.Multiline = true;
            this.txtNonePID.Name = "txtNonePID";
            this.txtNonePID.Size = new System.Drawing.Size(90, 28);
            this.txtNonePID.TabIndex = 11;
            this.txtNonePID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKdPos
            // 
            this.txtKdPos.Location = new System.Drawing.Point(148, 102);
            this.txtKdPos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKdPos.Multiline = true;
            this.txtKdPos.Name = "txtKdPos";
            this.txtKdPos.Size = new System.Drawing.Size(70, 28);
            this.txtKdPos.TabIndex = 11;
            // 
            // btnSendNonePID
            // 
            this.btnSendNonePID.BackColor = System.Drawing.Color.Lime;
            this.btnSendNonePID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNonePID.Location = new System.Drawing.Point(11, 148);
            this.btnSendNonePID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendNonePID.Name = "btnSendNonePID";
            this.btnSendNonePID.Size = new System.Drawing.Size(88, 28);
            this.btnSendNonePID.TabIndex = 11;
            this.btnSendNonePID.Text = "SEND";
            this.btnSendNonePID.UseVisualStyleBackColor = false;
            this.btnSendNonePID.Click += new System.EventHandler(this.btnSendNonePID_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "PID Controller";
            // 
            // txtKiPos
            // 
            this.txtKiPos.Location = new System.Drawing.Point(148, 70);
            this.txtKiPos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKiPos.Multiline = true;
            this.txtKiPos.Name = "txtKiPos";
            this.txtKiPos.Size = new System.Drawing.Size(70, 28);
            this.txtKiPos.TabIndex = 17;
            // 
            // txtKpPos
            // 
            this.txtKpPos.Location = new System.Drawing.Point(148, 37);
            this.txtKpPos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKpPos.Multiline = true;
            this.txtKpPos.Name = "txtKpPos";
            this.txtKpPos.Size = new System.Drawing.Size(71, 28);
            this.txtKpPos.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(120, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Kp:";
            // 
            // btnSendPos
            // 
            this.btnSendPos.BackColor = System.Drawing.Color.Lime;
            this.btnSendPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendPos.Location = new System.Drawing.Point(231, 37);
            this.btnSendPos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendPos.Name = "btnSendPos";
            this.btnSendPos.Size = new System.Drawing.Size(64, 93);
            this.btnSendPos.TabIndex = 23;
            this.btnSendPos.Text = "SEND";
            this.btnSendPos.UseVisualStyleBackColor = false;
            this.btnSendPos.Click += new System.EventHandler(this.btnSendPos_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(120, 77);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Ki:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(120, 109);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Kd:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 103);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Custom Degree";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtPulse);
            this.groupBox9.Controls.Add(this.txtPOT);
            this.groupBox9.Controls.Add(this.txtTxl);
            this.groupBox9.Controls.Add(this.label33);
            this.groupBox9.Controls.Add(this.txtAngle);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.label31);
            this.groupBox9.Location = new System.Drawing.Point(139, 28);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(176, 115);
            this.groupBox9.TabIndex = 39;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Parameters";
            // 
            // txtPulse
            // 
            this.txtPulse.Location = new System.Drawing.Point(4, 35);
            this.txtPulse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPulse.Multiline = true;
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.ReadOnly = true;
            this.txtPulse.Size = new System.Drawing.Size(77, 28);
            this.txtPulse.TabIndex = 31;
            this.txtPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPOT
            // 
            this.txtPOT.Location = new System.Drawing.Point(4, 81);
            this.txtPOT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPOT.Multiline = true;
            this.txtPOT.Name = "txtPOT";
            this.txtPOT.ReadOnly = true;
            this.txtPOT.Size = new System.Drawing.Size(77, 28);
            this.txtPOT.TabIndex = 18;
            this.txtPOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTxl
            // 
            this.txtTxl.Location = new System.Drawing.Point(95, 81);
            this.txtTxl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTxl.Multiline = true;
            this.txtTxl.Name = "txtTxl";
            this.txtTxl.ReadOnly = true;
            this.txtTxl.Size = new System.Drawing.Size(75, 28);
            this.txtTxl.TabIndex = 30;
            this.txtTxl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(122, 66);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(20, 13);
            this.label33.TabIndex = 36;
            this.label33.Text = "t xl";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(95, 35);
            this.txtAngle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAngle.Multiline = true;
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.ReadOnly = true;
            this.txtAngle.Size = new System.Drawing.Size(76, 28);
            this.txtAngle.TabIndex = 32;
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(29, 66);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 13);
            this.label32.TabIndex = 35;
            this.label32.Text = "POT";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(25, 20);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(33, 13);
            this.label30.TabIndex = 33;
            this.label30.Text = "Pulse";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(116, 20);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 13);
            this.label31.TabIndex = 34;
            this.label31.Text = "Angle";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.CBCalibration);
            this.groupBox12.Controls.Add(this.btnZeroCalib);
            this.groupBox12.Controls.Add(this.btnSpanCalib);
            this.groupBox12.Location = new System.Drawing.Point(13, 28);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(120, 115);
            this.groupBox12.TabIndex = 39;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Calibration";
            // 
            // CBCalibration
            // 
            this.CBCalibration.AutoSize = true;
            this.CBCalibration.Location = new System.Drawing.Point(55, 93);
            this.CBCalibration.Name = "CBCalibration";
            this.CBCalibration.Size = new System.Drawing.Size(15, 14);
            this.CBCalibration.TabIndex = 40;
            this.CBCalibration.UseVisualStyleBackColor = true;
            this.CBCalibration.CheckedChanged += new System.EventHandler(this.CBCalibration_CheckedChanged);
            // 
            // btnZeroCalib
            // 
            this.btnZeroCalib.BackColor = System.Drawing.Color.Yellow;
            this.btnZeroCalib.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroCalib.Location = new System.Drawing.Point(6, 22);
            this.btnZeroCalib.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnZeroCalib.Name = "btnZeroCalib";
            this.btnZeroCalib.Size = new System.Drawing.Size(109, 27);
            this.btnZeroCalib.TabIndex = 28;
            this.btnZeroCalib.Text = "ZERO";
            this.btnZeroCalib.UseVisualStyleBackColor = false;
            this.btnZeroCalib.Click += new System.EventHandler(this.btnZeroCalib_Click);
            // 
            // btnSpanCalib
            // 
            this.btnSpanCalib.BackColor = System.Drawing.Color.Yellow;
            this.btnSpanCalib.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpanCalib.Location = new System.Drawing.Point(6, 58);
            this.btnSpanCalib.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSpanCalib.Name = "btnSpanCalib";
            this.btnSpanCalib.Size = new System.Drawing.Size(109, 28);
            this.btnSpanCalib.TabIndex = 37;
            this.btnSpanCalib.Text = "SPAN";
            this.btnSpanCalib.UseVisualStyleBackColor = false;
            this.btnSpanCalib.Click += new System.EventHandler(this.btnSpanCalib_Click);
            // 
            // POScontrolGraph
            // 
            this.POScontrolGraph.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.POScontrolGraph.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.POScontrolGraph.Legends.Add(legend2);
            this.POScontrolGraph.Location = new System.Drawing.Point(330, 28);
            this.POScontrolGraph.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.POScontrolGraph.Name = "POScontrolGraph";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Position";
            this.POScontrolGraph.Series.Add(series2);
            this.POScontrolGraph.Size = new System.Drawing.Size(707, 368);
            this.POScontrolGraph.TabIndex = 25;
            this.POScontrolGraph.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Position Control";
            this.POScontrolGraph.Titles.Add(title2);
            // 
            // btnGraphPos
            // 
            this.btnGraphPos.BackColor = System.Drawing.Color.Yellow;
            this.btnGraphPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphPos.Location = new System.Drawing.Point(219, 151);
            this.btnGraphPos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGraphPos.Name = "btnGraphPos";
            this.btnGraphPos.Size = new System.Drawing.Size(91, 71);
            this.btnGraphPos.TabIndex = 27;
            this.btnGraphPos.Text = "GRAPH";
            this.btnGraphPos.UseVisualStyleBackColor = false;
            this.btnGraphPos.Click += new System.EventHandler(this.btnGraphPos_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Yellow;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(119, 151);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(91, 71);
            this.button9.TabIndex = 4;
            this.button9.Text = "GET DATA";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtConnectUSBCDC);
            this.groupBox6.Controls.Add(this.txtVendor);
            this.groupBox6.Controls.Add(this.txtProductID);
            this.groupBox6.Controls.Add(this.txtVendorID);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.button12);
            this.groupBox6.Controls.Add(this.button13);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Location = new System.Drawing.Point(211, 10);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Size = new System.Drawing.Size(259, 128);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "USB CDC Configuration";
            // 
            // txtConnectUSBCDC
            // 
            this.txtConnectUSBCDC.BackColor = System.Drawing.Color.Lime;
            this.txtConnectUSBCDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectUSBCDC.Location = new System.Drawing.Point(162, 26);
            this.txtConnectUSBCDC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConnectUSBCDC.Name = "txtConnectUSBCDC";
            this.txtConnectUSBCDC.Size = new System.Drawing.Size(91, 93);
            this.txtConnectUSBCDC.TabIndex = 14;
            this.txtConnectUSBCDC.Text = "CONNECT";
            this.txtConnectUSBCDC.UseVisualStyleBackColor = false;
            this.txtConnectUSBCDC.Click += new System.EventHandler(this.txtConnectUSBCDC_Click);
            // 
            // txtVendor
            // 
            this.txtVendor.Location = new System.Drawing.Point(76, 91);
            this.txtVendor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVendor.Multiline = true;
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(79, 28);
            this.txtVendor.TabIndex = 26;
            this.txtVendor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(76, 58);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProductID.Multiline = true;
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(79, 28);
            this.txtProductID.TabIndex = 25;
            this.txtProductID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVendorID
            // 
            this.txtVendorID.Location = new System.Drawing.Point(76, 26);
            this.txtVendorID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVendorID.Multiline = true;
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(79, 28);
            this.txtVendorID.TabIndex = 24;
            this.txtVendorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 98);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Vendor";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 66);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "ProductID";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Red;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button12.Location = new System.Drawing.Point(15, 205);
            this.button12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(166, 32);
            this.button12.TabIndex = 13;
            this.button12.Text = "DISCONNECT";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Lime;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(15, 158);
            this.button13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(166, 33);
            this.button13.TabIndex = 12;
            this.button13.Text = "CONNECT";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(14, 33);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 3;
            this.label26.Text = "VendorID";
            // 
            // Timer_Position
            // 
            this.Timer_Position.Interval = 50;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnStop);
            this.groupBox8.Controls.Add(this.btnStart);
            this.groupBox8.Controls.Add(this.txttempvalue);
            this.groupBox8.Location = new System.Drawing.Point(853, 144);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox8.Size = new System.Drawing.Size(208, 110);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Analog Input";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStop.Location = new System.Drawing.Point(116, 68);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(79, 32);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Lime;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(16, 67);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(79, 33);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnSendDAC);
            this.groupBox10.Controls.Add(this.cbSRAM);
            this.groupBox10.Controls.Add(this.lbDAC);
            this.groupBox10.Controls.Add(this.lbSpeed);
            this.groupBox10.Controls.Add(this.trackBar1);
            this.groupBox10.Controls.Add(this.trackBar2);
            this.groupBox10.Location = new System.Drawing.Point(479, 144);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox10.Size = new System.Drawing.Size(368, 110);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Analog Output";
            // 
            // lbDAC
            // 
            this.lbDAC.AutoSize = true;
            this.lbDAC.Location = new System.Drawing.Point(70, 29);
            this.lbDAC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDAC.Name = "lbDAC";
            this.lbDAC.Size = new System.Drawing.Size(51, 13);
            this.lbDAC.TabIndex = 5;
            this.lbDAC.Text = "DAC: 0 V";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(6, 39);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar2.Maximum = 4095;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(178, 45);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // cbSRAM
            // 
            this.cbSRAM.AutoSize = true;
            this.cbSRAM.Location = new System.Drawing.Point(6, 81);
            this.cbSRAM.Name = "cbSRAM";
            this.cbSRAM.Size = new System.Drawing.Size(57, 17);
            this.cbSRAM.TabIndex = 6;
            this.cbSRAM.Text = "SRAM";
            this.cbSRAM.UseVisualStyleBackColor = true;
            this.cbSRAM.CheckedChanged += new System.EventHandler(this.cbSRAM_CheckedChanged);
            // 
            // btnSendDAC
            // 
            this.btnSendDAC.BackColor = System.Drawing.Color.Lime;
            this.btnSendDAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendDAC.Location = new System.Drawing.Point(68, 73);
            this.btnSendDAC.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendDAC.Name = "btnSendDAC";
            this.btnSendDAC.Size = new System.Drawing.Size(114, 30);
            this.btnSendDAC.TabIndex = 15;
            this.btnSendDAC.Text = "Send";
            this.btnSendDAC.UseVisualStyleBackColor = false;
            this.btnSendDAC.Click += new System.EventHandler(this.btnSendDAC_Click);
            // 
            // bttime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 704);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UART_Config);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "bttime";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UART_Config.ResumeLayout(false);
            this.UART_Config.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_GREEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BLUE)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.POScontrolGraph)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UART_Config;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RichTextBox txtReceivedMessages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txttempvalue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_90_click;
        private System.Windows.Forms.Button btn_270_click;
        private System.Windows.Forms.Button btn_360_click;
        private System.Windows.Forms.Button btn_180_click;
        private System.Windows.Forms.TextBox txtNonePID;
        private System.Windows.Forms.Button btnSendNonePID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtKpPos;
        private System.Windows.Forms.TextBox txtKiPos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKdPos;
        private System.Windows.Forms.Button btnSendPos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataVisualization.Charting.Chart POScontrolGraph;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnGraphPos;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVendorID;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button txtConnectUSBCDC;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Timer Timer_Position;
        private System.Windows.Forms.Button btnZeroCalib;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.TextBox txtTxl;
        private System.Windows.Forms.TextBox txtPOT;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnSpanCalib;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CBCalibration;
        private System.Windows.Forms.Button btnResetCounter;
        private System.Windows.Forms.TrackBar trackBar_BLUE;
        private System.Windows.Forms.TrackBar trackBar_GREEN;
        private System.Windows.Forms.TrackBar trackBar_RED;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbBLUE;
        private System.Windows.Forms.Label lbGREEN;
        private System.Windows.Forms.Label lbRED;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label lbDAC;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbSRAM;
        private System.Windows.Forms.Button btnSendDAC;
    }
}

