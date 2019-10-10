using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedTankControl
{
    public partial class Form1 : Form
    {
        string Voltage = "";
        private const int startServo = 30;
        private const int stopServo = 125;
        private const int PORT1 = 81;
        private const int PORT2 = 80;
        private byte[] data=new byte[38400];
        private string cmd;
        private string cmdCAM;
        Socket server=null;
        IPEndPoint ipep=null;
        Socket serverCAM = null;
        IPEndPoint ipepCAM = null;
        private double FPS = 2;
        private bool VGA = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            textBox_FPS.Text = FPS.ToString();
            
            button_Connect.Tag = textBox1;
            button_Connect1.Tag = textBox2;
            button_Connect1.Click += button_Connect_Click;
            //two letter code
            button_LF.Tag = "LF";
            button_LS.Tag = "LS";
            button_LR.Tag = "LR";
            button_RF.Tag = "RF";
            button_RS.Tag = "RS";
            button_RR.Tag = "RR";
            button_ledOn.Tag = "LY";
            button_LedOff.Tag = "LN";
            trackBar_S1.Tag = "S1";
            trackBar_S2.Tag = "S2";
            trackBar_S3.Tag = "S3";
            button_cameraON.Tag = "CY";
            button_cameraOFF.Tag = "CN";
            button_ESP32_CAM_On.Tag = "EY";
            button_ESP32_CAM_Off.Tag = "EN";
            button_VGA_High.Tag = "QH";
            button_VGA_Low.Tag = "QL";
            button_speed_1.Tag = "V1";
            button_speed_2.Tag = "V2";
            button_speed_3.Tag = "V3";
            button_speed_4.Tag = "V4";
            button_S1Low.Tag = trackBar_S1;
            button_S2Low.Tag = trackBar_S2;
            button_S3Low.Tag = trackBar_S3;
            button_S1High.Tag = trackBar_S1;
            button_S2High.Tag = trackBar_S2;
            button_S3High.Tag = trackBar_S3;
            //add event
            button_LF.Click += Button_SendMessage;
            button_LS.Click += Button_SendMessage;
            button_LR.Click += Button_SendMessage;
            button_RF.Click += Button_SendMessage;
            button_RS.Click += Button_SendMessage;
            button_RR.Click += Button_SendMessage;
            button_ledOn.Click += Button_SendMessage;
            button_LedOff.Click += Button_SendMessage;
            button_cameraON.Click += Button_SendMessage;
            button_cameraOFF.Click += Button_SendMessage;
            button_ESP32_CAM_On.Click += Button_SendMessage;
            button_ESP32_CAM_Off.Click += Button_SendMessage;
            button_VGA_High.Click += Button_VGA_SendMessage;
            button_VGA_Low.Click += Button_VGA_SendMessage;
            button_speed_1.Click += Button_SendMessage;
            button_speed_2.Click += Button_SendMessage;
            button_speed_3.Click += Button_SendMessage;
            button_speed_4.Click += Button_SendMessage;

            trackBar_S1.ValueChanged += TrackBar_SendMessage;
            trackBar_S2.ValueChanged += TrackBar_SendMessage;
            trackBar_S3.ValueChanged += TrackBar_SendMessage;
            button_S1Low.Click += ButtonSLow_SendMessage;
            button_S2Low.Click += ButtonSLow_SendMessage;
            button_S3Low.Click += ButtonSLow_SendMessage;
            button_S1High.Click += ButtonSHigh_SendMessage;
            button_S2High.Click += ButtonSHigh_SendMessage;
            button_S3High.Click += ButtonSHigh_SendMessage;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyPress;
            this.Resize += Form1_Resize;
        }
        private void Form1_Resize(object sender,EventArgs e)
        {
            int bmpW = 160;
            int bmpH = 120;
            int w = panel2.Width;
            int h = panel2.Height;
            int rescaleW = w / bmpW;
            int rescaleH = h/ bmpH;
            int rescale = 1;

            if (rescaleW < rescaleH)
            {
                rescale = rescaleW;
            }
            else
            {
                rescale = rescaleH;
            }

            pictureBox1.Size = new Size(rescale * bmpW, rescale * bmpH);
            pictureBox1.Location = new Point(w/2-pictureBox1.Size.Width/2, h / 2 - pictureBox1.Size.Height / 2);
        }
        void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            if (!textBox1.Focused && !textBox_FPS.Focused)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad7:
                        button_LF.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.NumPad4:
                        button_LS.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.NumPad1:
                        button_LR.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.NumPad8:
                        button_RF.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.NumPad5:
                        button_RS.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.NumPad2:
                        button_RR.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D1:
                        button_S1Low.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D2:
                        button_S1High.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D3:
                        button_S2Low.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D4:
                        button_S2High.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D5:
                        button_S3Low.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D6:
                        button_S3High.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.Oemplus:
                        button_ledOn.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.OemMinus:
                        button_LedOff.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.F1:
                        button_speed_1.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.F2:
                        button_speed_2.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.F3:
                        button_speed_3.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.F4:
                        button_speed_4.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.W:
                        button_RF.PerformClick();
                        Thread.Sleep(100);
                        button_LF.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.S:
                        button_RR.PerformClick();
                        Thread.Sleep(100);
                        button_LR.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.Space:
                        button_RS.PerformClick();
                        Thread.Sleep(100);
                        button_LS.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.A:
                        button_RF.PerformClick();
                        Thread.Sleep(100);
                        button_LR.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.D:
                        button_RR.PerformClick();
                        Thread.Sleep(100);
                        button_LF.PerformClick();
                        e.Handled = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Button_SendMessage(object sender, EventArgs e)
        {
            if (server == null) return;

            Button btn = (Button)sender;

            if(btn.Enabled)
                this.cmd = (string)btn.Tag;
        }
        private void Button_VGA_SendMessage(object sender, EventArgs e)
        {
            if (server == null) return;

            Button btn = (Button)sender;

            string str = (string)btn.Tag;

            if (str == "QH")
            {
                FPS = 2;
                textBox_FPS.Text = FPS.ToString();
                VGA = true;
            }
            else if (str == "QL")
                VGA = false;

            if (btn.Enabled)
                this.cmd = str;

           
        }
        private void ButtonSLow_SendMessage(object sender, EventArgs e)
        {
            if (server == null) return;

            TrackBar tb = (TrackBar)((Button)sender).Tag;

            if (tb.Enabled && tb.Value>tb.Minimum)
            {
                tb.Value -= 1;
            }
        }
        private void ButtonSHigh_SendMessage(object sender, EventArgs e)
        {
            if (server == null) return;

            TrackBar tb = (TrackBar)((Button)sender).Tag;

            if (tb.Enabled && tb.Value < tb.Maximum)
            {
                tb.Value += 1;
            }
        }
        private void TrackBar_SendMessage(object sender, EventArgs e)
        {
            if (server == null) return;

            TrackBar tb = (TrackBar)sender;

            if (tb.Enabled)
                this.cmd = (string)tb.Tag + tb.Value.ToString();
        }
        private void button_Connect_Click(object sender, EventArgs e)
        {            
            //take the new ip
            string IP =( (TextBox)((Button)sender).Tag).Text;
            
            IPEndPoint ipepNew = null;
            //check the ip
            try
            {
                if ((Button)sender == button_Connect)
                    ipepNew = new IPEndPoint(IPAddress.Parse(IP), PORT1);
                else
                    ipepNew = new IPEndPoint(IPAddress.Parse(IP), PORT2);
            }
            catch
            {
                MessageBox.Show("IP address is not correct!");
                return;
            }
            //reset servo positions and LED_On/Off
            ServoPosition_Reset(trackBar_S1,stopServo);
            ServoPosition_Reset(trackBar_S2);
            ServoPosition_Reset(trackBar_S3);
            button_ledOn.Enabled = true;
            button_LedOff.Enabled = true;
            Form1_Resize(this, new EventArgs());
            pictureBox1.Visible = true;
            //start server
            if((Button)sender == button_Connect)
                NetworkClient_Start(ipepNew);
            else
                NetworkClient_Start1(ipepNew);
        }
        private void ServoPosition_Reset(TrackBar tb,int position = startServo)
        {
            tb.Enabled = false;
            tb.Minimum = startServo;
            tb.Maximum = stopServo;
            tb.Value = position;
            tb.Enabled = true;
        }
        private void NetworkClient_Start(IPEndPoint ipepNew)
        {
            if (ipepNew == null) return;

            Socket serverNew = new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
               serverNew.Connect(ipepNew);                
            }
            catch //(SocketException e)
            {
                MessageBox.Show("Unable to connect to server.");
                return;
            }
            //check is this the main ESP
            /*
            serverNew.Send(Encoding.ASCII.GetBytes("ID"));

            byte[] newData = new byte[1280];

            int recv = serverNew.Receive(newData);
            string str = Encoding.ASCII.GetString(newData);
            MessageBox.Show(str);*/
            var bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            string str = "A";
            if (str == "A")//Main
            {
                this.server = serverNew;
                this.ipep = ipepNew;
                bgw.DoWork += bgw_MainDoWork;
            }
            else if (str == "B")//Camera
            {
                this.serverCAM = serverNew;
                this.ipepCAM = ipepNew;
                pictureBox1.Visible = true;                
                bgw.DoWork += bgw_doWork;
            }

            bgw.ProgressChanged += bgw_ProgressChanged;

            bgw.RunWorkerAsync();
        }
        private void NetworkClient_Start1(IPEndPoint ipepNew)
        {
            if (ipepNew == null) return;

            Socket serverNew = new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverNew.Connect(ipepNew);
            }
            catch 
            {
                MessageBox.Show("Unable to connect to server.");
                return;
            }
            //check is this the main ESP
            /*
            serverNew.Send(Encoding.ASCII.GetBytes("ID"));

            byte[] newData = new byte[1280];

            int recv = serverNew.Receive(newData);
            string str = Encoding.ASCII.GetString(newData);
            MessageBox.Show(str);*/
            var bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            string str = "B";
            if (str == "A")//Main
            {
                this.server = serverNew;
                this.ipep = ipepNew;
                bgw.DoWork += bgw_MainDoWork;
            }
            else if (str == "B")//Camera
            {
                this.serverCAM = serverNew;
                this.ipepCAM = ipepNew;
                pictureBox1.Visible = true;
                bgw.DoWork += bgw_doWork;
            }

            bgw.ProgressChanged += bgw_ProgressChanged;

            bgw.RunWorkerAsync();
        }
        #region Camera ESP
        private void bgw_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                Image flipImage = BMPProcessor.GetBmp(data, pictureBox1.Size,this.VGA);
                flipImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox1.Image = flipImage;

                Application.DoEvents();
            }
            else if (e.ProgressPercentage == 1)
            {
                MessageBox.Show("Disconnected from camera server!");
            }
            else if (e.ProgressPercentage == 2)
            {
                MessageBox.Show("Disconnected from main server!");
            }
            else if (e.ProgressPercentage == 3)
            {
                if (Voltage == "")
                {
                    VoltageESP_label.Text = "ESP battery: --- V";
                    VoltageMotor_label.Text = "Engine battery: --- V";
                }
                else
                {
                    string[] vals = Voltage.Split(new string[] { "|" }, StringSplitOptions.None);

                    if (vals.Length != 3) return;

                    VoltageESP_label.Text = "ESP battery: " + vals[2] + " V";
                    VoltageMotor_label.Text = "Engine battery: " + vals[1] + " V";
                }
            }
        }
        private void bgw_doWork(Object sender, DoWorkEventArgs e)
        {
            int recv;
            
            try
            {
                while (true)
                {
                    if (this.cmdCAM == "exit")
                    {
                        this.cmdCAM = "";
                        break;
                    }
                    
                    if (!this.serverCAM.Connected) serverCAM.Connect(ipepCAM);

                    this.serverCAM.Send(Encoding.ASCII.GetBytes(this.cmdCAM + ";"));
                    this.cmdCAM = "";
                    byte[] newData = null;
                    if(VGA)
                        newData = new byte[38400];
                    else
                        newData = new byte[9600];

                    recv = serverCAM.Receive(newData);

                    Thread.Sleep((int)(1000 / FPS));
                    this.data = newData;
                    ((BackgroundWorker)sender).ReportProgress(0);
                }
            }
            catch { }

            if (serverCAM != null)
            {
                try
                {
                    serverCAM.Shutdown(SocketShutdown.Both);
                    serverCAM.Close();
                    serverCAM = null;
                }
                catch { }
                ((BackgroundWorker)sender).ReportProgress(1);
            }

        }
        #endregion Camera ESP

        #region Main ESP
        private void bgw_MainDoWork(Object sender, DoWorkEventArgs e)
        {
            int recv;

            try
            {
                while (true)
                {
                    if (cmd == "exit")
                    {
                        cmd = "";
                        break;
                    }

                    if(!this.server.Connected) server.Connect(ipep);

                    this.server.Send(Encoding.ASCII.GetBytes(cmd + ";"));
                    cmd = "";

                    byte[] newData = new byte[38400];
                                        
                    recv = server.Receive(newData);
                    this.Voltage = Encoding.ASCII.GetString(newData);
                    ((BackgroundWorker)sender).ReportProgress(3);
                    Thread.Sleep(50);                   
                }
            }
            catch { }

            if (server != null)
            {
                try
                {
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    server = null;
                }
                catch { }
                ((BackgroundWorker)sender).ReportProgress(2);
            }
            
        }
        #endregion Main ESP
        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (server == null) return;
            this.cmd = "exit";
            this.cmdCAM = "exit";

            pictureBox1.Visible = false;
        }

        private void button_FPS_Click(object sender, EventArgs e)
        {
            double newFPS = 0;

            if (double.TryParse(textBox_FPS.Text, out newFPS))
                this.FPS = newFPS;
            else
                MessageBox.Show("Incorrect value!");

        }

        private void button_infoSpeed_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Join("\n",new string[]{"Speed 1 = 50%",
                "Speed 2 = 55%",
                "Speed 3 = 65%",
                "Speed 4 = 80%" }));
        }
    }
}
