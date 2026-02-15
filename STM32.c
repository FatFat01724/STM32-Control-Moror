/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2025 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "usb_device.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <stdbool.h>
#include "usbd_cdc_if.h"
#include "string.h"
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
volatile uint8_t data_recieved_flag=0;
volatile uint8_t mode_001_flag=0;
volatile uint8_t mode_000_flag=0;
volatile uint8_t mode_010_flag=0;
volatile uint8_t mode_011_flag=0;
volatile uint8_t mode_012_flag=0;
volatile uint8_t mode_013_flag=0;
volatile uint8_t mode_014_flag=0;
volatile uint8_t mode_020_flag=0;
volatile uint8_t mode_021_flag=0;
volatile uint8_t mode_022_flag=0;
volatile uint8_t mode_023_flag=0;
volatile uint8_t SRAM_Flag=0;


volatile uint8_t span_flag = 0;
volatile uint8_t page_index=0;
volatile uint8_t usb_data_flag;

volatile short calibrated_pulse = 937;
volatile short calibrated_pulse_read = 0;
volatile uint8_t zero_calib=0;
volatile uint8_t span_calib=0;


volatile short pulse=0;
volatile float f_Mea_Now, f_Err_Now = 0, f_Err_Pre = 0;
volatile static float f_Int = 0, f_Der = 0;
volatile float f_SP = 937, f_Kp, f_Ki, f_Kd;
volatile float f_Del = 0.02;
volatile int i_Out;
volatile float output;

uint16_t pwmValue;
uint16_t data_Poi_None_PID;
uint16_t data_Pulse_None_PID;

uint8_t spi_buffer[2];
uint8_t data_RX[15]={0};
float data_PID[3]={0};
uint8_t data_PID_buff[6]={0};
uint8_t data_Poi[4]={0};
uint8_t data_TX[63];
uint8_t calibrated_pulse_read_raw[4]={0};
uint8_t data_DAC[4]={0};
uint16_t DAC_Value;
uint32_t PT100_value = 0;

uint16_t holdTime=0;
uint16_t data_counter=0;
uint8_t data_pointer=0;
uint16_t page_counter=0;
uint16_t page_reader=0;
char data_array[5];
uint8_t data_motor_write[64];
uint8_t data_motor_read[60];
uint8_t data_motor_read_2[64];

#define EEPROM_ADDR 0x50 << 1
#define MCP4725_ADDR 0xC0

uint8_t data[] = "zMy name is Phat\r\n{";
uint8_t data_trans1[] = "LED_1_ON \n";
uint8_t data_trans11[] = "LED_1_OFF \n";
uint8_t data_trans2[] = "LED_2_ON \n";
uint8_t data_trans22[] = "LED_2_OFF \n";
uint8_t data_trans3[] = "LED_3_ON \n";
uint8_t data_trans33[] = "LED_3_OFF \n";
uint8_t data_trans4[] = "MOTOR_IS_RUNNING \n";
uint8_t data_trans44[] = "MOTOR_IS_STOPPING \n";
uint8_t data_trans5[] = "Zero Calibrated\n";
uint8_t data_trans6[] = "Span Calibrated\n";

uint8_t bSTX=0x02;
uint8_t bETX=0x03;
uint8_t receivedByte=0;
uint8_t isReceiving=0;
uint8_t uartrecvalue[128];
uint8_t receive_data[128];

uint8_t pulse_read [3]={0};
uint8_t data_led[3]={0};
uint8_t color_led;

uint16_t PT100_index = 0;
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
ADC_HandleTypeDef hadc1;
DMA_HandleTypeDef hdma_adc1;

I2C_HandleTypeDef hi2c1;

SPI_HandleTypeDef hspi1;

TIM_HandleTypeDef htim1;
TIM_HandleTypeDef htim2;
TIM_HandleTypeDef htim3;
TIM_HandleTypeDef htim4;

/* USER CODE BEGIN PV */

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_DMA_Init(void);
static void MX_TIM1_Init(void);
static void MX_TIM2_Init(void);
static void MX_TIM4_Init(void);
static void MX_I2C1_Init(void);
static void MX_SPI1_Init(void);
static void MX_TIM3_Init(void);
static void MX_ADC1_Init(void);
/* USER CODE BEGIN PFP */
void Forward_Turning(uint16_t pwmValue2);
void Reverse_Turning(uint16_t pwmValue2);
void Stop_Turning(void);
void SRAM_GPIO_Init(void);
void SRAM_SetDataAsOutput(void);
void SRAM_SetDataAsInput(void);
void SRAM_SetAddress(uint8_t addr);
void SRAM_WriteByte(uint8_t addr, uint8_t data);
uint8_t SRAM_ReadByte(uint8_t addr);

void Data_Receive(void);
void Process_data(void);
void MAX7219_SendData(uint8_t address, uint8_t data);
void MAX7219_Cleardata();
void MAX7219_Init(void);
void PT100_ADC(void);

void MCP4725_Write(uint16_t value);
void beep(uint16_t level, uint32_t duration_ms);


