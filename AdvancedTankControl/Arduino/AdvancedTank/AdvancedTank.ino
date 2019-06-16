//Libraries
#include "OV7670.h"//Camera class
#include <Adafruit_GFX.h>    // Core graphics library
#include "BMP.h"//Bitmap class
#include <WiFi.h>
#include <WiFiMulti.h>
#include <WiFiClient.h>

//WI-Fi settings
#define ssid1        "network name" //ssid
#define password1    "password" //password

#define ssid2        "network name" //ssid
#define password2    "password" //password

#define ssid3        "network name" //ssid
#define password3    "password" //password

//define camera pins

const int SIOD = 21; //SDA
const int SIOC = 22; //SCL

const int VSYNC = 34;
const int HREF = 35;

const int XCLK = 32;
const int PCLK = 33;

const int D0 = 39;
const int D1 = 17;
const int D2 = 16;
const int D3 = 15;
const int D4 = 14;
const int D5 = 36;
const int D6 = 12;
const int D7 = 4;

//define H-brige pins
const int M1Forward=25;
const int M1Reverse=26;
const int M2Forward=27;
const int M2Reverse=13;

//define PWN servo pins
const int Servo1=18;
const int Servo2=19;
const int Servo3=23;

//define LED pin
const int LED = 2;

//Set camera
OV7670 *camera;

//set server
WiFiMulti wifiMulti;
WiFiServer server(80);
byte mac[6];

//BitMap header
unsigned char bmpHeader[BMP::headerSize];

// setting PWM properties
const int Servo1Channel = 10;
const int Servo2Channel = 11;
const int Servo3Channel = 12;
const int ServoMin = 30;
const int ServoMax = 125;
const int freq = 50;//50 Hz
const int resolution = 10; //Resolution 8, 10, 12, 15

void setup() {
  //set serial monitor settings
  Serial.begin(115200);
  //Get info
  Serial.println("Name: Advanced Tank");
  Serial.println("Program Start...");
  
  //set the pins to propper mode
  Serial.println("Configurating pins...");
  pinMode (M1Forward, OUTPUT);
  pinMode (M1Reverse, OUTPUT);
  pinMode (M2Forward, OUTPUT);
  pinMode (M2Reverse, OUTPUT);
  pinMode(LED,OUTPUT);
  pinMode(Servo1, OUTPUT);
  pinMode(Servo2, OUTPUT);
  pinMode(Servo3, OUTPUT);

  //configure LED PWM functionalitites
  ledcSetup(Servo1Channel, freq, resolution);
  ledcSetup(Servo2Channel, freq, resolution);
  ledcSetup(Servo3Channel, freq, resolution);

  // attach the PWN channel to the GPIO Servo pins to be controlled
  ledcAttachPin(Servo1, Servo1Channel);
  ledcAttachPin(Servo2, Servo2Channel);
  ledcAttachPin(Servo3, Servo3Channel);
 
  //reset pins
  ResetMyPins();
  digitalWrite(LED,LOW);
  //reset the servo position
  Serial.println("Reset the servo position...");
  ledcWrite(Servo1Channel, ServoMin);
  delay(2000);//delay for hardware movement
  ledcWrite(Servo2Channel, ServoMin);
  delay(2000);//delay for hardware movement
  ledcWrite(Servo3Channel, ServoMin); 
  //set Wi-Fi settings and try to connect  
  Serial.println("Connecting Wifi...");
  wifiMulti.addAP(ssid1, password1);
  wifiMulti.addAP(ssid2, password2);
  wifiMulti.addAP(ssid3, password3);

  //Loop until the connection to wifi is established
  while(wifiMulti.run() != WL_CONNECTED) {
       delay(5000);        
       Serial.print(".");
    }
    
  if(wifiMulti.run() == WL_CONNECTED) {
      Serial.println("");
      Serial.println("");
      Serial.println("WiFi connected");
      //print the network name
      Serial.println("Network name: ");
      Serial.println(WiFi.SSID());
      //print IP address
      Serial.println("IP address: ");
      Serial.println(WiFi.localIP());
      //print MAC address      
      WiFi.macAddress(mac);
      Serial.println("MAC address: "); 
      Serial.print(mac[0],HEX);
      Serial.print(":");
      Serial.print(mac[1],HEX);
      Serial.print(":");
      Serial.print(mac[2],HEX);
      Serial.print(":");
      Serial.print(mac[3],HEX);
      Serial.print(":");
      Serial.print(mac[4],HEX);
      Serial.print(":");
      Serial.println(mac[5],HEX);
  }

  //Start the camera with QQVGA_RGB565 quality
  camera = new OV7670(OV7670::Mode::QQVGA_RGB565, SIOD, SIOC, VSYNC, HREF, XCLK, PCLK, D0, D1, D2, D3, D4, D5, D6, D7);

  //create bitmap header
  BMP::construct16BitHeader(bmpHeader, camera->xres, camera->yres);
  
  //start the server
  server.begin();
  //start the LED
  digitalWrite(LED, HIGH);
  //report successful initialization
  Serial.println("Ready!");
  Serial.println("---------------------------");
}

