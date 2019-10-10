//Libraries
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
bool cameraON = true;//change to true to activate the cammera
const int camPin=4;//up to start transmiting images
const int powPin=32;//up to turn on the ESP32-CAM
const int VGA = 13;//If High - QQVGA, else - QQQVGA
//define H-brige pins
const int M1Forward=33;
const int M1Reverse=25;
const int M2Forward=26;
const int M2Reverse=27;

//define PWN servo pins
const int Servo1=18;
const int Servo2=19;
const int Servo3=23;

//define LED pin
const int LED = 2;

//set server
WiFiMulti wifiMulti;
WiFiServer server(81);
byte mac[6];
String voltageValue = "vm|0|0";

// setting PWM properties
const int M1ForwardChannel=1;
const int M1ReverseChannel=2;
const int M2ForwardChannel=3;
const int M2ReverseChannel=4;
int MSpeed = 550;

const int Servo1Channel = 10;
const int Servo2Channel = 11;
const int Servo3Channel = 12;

const int ServoMin = 30;
const int ServoMax = 125;
const int freq = 50;//50 Hz
const int freqM = 5000;//5000 Hz
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
  pinMode (camPin, OUTPUT);
  pinMode (powPin, OUTPUT);
  pinMode (VGA, OUTPUT);

  //configurate the camera pin
  digitalWrite (camPin, LOW); // turn off the pin
  digitalWrite (powPin, LOW); // turn off the pin
  digitalWrite (VGA, LOW); // turn off the pin
  
  //configure LED PWM functionalitites
  ledcSetup(Servo1Channel, freq, resolution);
  ledcSetup(Servo2Channel, freq, resolution);
  ledcSetup(Servo3Channel, freq, resolution);

  ledcSetup(M1ForwardChannel, freqM, resolution);
  ledcSetup(M1ReverseChannel, freqM, resolution);
  ledcSetup(M2ForwardChannel, freqM, resolution);
  ledcSetup(M2ReverseChannel, freqM, resolution);

  // attach the PWN channel to the GPIO Servo pins to be controlled
  ledcAttachPin(Servo1, Servo1Channel);
  ledcAttachPin(Servo2, Servo2Channel);
  ledcAttachPin(Servo3, Servo3Channel);

  ledcAttachPin(M1Forward, M1ForwardChannel);
  ledcAttachPin(M1Reverse, M1ReverseChannel);
  ledcAttachPin(M2Forward, M2ForwardChannel);
  ledcAttachPin(M2Reverse, M2ReverseChannel);
  //reset pins
  ResetMyPins();
  digitalWrite(LED,LOW);
  //reset the servo position
  Serial.println("Reset the servo position...");
  ledcWrite(Servo1Channel, ServoMax);
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
  int counter = 0;  
  bool b = true;
  if (client) 
  {
    Serial.println("New Client.");
    digitalWrite (powPin, LOW); // turn off the pin
    String currentLine = "";
    ACPVoltageDetect();
    while (client.connected()) 
    {
      if (client.available()) 
      {
        char c = client.read();
        
        if (c == ';')
        {  
          if(currentLine == "ID")
          {
             currentLine = ""; 
             delay(20);              
             client.println("A"); 
          }
          else
          {        
            if(currentLine != "")
            {
              ReadMyComand(currentLine);
              currentLine = "";
            }                       
            delay(20);
            
            counter++;
            if(counter >= 500)
             {
                ACPVoltageDetect();
                counter = 0;
             }
            
            client.println(voltageValue);              
          }
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
  ledcWrite(M1ForwardChannel, 0);
  ledcWrite(M1ReverseChannel, 0);
  ledcWrite(M2ForwardChannel, 0);
  ledcWrite(M2ReverseChannel, 0);
  digitalWrite (powPin, LOW); // turn off the pin
  digitalWrite (camPin, LOW); // turn off the pin
  MSpeed = 500;
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
        ledcWrite(M1ReverseChannel, 0);
        delay(20);   
        ledcWrite(M1ForwardChannel, MSpeed);
   }
    else if(val == "LS"){
        ledcWrite(M1ForwardChannel, 0);
        ledcWrite(M1ReverseChannel, 0);
    }
     else if(val == "LR"){
        ledcWrite(M1ForwardChannel, 0);
        delay(20);   
        ledcWrite(M1ReverseChannel, MSpeed);
      }  
      else if(val =="RF"){
        ledcWrite(M2ReverseChannel, 0);
        delay(20);   
        ledcWrite(M2ForwardChannel, MSpeed);
       } 
     else if(val == "RS"){
        ledcWrite(M2ForwardChannel, 0);
        ledcWrite(M2ReverseChannel, 0);
       } 
      else if(val =="RR"){
        ledcWrite(M2ForwardChannel, 0);
        delay(20);   
        ledcWrite(M2ReverseChannel, MSpeed);
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
      else if(val == "CY"){
        cameraON = true;
        digitalWrite (camPin, HIGH); // turn off the pin
      }
       else if(val == "CN"){
        cameraON = false;
        digitalWrite (camPin, LOW); // turn off the pin
      }
       else if(val == "EY"){
        digitalWrite (powPin, HIGH); // turn on the pin
      }
      else if(val == "EN"){
        digitalWrite (powPin, LOW); // turn off the pin
      }
      else if(val == "QH")
      {
        digitalWrite (VGA, HIGH); // turn on the pin
      }
      else if(val == "QL")
      {
        digitalWrite (VGA, LOW); // turn off the pin
      }
       else if(val == "V1"){
        MSpeed = 500;
      }
       else if(val == "V2"){
        MSpeed = 550;
      }
       else if(val == "V3"){
        MSpeed = 650;
      }
       else if(val == "V4"){
        MSpeed = 800;
      }
  }
  void ACPVoltageDetect(){
    
   // take a number of analog samples and add them up
   float sum1 = 0;
   float sum2 = 0;
   int counterVoltageMater = 0;
   unsigned char sample_count = 0; // current sample number
   int NUM_SAMPLES = 10;
   
    while (sample_count < NUM_SAMPLES) {         
        sum1 += analogRead(A6);//p34
        sum2 += analogRead(A7);//p34
        sample_count++;
        delay(10);
    }
    // calculate the voltage
    // use 3.3 for a 5.0V ADC reference voltage
    // 3.8 V is the calibrated reference voltage
    float voltage1 = ((float)sum1 / (float)NUM_SAMPLES * 3.3) / 4096.0;
    float voltage2 = ((float)sum2 / (float)NUM_SAMPLES * 3.3) / 4096.0;
    // send voltage for display on Serial Monitor
    // voltage multiplied by 2 when using voltage divider that
    // divides by 2. 
    // value
     voltage1 = voltage1*2;
     voltage2 = voltage2*2;
     
     String stringThree = String("vm|");
     stringThree = stringThree + voltage1 + "|"+ voltage2;
     voltageValue = stringThree;
     Serial.println(voltageValue);    
  }