/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{

  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */
  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_TIM1_Init();
  MX_TIM2_Init();
  MX_USB_DEVICE_Init();
  MX_TIM4_Init();
  MX_I2C1_Init();
  MX_SPI1_Init();
  MX_TIM3_Init();
  MX_ADC1_Init();
  /* USER CODE BEGIN 2 */
	HAL_TIM_PWM_Start(&htim1, TIM_CHANNEL_1);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_1);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_3);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_4);
	
	HAL_ADC_Start_DMA(&hadc1, &PT100_value, 1);
	//HAL_UART_Receive_DMA(&huart1, uartrecvalue,15);
	HAL_TIM_Encoder_Start(&htim2, TIM_CHANNEL_1|TIM_CHANNEL_2);
	MAX7219_Init();
	SRAM_GPIO_Init();
	MCP4725_Write(0);

  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
		if(usb_data_flag==1)
		{
			Process_data();
			if(mode_001_flag ==1)
			{
				mode_001_flag = 0;
				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_14,0);
				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_15,1);
				pwmValue =atoi((char*)data_RX);
				MAX7219_SendData(3,pwmValue/100);	
				MAX7219_SendData(2,((pwmValue)/10)%10);	
				MAX7219_SendData(1,pwmValue%10);		
				__HAL_TIM_SET_COMPARE(&htim1,TIM_CHANNEL_1,pwmValue);
				__HAL_TIM_SET_COUNTER(&htim2, 0);
				usb_data_flag =0;
			}
			
			if(mode_010_flag ==1)
			{
				uint32_t holdTime = 0;
				uint32_t lastTime = 0;
				HAL_I2C_Mem_Read(&hi2c1, EEPROM_ADDR, 32704, 2, calibrated_pulse_read_raw, 4, 1000);
				HAL_Delay(5);
				calibrated_pulse_read = calibrated_pulse_read_raw[1]<<8 | (calibrated_pulse_read_raw[2]);
				if(calibrated_pulse_read != 0)
				{
					calibrated_pulse = calibrated_pulse_read;
					memset(data_TX, 0, sizeof(data_TX));
					sprintf((char*)data_TX,"%c%c%u%c",bSTX,'E',calibrated_pulse,bETX);
					CDC_Transmit_FS(data_TX,7);					
				}
				data_Poi[3] = '\0';
				data_Poi_None_PID = atoi((char*)data_Poi);
				data_Pulse_None_PID = (data_Poi_None_PID)*((double)calibrated_pulse/360.0);

				while(1)
				{
					pulse = __HAL_TIM_GET_COUNTER(&htim2); 
					memset(data_TX, 0, sizeof(data_TX));
					sprintf((char*)data_TX,"%c%c%u",bSTX,'D',pulse);
					data_TX[9] = bETX;
					CDC_Transmit_FS(data_TX,10);					
					if (pulse<=0) 
					{
						Forward_Turning(400);
						holdTime=0;
					}
					else if (pulse < (data_Pulse_None_PID)*0.98)
					{ 
						Forward_Turning(400);
						holdTime=0;
					}
					else if (pulse > (data_Pulse_None_PID)*1.02)
					{
						Reverse_Turning(400);
						holdTime=0;
					}
					else if (pulse >=(data_Pulse_None_PID)*0.98 && pulse <= (data_Pulse_None_PID)*1.02)
					{
						Stop_Turning();
						if(pulse < (data_Pulse_None_PID)*0.98 || pulse >(data_Pulse_None_PID)*1.02)
						{
							break;
						}
						uint32_t currentTime = HAL_GetTick();
								if (currentTime - lastTime >= 100) 
								{
										holdTime += 100;
										lastTime = currentTime;
								}

								if (holdTime >= 3000)
								{
										Stop_Turning();
										mode_010_flag = 0; 
										usb_data_flag =0;
										HAL_TIM_Base_Stop_IT(&htim4);
										
										beep(4095, 100);
										beep(4095, 100);
										beep(4095, 100);
									
										if(SRAM_Flag == 1)
										{
											for (uint8_t addr = 0; addr < 4; addr++) 
											{
												uint8_t value = SRAM_ReadByte(addr);
												data_DAC[addr]= value;
											}
											DAC_Value =atoi((char*)data_DAC);
											MCP4725_Write(DAC_Value);
										}
										break;
								}		
					}
				}	
			}

			if(mode_011_flag ==1)
			{
				uint32_t holdTime = 0;
				uint32_t lastTime = 0;
				uint32_t lastMea = 0;  
				HAL_I2C_Mem_Read(&hi2c1, EEPROM_ADDR, 32704, 2, calibrated_pulse_read_raw, 4, 1000);
				HAL_Delay(5);
				calibrated_pulse_read = calibrated_pulse_read_raw[1]<<8 | (calibrated_pulse_read_raw[2]);
				if(calibrated_pulse_read != 0)
				{
					calibrated_pulse = calibrated_pulse_read;
				}
				while(1)
				{
					f_Mea_Now = __HAL_TIM_GET_COUNTER(&htim2);
					memset(data_TX, 0, sizeof(data_TX));
					sprintf((char*)data_TX,"%c%c%u",bSTX,'D',(int)f_Mea_Now);
					data_TX[6] = bETX;
					CDC_Transmit_FS(data_TX,7);
					//MAX7219_SendData(3, (int)(f_Mea_Now/100));
					//MAX7219_SendData(2, (int)(f_Mea_Now/10)%10);
					//MAX7219_SendData(1, (int)(f_Mea_Now)%10);

					if (f_Mea_Now >=(calibrated_pulse)*0.98 && f_Mea_Now <= (calibrated_pulse)*1.02)
					{
						if(f_Mea_Now < (calibrated_pulse)*0.98 && f_Mea_Now > (calibrated_pulse)*1.02)
						{
							break;  
						}
						uint32_t currentTime = HAL_GetTick();
						if (currentTime - lastTime >= 100)
						{
							holdTime += 100;
							lastTime = currentTime;
						}
						if (holdTime >= 3000)
						{
							Stop_Turning();
							mode_011_flag = 0;
							usb_data_flag =0;
							HAL_TIM_Base_Stop_IT(&htim4);
							beep(4095, 100);
							beep(4095, 100);
							beep(4095, 100);
							break;
						}
					}
				}
			}
			if(mode_012_flag ==1)
			{
				for (page_reader = 0; page_reader <= 576; page_reader+=64)
				{
					HAL_I2C_Mem_Read(&hi2c1, EEPROM_ADDR, page_reader, 2, data_motor_read, sizeof(data_motor_read), 1000);
					HAL_Delay(5);
					data_TX[0]=bSTX;
					data_TX[1]='P';
					memcpy(&data_TX[2], data_motor_read, sizeof(data_motor_read));
					data_TX[62]=bETX;
					CDC_Transmit_FS(data_TX,sizeof(data_TX));	
				}
				mode_012_flag=0;	
				usb_data_flag =0;
			}		
			
			if(mode_013_flag ==1)		
			{
				__HAL_TIM_SET_COUNTER(&htim2,0);
				MAX7219_SendData(1,0);
				MAX7219_SendData(2,0);
				MAX7219_SendData(3,0);
				MAX7219_SendData(4,0);				
				mode_013_flag = 0;
				usb_data_flag =0;
			}
			
			if(mode_014_flag ==1)		
			{
				pulse = __HAL_TIM_GET_COUNTER(&htim2);
				MAX7219_SendData(4, pulse/1000);
				MAX7219_SendData(3, (pulse/100)%10);
				MAX7219_SendData(2, (pulse/10)%10);
				MAX7219_SendData(1, pulse%10);
				memset(data_TX, 0, sizeof(data_TX));
				sprintf((char*)data_TX,"%c%c%u",bSTX,'D',pulse);
				data_TX[9] = bETX;
				CDC_Transmit_FS(data_TX,10);

				if(zero_calib == 1)
				{
					__HAL_TIM_SET_COUNTER(&htim2,0);
					memset(data_TX, 0, sizeof(data_TX));
					sprintf((char*)data_TX,"%c%c%s",bSTX,'C',data_trans5);
					data_TX[15] = bETX;
					CDC_Transmit_FS(data_TX,sizeof(data_TX));
					zero_calib = 0;
				}
				if(span_calib == 1 && zero_calib == 0)
				{
					calibrated_pulse = __HAL_TIM_GET_COUNTER(&htim2);
					pulse_read[0] = 0x00;
					pulse_read[1] = (calibrated_pulse >> 8)& 0xFF;
					pulse_read[2] = calibrated_pulse & 0xFF;
					memset(data_TX, 0, sizeof(data_TX));
					sprintf((char*)data_TX,"%c%c%s",bSTX,'C',data_trans6);
					data_TX[15U] = bETX;
					CDC_Transmit_FS(data_TX,sizeof(data_TX));
					HAL_I2C_Mem_Write(&hi2c1, EEPROM_ADDR, 32704, 2, pulse_read, sizeof(pulse_read), 1000);
					HAL_Delay(5);
					span_calib = 0;
					span_flag = 0;			
					mode_014_flag = 0;
					usb_data_flag = 0;
					beep(4095, 100);
				}
			}
			if(mode_020_flag ==1)
			{
				mode_020_flag = 0;
				pwmValue =atoi((char*)data_led);
				if(color_led == 'R')
				{
					__HAL_TIM_SET_COMPARE(&htim3,TIM_CHANNEL_1,pwmValue);
				}	
				else if(color_led == 'G')
				{
					__HAL_TIM_SET_COMPARE(&htim3,TIM_CHANNEL_3,pwmValue);
				}
				else if(color_led == 'B')
				{
					__HAL_TIM_SET_COMPARE(&htim3,TIM_CHANNEL_4,pwmValue);
				}
				usb_data_flag =0;
			}			
			
			if(mode_021_flag ==1)
			{
				mode_021_flag = 0;
				DAC_Value =atoi((char*)data_DAC);
				MCP4725_Write(DAC_Value);
				usb_data_flag =0;
			}

			if(mode_022_flag ==1)
			{
				usb_data_flag =0;
			}					
		}		
	}

    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.HSEPredivValue = RCC_HSE_PREDIV_DIV1;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL9;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_ADC|RCC_PERIPHCLK_USB;
  PeriphClkInit.AdcClockSelection = RCC_ADCPCLK2_DIV8;
  PeriphClkInit.UsbClockSelection = RCC_USBCLKSOURCE_PLL_DIV1_5;
  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief ADC1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_ADC1_Init(void)
{

  /* USER CODE BEGIN ADC1_Init 0 */

  /* USER CODE END ADC1_Init 0 */

  ADC_ChannelConfTypeDef sConfig = {0};

  /* USER CODE BEGIN ADC1_Init 1 */

  /* USER CODE END ADC1_Init 1 */

  /** Common config
  */
  hadc1.Instance = ADC1;
  hadc1.Init.ScanConvMode = ADC_SCAN_DISABLE;
  hadc1.Init.ContinuousConvMode = ENABLE;
  hadc1.Init.DiscontinuousConvMode = DISABLE;
  hadc1.Init.ExternalTrigConv = ADC_SOFTWARE_START;
  hadc1.Init.DataAlign = ADC_DATAALIGN_RIGHT;
  hadc1.Init.NbrOfConversion = 1;
  if (HAL_ADC_Init(&hadc1) != HAL_OK)
  {
    Error_Handler();
  }

  /** Configure Regular Channel
  */
  sConfig.Channel = ADC_CHANNEL_3;
  sConfig.Rank = ADC_REGULAR_RANK_1;
  sConfig.SamplingTime = ADC_SAMPLETIME_239CYCLES_5;
  if (HAL_ADC_ConfigChannel(&hadc1, &sConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN ADC1_Init 2 */

  /* USER CODE END ADC1_Init 2 */

}

/**
  * @brief I2C1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_I2C1_Init(void)
{

  /* USER CODE BEGIN I2C1_Init 0 */

  /* USER CODE END I2C1_Init 0 */

  /* USER CODE BEGIN I2C1_Init 1 */

  /* USER CODE END I2C1_Init 1 */
  hi2c1.Instance = I2C1;
  hi2c1.Init.ClockSpeed = 400000;
  hi2c1.Init.DutyCycle = I2C_DUTYCYCLE_2;
  hi2c1.Init.OwnAddress1 = 0;
  hi2c1.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
  hi2c1.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
  hi2c1.Init.OwnAddress2 = 0;
  hi2c1.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
  hi2c1.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
  if (HAL_I2C_Init(&hi2c1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN I2C1_Init 2 */

  /* USER CODE END I2C1_Init 2 */

}

/**
  * @brief SPI1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_SPI1_Init(void)
{

  /* USER CODE BEGIN SPI1_Init 0 */

  /* USER CODE END SPI1_Init 0 */

  /* USER CODE BEGIN SPI1_Init 1 */

  /* USER CODE END SPI1_Init 1 */
  /* SPI1 parameter configuration*/
  hspi1.Instance = SPI1;
  hspi1.Init.Mode = SPI_MODE_MASTER;
  hspi1.Init.Direction = SPI_DIRECTION_2LINES;
  hspi1.Init.DataSize = SPI_DATASIZE_8BIT;
  hspi1.Init.CLKPolarity = SPI_POLARITY_LOW;
  hspi1.Init.CLKPhase = SPI_PHASE_1EDGE;
  hspi1.Init.NSS = SPI_NSS_SOFT;
  hspi1.Init.BaudRatePrescaler = SPI_BAUDRATEPRESCALER_8;
  hspi1.Init.FirstBit = SPI_FIRSTBIT_MSB;
  hspi1.Init.TIMode = SPI_TIMODE_DISABLE;
  hspi1.Init.CRCCalculation = SPI_CRCCALCULATION_DISABLE;
  hspi1.Init.CRCPolynomial = 10;
  if (HAL_SPI_Init(&hspi1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN SPI1_Init 2 */

  /* USER CODE END SPI1_Init 2 */

}

/**
  * @brief TIM1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM1_Init(void)
{

  /* USER CODE BEGIN TIM1_Init 0 */

  /* USER CODE END TIM1_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};
  TIM_BreakDeadTimeConfigTypeDef sBreakDeadTimeConfig = {0};

  /* USER CODE BEGIN TIM1_Init 1 */

  /* USER CODE END TIM1_Init 1 */
  htim1.Instance = TIM1;
  htim1.Init.Prescaler = 71;
  htim1.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim1.Init.Period = 999;
  htim1.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim1.Init.RepetitionCounter = 0;
  htim1.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim1) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim1, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim1) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim1, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCNPolarity = TIM_OCNPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  sConfigOC.OCIdleState = TIM_OCIDLESTATE_RESET;
  sConfigOC.OCNIdleState = TIM_OCNIDLESTATE_RESET;
  if (HAL_TIM_PWM_ConfigChannel(&htim1, &sConfigOC, TIM_CHANNEL_1) != HAL_OK)
  {
    Error_Handler();
  }
  sBreakDeadTimeConfig.OffStateRunMode = TIM_OSSR_DISABLE;
  sBreakDeadTimeConfig.OffStateIDLEMode = TIM_OSSI_DISABLE;
  sBreakDeadTimeConfig.LockLevel = TIM_LOCKLEVEL_OFF;
  sBreakDeadTimeConfig.DeadTime = 0;
  sBreakDeadTimeConfig.BreakState = TIM_BREAK_DISABLE;
  sBreakDeadTimeConfig.BreakPolarity = TIM_BREAKPOLARITY_HIGH;
  sBreakDeadTimeConfig.AutomaticOutput = TIM_AUTOMATICOUTPUT_DISABLE;
  if (HAL_TIMEx_ConfigBreakDeadTime(&htim1, &sBreakDeadTimeConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM1_Init 2 */

  /* USER CODE END TIM1_Init 2 */
  HAL_TIM_MspPostInit(&htim1);

}

/**
  * @brief TIM2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM2_Init(void)
{

  /* USER CODE BEGIN TIM2_Init 0 */

  /* USER CODE END TIM2_Init 0 */

  TIM_Encoder_InitTypeDef sConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM2_Init 1 */

  /* USER CODE END TIM2_Init 1 */
  htim2.Instance = TIM2;
  htim2.Init.Prescaler = 0;
  htim2.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim2.Init.Period = 65535;
  htim2.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim2.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  sConfig.EncoderMode = TIM_ENCODERMODE_TI12;
  sConfig.IC1Polarity = TIM_ICPOLARITY_RISING;
  sConfig.IC1Selection = TIM_ICSELECTION_DIRECTTI;
  sConfig.IC1Prescaler = TIM_ICPSC_DIV1;
  sConfig.IC1Filter = 0;
  sConfig.IC2Polarity = TIM_ICPOLARITY_RISING;
  sConfig.IC2Selection = TIM_ICSELECTION_DIRECTTI;
  sConfig.IC2Prescaler = TIM_ICPSC_DIV1;
  sConfig.IC2Filter = 0;
  if (HAL_TIM_Encoder_Init(&htim2, &sConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim2, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM2_Init 2 */

  /* USER CODE END TIM2_Init 2 */

}

/**
  * @brief TIM3 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM3_Init(void)
{

  /* USER CODE BEGIN TIM3_Init 0 */

  /* USER CODE END TIM3_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};

  /* USER CODE BEGIN TIM3_Init 1 */

  /* USER CODE END TIM3_Init 1 */
  htim3.Instance = TIM3;
  htim3.Init.Prescaler = 71;
  htim3.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim3.Init.Period = 999;
  htim3.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim3.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim3) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim3, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim3) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim3, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  if (HAL_TIM_PWM_ConfigChannel(&htim3, &sConfigOC, TIM_CHANNEL_1) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_ConfigChannel(&htim3, &sConfigOC, TIM_CHANNEL_3) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_ConfigChannel(&htim3, &sConfigOC, TIM_CHANNEL_4) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM3_Init 2 */

  /* USER CODE END TIM3_Init 2 */
  HAL_TIM_MspPostInit(&htim3);

}

/**
  * @brief TIM4 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM4_Init(void)
{

  /* USER CODE BEGIN TIM4_Init 0 */

  /* USER CODE END TIM4_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM4_Init 1 */

  /* USER CODE END TIM4_Init 1 */
  htim4.Instance = TIM4;
  htim4.Init.Prescaler = 799;
  htim4.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim4.Init.Period = 1799;
  htim4.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim4.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim4) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim4, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim4, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM4_Init 2 */

  /* USER CODE END TIM4_Init 2 */

}

