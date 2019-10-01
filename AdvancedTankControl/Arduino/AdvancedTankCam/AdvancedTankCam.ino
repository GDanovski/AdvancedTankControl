//Libraries
#include "OV7670.h"//Camera class
#include <Adafruit_GFX.h>    // Core graphics library
#include "BMP.h"//Bitmap class
#include <WiFi.h>
#include <WiFiMulti.h>
#include <WiFiClient.h>

//WI-Fi settings
#define ssid1        "" //ssid
#define password1    "" //password

#define ssid2        "" //ssid
#define password2    "" //password

#define ssid3        "" //ssid
#define password3    "" //password

//define camera pins
const int onPin = 27;//send frame if HIGH
const int VGA = 19;//If High - QQVGA else - QQQVGA
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

void setup() {
  //set serial monitor settings
  Serial.begin(115200);
  //Get info
  Serial.println("Name: Advanced Tank");
  Serial.println("Program Start...");
  
  //set the pins to propper mode
  Serial.println("Configurating pins...");
  
  pinMode(LED,OUTPUT);
  digitalWrite(LED,LOW);
  pinMode(onPin, INPUT); 
  pinMode(VGA, INPUT); 
  
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
  //Start the camera
 if(digitalRead(VGA) == HIGH)//Start the camera with QQVGA_RGB565 quality
 {
   camera = new OV7670(OV7670::Mode::QQVGA_RGB565, SIOD, SIOC, VSYNC, HREF, XCLK, PCLK, D0, D1, D2, D3, D4, D5, D6, D7);
 }
 else //Start the camera with QQQVGA_RGB565 quality
 {
   camera = new OV7670(OV7670::Mode::QQQVGA_RGB565, SIOD, SIOC, VSYNC, HREF, XCLK, PCLK, D0, D1, D2, D3, D4, D5, D6, D7);
 }
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
  if(digitalRead(onPin) == HIGH)
  {
    camera->oneFrame();
  }
  serve();
}

void serve()
{
  WiFiClient client = server.available();
  
  if (client) 
  {
    Serial.println("New Client.");
    String currentLine = "";
    while (client.connected()) 
    {
      if (client.available()) 
      {
        char c = client.read();
        if (c == '\n') 
        {
          if (currentLine.length() == 0) 
          {
            client.println("HTTP/1.1 200 OK");
            client.println("Content-type:text/html");
            client.println();
            // filter:FlipH
            client.print(
              "<style>body{margin: 0}\nimg{height: 100%; width: auto;}</style>"
              "<img id='a' src='/camera' onload='this.style.display=\"initial\"; var b = document.getElementById(\"b\"); b.style.display=\"none\"; b.src=\"camera?\"+Date.now(); '>"
              "<img id='b' style='display: none' src='/camera' onload='this.style.display=\"initial\"; var a = document.getElementById(\"a\"); a.style.display=\"none\"; a.src=\"camera?\"+Date.now(); '>");
            client.println();
            break;
          } 
          else 
          {
            currentLine = "";
          }
        } 
        else if (c != '\r') 
        {
          currentLine += c;
        }
        if(digitalRead(onPin) == HIGH){
          if(currentLine.endsWith("GET /camera") )
          {
            client.println("HTTP/1.1 200 OK");
            client.println("Content-type:image/bmp");
            client.println();
            
            client.write(bmpHeader, BMP::headerSize);
            client.write(camera->frame, camera->xres * camera->yres * 2);
          }
        }   
      }
    }
     
    // close the connection:
    client.stop();
    Serial.println("Client Disconnected.");
  }
} 