void loop() { 
  
   
  //check for incomming information and send the image
  serve();
}

void serve()
{
  WiFiClient client = server.available();
  bool b = true;
  if (client) 
  {
    Serial.println("New Client.");
    String currentLine = "";
    while (client.connected()) 
    {
      if (client.available()) 
      {
        char c = client.read();
        
        if (c == ';')
        {          
          if(currentLine != "")
          {
            ReadMyComand(currentLine);
            currentLine = "";
          }   
           
          // Send the image
          camera->oneFrame();
          delay(20);
          client.write(camera->frame, camera->xres * camera->yres * 2);
                            
        }
        else
        {
          currentLine += c;
        }       
      }
    }
    //reset pins
     ResetMyPins();
    // close the connection:
    client.stop();
    Serial.println("Client Disconnected.");
  }
} 
  void ResetMyPins()
  {
  Serial.println("Setting pin value...");
  digitalWrite (M1Forward,  LOW);
  digitalWrite(M1Reverse, LOW);
  digitalWrite (M2Forward, LOW);
  digitalWrite (M2Reverse, LOW);

  }
  void ReadMyComand(String cmd1)
  { 
    String val = cmd1.substring(0,2);
    int servo = ServoMin;
    
    if(cmd1.length()>2)
    {
      servo = cmd1.substring(2).toInt();
      Serial.println(val+ "->" + String(servo));
    }
    else
    {
      Serial.println(val);
    }
     
    if(val == "LF"){
        digitalWrite (M1Reverse, LOW);
        delay(20);   
        digitalWrite (M1Forward, HIGH);
   }
    else if(val == "LS"){
        digitalWrite (M1Reverse, LOW);  
        digitalWrite (M1Forward, LOW);
    }
     else if(val == "LR"){
        digitalWrite (M1Forward, LOW);
        delay(20);   
        digitalWrite (M1Reverse, HIGH);
      }  
      else if(val =="RF"){
        digitalWrite (M2Reverse, LOW);
        delay(20);   
        digitalWrite (M2Forward, HIGH);
       } 
     else if(val == "RS"){
        digitalWrite (M2Reverse, LOW);  
        digitalWrite (M2Forward, LOW);
       } 
      else if(val =="RR"){
        digitalWrite (M2Forward, LOW);
        delay(20);   
        digitalWrite (M2Reverse, HIGH);
      }  
     else if(val =="LY"){
        digitalWrite (LED, HIGH);
       } 
      else if(val =="LN"){
        digitalWrite (LED, LOW);
       } 
      else if(val == "S1"){
        ledcWrite(Servo1Channel, servo);
       }  
     else if(val == "S2"){
        ledcWrite(Servo2Channel, servo);
       } 
      else if(val == "S3"){
        ledcWrite(Servo3Channel, servo);
      }
    
  }