/**
  * Enable DMA controller clock
  */
static void MX_DMA_Init(void)
{

  /* DMA controller clock enable */
  __HAL_RCC_DMA1_CLK_ENABLE();

  /* DMA interrupt init */
  /* DMA1_Channel1_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Channel1_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Channel1_IRQn);

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};
/* USER CODE BEGIN MX_GPIO_Init_1 */
/* USER CODE END MX_GPIO_Init_1 */

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOD_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOB, GPIO_PIN_14|GPIO_PIN_15, GPIO_PIN_RESET);

  /*Configure GPIO pin : PA4 */
  GPIO_InitStruct.Pin = GPIO_PIN_4;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : PB14 PB15 */
  GPIO_InitStruct.Pin = GPIO_PIN_14|GPIO_PIN_15;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

/* USER CODE BEGIN MX_GPIO_Init_2 */
/* USER CODE END MX_GPIO_Init_2 */
}

/* USER CODE BEGIN 4 */
void Forward_Turning(uint16_t pwmValue2)
{
	__HAL_TIM_SET_COMPARE(&htim1,TIM_CHANNEL_1,pwmValue2);
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_14,0);
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_15,1);
	HAL_GPIO_WritePin(GPIOA,GPIO_PIN_8,1);	
}

void Reverse_Turning(uint16_t pwmValue2)
{
	__HAL_TIM_SET_COMPARE(&htim1,TIM_CHANNEL_1,pwmValue2);
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_14,1);
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_15,0);
	HAL_GPIO_WritePin(GPIOA,GPIO_PIN_8,1);

}

