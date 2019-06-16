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
        private const int startServo = 30;
        private const int stopServo = 125;
        private const int PORT = 80;
        private byte[] data=new byte[38400];
        private string cmd;
        Socket server=null;
        IPEndPoint ipep=null;
        private double FPS = 5;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            textBox_FPS.Text = FPS.ToString();
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
            if (!textBox1.Focused)
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
            string IP = textBox1.Text;
            //check the ip
            try
            {
                ipep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            }
            catch
            {
                MessageBox.Show("IP address is not correct!");
                return;
            }
            //reset servo positions and LED_On/Off
            ServoPosition_Reset(trackBar_S1);
            ServoPosition_Reset(trackBar_S2);
            ServoPosition_Reset(trackBar_S3);
            button_ledOn.Enabled = true;
            button_LedOff.Enabled = true;
            Form1_Resize(this, new EventArgs());
            pictureBox1.Visible = true;
            //start server
            NetworkClient_Start();
        }
        private void ServoPosition_Reset(TrackBar tb)
        {
            tb.Enabled = false;
            tb.Minimum = startServo;
            tb.Maximum = stopServo;
            tb.Value = startServo;
            tb.Enabled = true;
        }
        private void NetworkClient_Start()
        {
            if (ipep == null) return;

            this.server = new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                MessageBox.Show("Unable to connect to server.");
                return;
            }

            pictureBox1.Visible = true;

            var bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += bgw_doWork;
            bgw.ProgressChanged += bgw_ProgressChanged;

            bgw.RunWorkerAsync();
        }
        private void bgw_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                pictureBox1.Image = BMPProcessor.GetBmp(data, pictureBox1.Size);
                
                Application.DoEvents();
            }
            else if (e.ProgressPercentage == 1)
            {
                MessageBox.Show("Disconnected from server!");
            }
        }
        private void bgw_doWork(Object sender, DoWorkEventArgs e)
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
                    this.data = new byte[38400];
                    
                    recv = server.Receive(this.data);
                    ((BackgroundWorker)sender).ReportProgress(0);

                    Thread.Sleep((int)(1000/FPS));
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
                ((BackgroundWorker)sender).ReportProgress(1);
            }
            
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (server == null) return;
            this.cmd = "exit";
            
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
    }
}