void Stop_Turning(void)
{	
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_14,0);
	HAL_GPIO_WritePin(GPIOB,GPIO_PIN_15,0);
	HAL_GPIO_WritePin(GPIOA,GPIO_PIN_8,0);

}

void Data_Receive(void)
{
	for(int i=0; i<128; i++)
	{
		if(receive_data[i] == bSTX)
		{
			isReceiving=1;
		}
		else if(receive_data[i] == bETX && isReceiving)
		{
			isReceiving=0;		
		}
		else if(isReceiving)
		{
			for(int i=1;i<127;i++)
				{
					uartrecvalue[i-1] = receive_data[i];
				}
		}
	}
}
void Process_data(void)
{
	Data_Receive();
//---------------------------------------------------------------------------------
//-------------------------- MODE: 000 | DIGITAL OUTPUT ---------------------------
//---------------------------------------------------------------------------------
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='0'&&uartrecvalue[2]=='0')
				{
					mode_000_flag=1;
					if (uartrecvalue[3] == 0x7A)
						{
						HAL_GPIO_WritePin(GPIOA,GPIO_PIN_0,1);
						memset(data_TX, 0, sizeof(data_TX));
						sprintf((char*)data_TX,"%c%c%s",bSTX,'A',data_trans1);
						data_TX[62] = bETX;
						CDC_Transmit_FS(data_TX,sizeof(data_TX));
						}
					else if (uartrecvalue[3] == 0x7B)
						{
						HAL_GPIO_WritePin(GPIOA,GPIO_PIN_0,0);
						memset(data_TX, 0, sizeof(data_TX));
						sprintf((char*)data_TX,"%c%c%s",bSTX,'A',data_trans11);
						data_TX[62] = bETX;							
						CDC_Transmit_FS(data_TX,sizeof(data_TX));
						}
					if (uartrecvalue[4] == 0x7A)
						{
						HAL_GPIO_WritePin(GPIOA,GPIO_PIN_1,1);
						memset(data_TX, 0, sizeof(data_TX));
						sprintf((char*)data_TX,"%c%c%s",bSTX,'A',data_trans2);
						data_TX[62] = bETX;
						CDC_Transmit_FS(data_TX,sizeof(data_TX));
						}
					else if (uartrecvalue[4] == 0x7B)
						{
						HAL_GPIO_WritePin(GPIOA,GPIO_PIN_1,0);
						memset(data_TX, 0, sizeof(data_TX));
						sprintf((char*)data_TX,"%c%c%s",bSTX,'A',data_trans22);
						data_TX[62] = bETX;
						CDC_Transmit_FS(data_TX,sizeof(data_TX));
						}
					if (uartrecvalue[5] == 0x7A)
						{
						HAL_GPIO_WritePin(GPIOA,GPIO_PIN_2,1);
						memset(data_TX, 0, sizeof(data_TX));
						sprintf((char*)data_TX,"%c%c%s",bSTX,'A',data_trans3);
						data_TX[62] = bETX;
						CDC_Transmit_FS(data_TX,sizeof(data_TX));
						}
					else if (uartrecvalue[5] == 0x7B)
						{
						HAL_GPIO_WritePin(GPIOA,GPIO_PIN_2,0);
						memset(data_TX, 0, sizeof(data_TX));
						sprintf((char*)data_TX,"%c%c%s",bSTX,'A',data_trans33);
						data_TX[62] = bETX;
						CDC_Transmit_FS(data_TX,sizeof(data_TX));
						}
				}
//---------------------------------------------------------------------------------
//----------------------------- MODE: 001 | PWM MOTOR -----------------------------
//---------------------------------------------------------------------------------
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='0'&&uartrecvalue[2]=='1')
				{
					if(uartrecvalue[3]>='0'&&uartrecvalue[3]<='9'
						&&uartrecvalue[4]>='0'&&uartrecvalue[4]<='9'
						&&uartrecvalue[5]>='0'&&uartrecvalue[5]<='9')
					{
						mode_001_flag = 1;
						data_RX[0] = uartrecvalue[3];
						data_RX[1] = uartrecvalue[4];
						data_RX[2] = uartrecvalue[5];
					}
				}
//---------------------------------------------------------------------------------
//------------------------- MODE: 010 | POSITION NONE PID -------------------------
//---------------------------------------------------------------------------------
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='1'&&uartrecvalue[2]=='0')
				{
					mode_010_flag =1;
					data_Poi[0] = uartrecvalue[3];
					data_Poi[1] = uartrecvalue[4];
					data_Poi[2] = uartrecvalue[5];		
					HAL_TIM_Base_Start_IT(&htim4);
					data_counter=0;
					page_counter=0;
				}
//---------------------------------------------------------------------------------
//--------------------------- MODE: 011 | POSITION PID ----------------------------
//---------------------------------------------------------------------------------								
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='1'&&uartrecvalue[2]=='1')
				{
					mode_011_flag = 1;
					uint8_t index=0;
					uint8_t index_buff =0;
					for(uint8_t i=3; i<32;i++)
					{
						if (uartrecvalue[i] == '/' || uartrecvalue[i] == '\0')
						{
								data_PID_buff[index_buff] = '\0';
								data_PID[index] = atof((char*)data_PID_buff);
								index++;
								memset(data_PID_buff, 0, sizeof(data_PID_buff));
								index_buff = 0;
								if (uartrecvalue[i] == '\0') break;
						}
						else
						{
								data_PID_buff[index_buff] = uartrecvalue[i];
								index_buff++;
						}
					}
					if (index < 3 && index_buff > 0)
					{
							data_PID_buff[index_buff] = '\0';
							data_PID[index] = atof((char*)data_PID_buff);
					}
					f_Kp = data_PID[0];
					f_Ki = data_PID[1];
					f_Kd = data_PID[2];
					
					HAL_TIM_Base_Start_IT(&htim4);
					data_counter=0;
					page_counter=0;
				}
				
//---------------------------------------------------------------------------------
//------------------------ MODE: 012 | GET DATA POSITION --------------------------
//---------------------------------------------------------------------------------
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='1'&&uartrecvalue[2]=='2')
				{
					mode_012_flag = 1;
				}
//---------------------------------------------------------------------------------
//--------------------------- MODE: 013 | RESET COUNTER ---------------------------
//---------------------------------------------------------------------------------
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='1'&&uartrecvalue[2]=='3')
				{
					mode_013_flag = 1;
					__HAL_TIM_SET_COUNTER(&htim2,0);
				}
//---------------------------------------------------------------------------------
//---------------------------- MODE: 014 | CALIBRATION ----------------------------
//---------------------------------------------------------------------------------			
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='1'&&uartrecvalue[2]=='4')
				{
					mode_014_flag = 1;		
					if(uartrecvalue[3] == '1')
					{
						zero_calib = 1;
						receive_data[4]=0;
					}
					else if(uartrecvalue[3] == '2')
					{
						span_calib = 1;
						receive_data[4]=0;
					}
				}
//---------------------------------------------------------------------------------
//------------------------------ MODE: 020 | LED RGB ------------------------------
//---------------------------------------------------------------------------------			
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='2'&&uartrecvalue[2]=='0')
				{
					if(uartrecvalue[4]>='0'&&uartrecvalue[4]<='9'
						&&uartrecvalue[5]>='0'&&uartrecvalue[5]<='9'
						&&uartrecvalue[6]>='0'&&uartrecvalue[6]<='9')
					{
						mode_020_flag = 1;
						color_led = uartrecvalue[3];
						data_led[0] = uartrecvalue[4];
						data_led[1] = uartrecvalue[5];
						data_led[2] = uartrecvalue[6];
					}
				}				
//---------------------------------------------------------------------------------
//----------------------------- MODE: 021 | DAC VALUE -----------------------------
//---------------------------------------------------------------------------------			
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='2'&&uartrecvalue[2]=='1')
				{
					mode_021_flag = 1;
					data_DAC[0] = uartrecvalue[4];
					data_DAC[1] = uartrecvalue[5];
					data_DAC[2] = uartrecvalue[6];
					data_DAC[3] = uartrecvalue[7];		
					SRAM_Flag = uartrecvalue[3] - 0x30;
					if(SRAM_Flag == 1)
					{
						for (uint8_t addr = 0; addr < 4; addr++) 
						{
							SRAM_WriteByte(addr, data_DAC[addr]);  
						}	
					}	
				}
//---------------------------------------------------------------------------------
//---------------------------- MODE: 022 | PT100 VALUE ----------------------------
//---------------------------------------------------------------------------------			
				if(uartrecvalue[0]=='0'&&uartrecvalue[1]=='2'&&uartrecvalue[2]=='2')
				{
					if(uartrecvalue[3]=='1')
					{
						mode_022_flag=1;
						HAL_TIM_Base_Start_IT(&htim3);
					}
					else if(uartrecvalue[3]=='2')
					{
						mode_022_flag=0;
						HAL_TIM_Base_Stop_IT(&htim3);

					}
				}
}		

//---------------------------------------------------------------------------------
//---------------------------------- PT100 ADC ------------------------------------
//---------------------------------------------------------------------------------
void PT100_ADC(void)
{
		memset(data_TX, 0, sizeof(data_TX));
		sprintf((char*)data_TX,"%c%c%u",bSTX,'T',PT100_value);
		data_TX[6] = bETX;
		CDC_Transmit_FS(data_TX,7);	
}



//---------------------------------------------------------------------------------
//--------------------------------- SPI: MAX7129 ----------------------------------
//---------------------------------------------------------------------------------
void MAX7219_SendData(uint8_t address, uint8_t data)
{
    spi_buffer[0] = address;  
    spi_buffer[1] = data;     

    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_RESET); 
    HAL_SPI_Transmit(&hspi1, spi_buffer, 2, 1);
    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_SET);  
}


void MAX7219_Cleardata()
{
		for(uint8_t i=0; i<9; i++)
		{
			MAX7219_SendData(i,15);
		}	
}

void MAX7219_Init(void)
{
    MAX7219_SendData(0x09, 0x0F); 
    MAX7219_SendData(0x0A, 0x07); 
    MAX7219_SendData(0x0B, 0x03); 
    MAX7219_SendData(0x0C, 0x01); 
    MAX7219_SendData(0x0F, 0x00); 
		MAX7219_Cleardata();
}


//---------------------------------------------------------------------------------
//-------------------------------- TIMER INTERRUPT --------------------------------
//---------------------------------------------------------------------------------
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
	if(htim == &htim4)
	{	
		if(mode_010_flag || mode_011_flag)
		{
			data_counter++;	
			pulse = __HAL_TIM_GET_COUNTER(&htim2);
			//MAX7219_SendData(4, pulse/1000);
			//MAX7219_SendData(3, (pulse/100)%10);
			//MAX7219_SendData(2, (pulse/10)%10);
			//MAX7219_SendData(1, pulse%10);
			sprintf(data_array, "%04d",pulse);
			if(data_counter <= 150)
			{
				memcpy(&data_motor_write[data_pointer],data_array,4);
				data_pointer+=4;
				if(data_counter % 15 ==0)
				{
					HAL_I2C_Mem_Write(&hi2c1, EEPROM_ADDR, page_counter, 2, data_motor_write, sizeof(data_motor_write), 1000);
					page_counter+=64;
					data_pointer=0;
					page_index++;
					memset(data_motor_write, 0, sizeof(data_motor_write));
				}
			}
		}
		if(mode_011_flag)
		{
			f_Err_Now = calibrated_pulse - f_Mea_Now;
			f_Int = f_Int + (f_Err_Now * f_Del);
			f_Der = (f_Err_Now - f_Err_Pre) / f_Del;
			output = (f_Kp * f_Err_Now) + (f_Ki * f_Int) + (f_Kd * f_Der);
			if (output > 100) output = 100;
			if (output < -100) output = -100;
			f_Err_Pre = f_Err_Now;
			if(output >= 0) Forward_Turning(output*(999/100));
			else if(output < 0) Reverse_Turning(-output*(999/100));
			else Stop_Turning();
		}
	}
	if(htim == &htim3)
	{
		PT100_index ++;
		if(PT100_index == 500)
			{
				PT100_ADC();
				PT100_index = 0;
			}
	}
}
//---------------------------------------------------------------------------------
//------------------------------- SRAM CY6264-70SNC -------------------------------
//---------------------------------------------------------------------------------

void SRAM_GPIO_Init(void)
{
    GPIO_InitTypeDef GPIO_InitStruct = {0};

    // Pin: PA10, PA9, PB13, PB12 (Output)
    __HAL_RCC_GPIOA_CLK_ENABLE();
    __HAL_RCC_GPIOB_CLK_ENABLE();
    __HAL_RCC_GPIOC_CLK_ENABLE();

    // Output configuration
    GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
    GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;

    GPIO_InitStruct.Pin = GPIO_PIN_9 | GPIO_PIN_10;
    HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

    GPIO_InitStruct.Pin = GPIO_PIN_12 | GPIO_PIN_13;
    HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

    // !WE (PB5)
    GPIO_InitStruct.Pin = GPIO_PIN_5;
    HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);
		
		// !WE = 1: Mode Read
    HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_SET);

    // Default value
    SRAM_SetDataAsOutput();
    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_0 | GPIO_PIN_1 | GPIO_PIN_2, GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOB, GPIO_PIN_10 | GPIO_PIN_11, GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOC, GPIO_PIN_13 | GPIO_PIN_14 | GPIO_PIN_15, GPIO_PIN_RESET);
}

void SRAM_SetDataAsOutput(void)
{
    GPIO_InitTypeDef GPIO_InitStruct = {0};

    GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
    GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;

    // PB10, PB11
    GPIO_InitStruct.Pin = GPIO_PIN_10 | GPIO_PIN_11;
    HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

    // PA0, PA1, PA2
    GPIO_InitStruct.Pin = GPIO_PIN_0 | GPIO_PIN_1 | GPIO_PIN_2;
    HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

    // PC13, PC14, PC15
    GPIO_InitStruct.Pin = GPIO_PIN_13 | GPIO_PIN_14 | GPIO_PIN_15;
    HAL_GPIO_Init(GPIOC, &GPIO_InitStruct);
}

void SRAM_SetDataAsInput(void)
{
    GPIO_InitTypeDef GPIO_InitStruct = {0};

    GPIO_InitStruct.Mode = GPIO_MODE_INPUT;
    GPIO_InitStruct.Pull = GPIO_PULLDOWN; //Pull down resistor input

    // PB10, PB11
    GPIO_InitStruct.Pin = GPIO_PIN_10 | GPIO_PIN_11;
    HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

    // PA0, PA1, PA2
    GPIO_InitStruct.Pin = GPIO_PIN_0 | GPIO_PIN_1 | GPIO_PIN_2;
    HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

    // PC13, PC14, PC15
    GPIO_InitStruct.Pin = GPIO_PIN_13 | GPIO_PIN_14 | GPIO_PIN_15;
    HAL_GPIO_Init(GPIOC, &GPIO_InitStruct);
}

void SRAM_SetAddress(uint8_t addr)
{
	  HAL_GPIO_WritePin(GPIOA, GPIO_PIN_10, (addr & 0x01) ? GPIO_PIN_SET : GPIO_PIN_RESET);  // A0
    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_9, (addr & 0x02) ? GPIO_PIN_SET : GPIO_PIN_RESET);   // A1
    HAL_GPIO_WritePin(GPIOB, GPIO_PIN_13, (addr & 0x04) ? GPIO_PIN_SET : GPIO_PIN_RESET);  // A2
	  HAL_GPIO_WritePin(GPIOB, GPIO_PIN_12, (addr & 0x08) ? GPIO_PIN_SET : GPIO_PIN_RESET);  // A3
}

void SRAM_WriteByte(uint8_t addr, uint8_t data)
{
    SRAM_SetAddress(addr);
    SRAM_SetDataAsOutput();
		HAL_Delay(100);

    // Write bits
    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_2, (data & 0x01) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_1, (data & 0x02) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOA, GPIO_PIN_0, (data & 0x04) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOC, GPIO_PIN_15, (data & 0x08) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOC, GPIO_PIN_14, (data & 0x10) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOC, GPIO_PIN_13, (data & 0x20) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOB, GPIO_PIN_10, (data & 0x40) ? GPIO_PIN_SET : GPIO_PIN_RESET);
    HAL_GPIO_WritePin(GPIOB, GPIO_PIN_11, (data & 0x80) ? GPIO_PIN_SET : GPIO_PIN_RESET);


    // Pulse WE low to write data
    HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_RESET);
		HAL_Delay(30);
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_5, GPIO_PIN_SET);

}

uint8_t SRAM_ReadByte(uint8_t addr)
{
    uint8_t data = 0;
    SRAM_SetAddress(addr);
    SRAM_SetDataAsInput();
		HAL_Delay(100);


    data |= HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_2) << 0;
    data |= HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_1) << 1;
    data |= HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_0) << 2;
    data |= HAL_GPIO_ReadPin(GPIOC, GPIO_PIN_15) << 3;
    data |= HAL_GPIO_ReadPin(GPIOC, GPIO_PIN_14) << 4;
    data |= HAL_GPIO_ReadPin(GPIOC, GPIO_PIN_13) << 5;
    data |= HAL_GPIO_ReadPin(GPIOB, GPIO_PIN_10) << 6;
    data |= HAL_GPIO_ReadPin(GPIOB, GPIO_PIN_11) << 7;

    return data;
}


//---------------------------------------------------------------------------------
//------------------------------------ MCP4725 ------------------------------------
//---------------------------------------------------------------------------------
void MCP4725_Write(uint16_t value)
{
	uint8_t data[2];
	data[0] = (value >> 8) & 0x0F ; // 4 Bit trong so cao
	data[1] = value & 0xFF;        	// 8 Bit trong so thap
	HAL_I2C_Master_Transmit(&hi2c1, MCP4725_ADDR, data, 2, 100);
	HAL_Delay(5);
}


void beep(uint16_t level, uint32_t duration_ms) {
    MCP4725_Write(level);
    HAL_Delay(duration_ms);
    MCP4725_Write(0); 
    HAL_Delay(50);    
}


/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
