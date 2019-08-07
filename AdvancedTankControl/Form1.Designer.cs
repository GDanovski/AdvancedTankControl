namespace AdvancedTankControl
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_FPS = new System.Windows.Forms.Button();
            this.textBox_FPS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.trackBar_S3 = new System.Windows.Forms.TrackBar();
            this.trackBar_S2 = new System.Windows.Forms.TrackBar();
            this.trackBar_S1 = new System.Windows.Forms.TrackBar();
            this.button_S3High = new System.Windows.Forms.Button();
            this.button_S3Low = new System.Windows.Forms.Button();
            this.button_S2High = new System.Windows.Forms.Button();
            this.button_S2Low = new System.Windows.Forms.Button();
            this.button_S1High = new System.Windows.Forms.Button();
            this.button_S1Low = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_LedOff = new System.Windows.Forms.Button();
            this.button_ledOn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_RR = new System.Windows.Forms.Button();
            this.button_RS = new System.Windows.Forms.Button();
            this.button_RF = new System.Windows.Forms.Button();
            this.button_LR = new System.Windows.Forms.Button();
            this.button_LS = new System.Windows.Forms.Button();
            this.button_LF = new System.Windows.Forms.Button();
            this.button_cameraON = new System.Windows.Forms.Button();
            this.button_cameraOFF = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_S3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_S2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_S1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button_cameraOFF);
            this.panel1.Controls.Add(this.button_cameraON);
            this.panel1.Controls.Add(this.button_FPS);
            this.panel1.Controls.Add(this.textBox_FPS);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button_Disconnect);
            this.panel1.Controls.Add(this.button_Connect);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 30);
            this.panel1.TabIndex = 0;
            // 
            // button_FPS
            // 
            this.button_FPS.Location = new System.Drawing.Point(524, 2);
            this.button_FPS.Name = "button_FPS";
            this.button_FPS.Size = new System.Drawing.Size(58, 23);
            this.button_FPS.TabIndex = 6;
            this.button_FPS.Text = "Apply";
            this.button_FPS.UseVisualStyleBackColor = true;
            this.button_FPS.Click += new System.EventHandler(this.button_FPS_Click);
            // 
            // textBox_FPS
            // 
            this.textBox_FPS.Location = new System.Drawing.Point(467, 4);
            this.textBox_FPS.Name = "textBox_FPS";
            this.textBox_FPS.Size = new System.Drawing.Size(51, 20);
            this.textBox_FPS.TabIndex = 5;
            this.textBox_FPS.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(430, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "FPS:";
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(307, 4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_Disconnect.TabIndex = 3;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(226, 4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 2;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "192.168.0.104";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 270);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(195, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 158);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 200);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(312, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(741, 200);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.DimGray;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.trackBar_S3);
            this.panel6.Controls.Add(this.trackBar_S2);
            this.panel6.Controls.Add(this.trackBar_S1);
            this.panel6.Controls.Add(this.button_S3High);
            this.panel6.Controls.Add(this.button_S3Low);
            this.panel6.Controls.Add(this.button_S2High);
            this.panel6.Controls.Add(this.button_S2Low);
            this.panel6.Controls.Add(this.button_S1High);
            this.panel6.Controls.Add(this.button_S1Low);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.button_LedOff);
            this.panel6.Controls.Add(this.button_ledOn);
            this.panel6.Location = new System.Drawing.Point(25, 13);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(704, 173);
            this.panel6.TabIndex = 3;
            // 
            // trackBar_S3
            // 
            this.trackBar_S3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_S3.AutoSize = false;
            this.trackBar_S3.Location = new System.Drawing.Point(185, 128);
            this.trackBar_S3.Maximum = 125;
            this.trackBar_S3.Minimum = 30;
            this.trackBar_S3.Name = "trackBar_S3";
            this.trackBar_S3.Size = new System.Drawing.Size(512, 29);
            this.trackBar_S3.TabIndex = 17;
            this.trackBar_S3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_S3.Value = 30;
            // 
            // trackBar_S2
            // 
            this.trackBar_S2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_S2.AutoSize = false;
            this.trackBar_S2.Location = new System.Drawing.Point(185, 86);
            this.trackBar_S2.Maximum = 125;
            this.trackBar_S2.Minimum = 30;
            this.trackBar_S2.Name = "trackBar_S2";
            this.trackBar_S2.Size = new System.Drawing.Size(512, 29);
            this.trackBar_S2.TabIndex = 16;
            this.trackBar_S2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_S2.Value = 30;
            // 
            // trackBar_S1
            // 
            this.trackBar_S1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_S1.AutoSize = false;
            this.trackBar_S1.Location = new System.Drawing.Point(185, 42);
            this.trackBar_S1.Maximum = 125;
            this.trackBar_S1.Minimum = 30;
            this.trackBar_S1.Name = "trackBar_S1";
            this.trackBar_S1.Size = new System.Drawing.Size(512, 29);
            this.trackBar_S1.TabIndex = 15;
            this.trackBar_S1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_S1.Value = 30;
            // 
            // button_S3High
            // 
            this.button_S3High.Location = new System.Drawing.Point(128, 130);
            this.button_S3High.Name = "button_S3High";
            this.button_S3High.Size = new System.Drawing.Size(51, 23);
            this.button_S3High.TabIndex = 14;
            this.button_S3High.Text = ">";
            this.button_S3High.UseVisualStyleBackColor = true;
            // 
            // button_S3Low
            // 
            this.button_S3Low.Location = new System.Drawing.Point(76, 130);
            this.button_S3Low.Name = "button_S3Low";
            this.button_S3Low.Size = new System.Drawing.Size(51, 23);
            this.button_S3Low.TabIndex = 13;
            this.button_S3Low.Text = "<";
            this.button_S3Low.UseVisualStyleBackColor = true;
            // 
            // button_S2High
            // 
            this.button_S2High.Location = new System.Drawing.Point(128, 87);
            this.button_S2High.Name = "button_S2High";
            this.button_S2High.Size = new System.Drawing.Size(51, 23);
            this.button_S2High.TabIndex = 12;
            this.button_S2High.Text = ">";
            this.button_S2High.UseVisualStyleBackColor = true;
            // 
            // button_S2Low
            // 
            this.button_S2Low.Location = new System.Drawing.Point(76, 87);
            this.button_S2Low.Name = "button_S2Low";
            this.button_S2Low.Size = new System.Drawing.Size(51, 23);
            this.button_S2Low.TabIndex = 11;
            this.button_S2Low.Text = "<";
            this.button_S2Low.UseVisualStyleBackColor = true;
            // 
            // button_S1High
            // 
            this.button_S1High.Location = new System.Drawing.Point(128, 44);
            this.button_S1High.Name = "button_S1High";
            this.button_S1High.Size = new System.Drawing.Size(51, 23);
            this.button_S1High.TabIndex = 10;
            this.button_S1High.Text = ">";
            this.button_S1High.UseVisualStyleBackColor = true;
            // 
            // button_S1Low
            // 
            this.button_S1Low.Location = new System.Drawing.Point(76, 44);
            this.button_S1Low.Name = "button_S1Low";
            this.button_S1Low.Size = new System.Drawing.Size(51, 23);
            this.button_S1Low.TabIndex = 9;
            this.button_S1Low.Text = "<";
            this.button_S1Low.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Servo 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Servo 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Servo 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "LED";
            // 
            // button_LedOff
            // 
            this.button_LedOff.Location = new System.Drawing.Point(128, 6);
            this.button_LedOff.Name = "button_LedOff";
            this.button_LedOff.Size = new System.Drawing.Size(51, 23);
            this.button_LedOff.TabIndex = 4;
            this.button_LedOff.Text = "Off";
            this.button_LedOff.UseVisualStyleBackColor = true;
            // 
            // button_ledOn
            // 
            this.button_ledOn.Location = new System.Drawing.Point(76, 6);
            this.button_ledOn.Name = "button_ledOn";
            this.button_ledOn.Size = new System.Drawing.Size(51, 23);
            this.button_ledOn.TabIndex = 3;
            this.button_ledOn.Text = "On";
            this.button_ledOn.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(312, 200);
            this.panel4.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DimGray;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.button_RR);
            this.panel7.Controls.Add(this.button_RS);
            this.panel7.Controls.Add(this.button_RF);
            this.panel7.Controls.Add(this.button_LR);
            this.panel7.Controls.Add(this.button_LS);
            this.panel7.Controls.Add(this.button_LF);
            this.panel7.Location = new System.Drawing.Point(25, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(237, 175);
            this.panel7.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(145, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Right engine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Left engine";
            // 
            // button_RR
            // 
            this.button_RR.Location = new System.Drawing.Point(147, 125);
            this.button_RR.Name = "button_RR";
            this.button_RR.Size = new System.Drawing.Size(75, 37);
            this.button_RR.TabIndex = 13;
            this.button_RR.Text = "Reverse";
            this.button_RR.UseVisualStyleBackColor = true;
            // 
            // button_RS
            // 
            this.button_RS.Location = new System.Drawing.Point(147, 81);
            this.button_RS.Name = "button_RS";
            this.button_RS.Size = new System.Drawing.Size(75, 37);
            this.button_RS.TabIndex = 12;
            this.button_RS.Text = "Stop";
            this.button_RS.UseVisualStyleBackColor = true;
            // 
            // button_RF
            // 
            this.button_RF.Location = new System.Drawing.Point(147, 37);
            this.button_RF.Name = "button_RF";
            this.button_RF.Size = new System.Drawing.Size(75, 37);
            this.button_RF.TabIndex = 11;
            this.button_RF.Text = "Forward";
            this.button_RF.UseVisualStyleBackColor = true;
            // 
            // button_LR
            // 
            this.button_LR.Location = new System.Drawing.Point(13, 125);
            this.button_LR.Name = "button_LR";
            this.button_LR.Size = new System.Drawing.Size(75, 37);
            this.button_LR.TabIndex = 10;
            this.button_LR.Text = "Reverse";
            this.button_LR.UseVisualStyleBackColor = true;
            // 
            // button_LS
            // 
            this.button_LS.Location = new System.Drawing.Point(13, 81);
            this.button_LS.Name = "button_LS";
            this.button_LS.Size = new System.Drawing.Size(75, 37);
            this.button_LS.TabIndex = 9;
            this.button_LS.Text = "Stop";
            this.button_LS.UseVisualStyleBackColor = true;
            // 
            // button_LF
            // 
            this.button_LF.Location = new System.Drawing.Point(13, 37);
            this.button_LF.Name = "button_LF";
            this.button_LF.Size = new System.Drawing.Size(75, 37);
            this.button_LF.TabIndex = 8;
            this.button_LF.Text = "Forward";
            this.button_LF.UseVisualStyleBackColor = true;
            // 
            // button_cameraON
            // 
            this.button_cameraON.Location = new System.Drawing.Point(705, 4);
            this.button_cameraON.Name = "button_cameraON";
            this.button_cameraON.Size = new System.Drawing.Size(75, 23);
            this.button_cameraON.TabIndex = 7;
            this.button_cameraON.Text = "ON";
            this.button_cameraON.UseVisualStyleBackColor = true;
            // 
            // button_cameraOFF
            // 
            this.button_cameraOFF.Location = new System.Drawing.Point(786, 4);
            this.button_cameraOFF.Name = "button_cameraOFF";
            this.button_cameraOFF.Size = new System.Drawing.Size(75, 23);
            this.button_cameraOFF.TabIndex = 8;
            this.button_cameraOFF.Text = "OFF";
            this.button_cameraOFF.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(638, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Camera:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(744, 539);
            this.Name = "Form1";
            this.Text = "AdvancedTankControl";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_S3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_S2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_S1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_S3High;
        private System.Windows.Forms.Button button_S3Low;
        private System.Windows.Forms.Button button_S2High;
        private System.Windows.Forms.Button button_S2Low;
        private System.Windows.Forms.Button button_S1High;
        private System.Windows.Forms.Button button_S1Low;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_LedOff;
        private System.Windows.Forms.Button button_ledOn;
        private System.Windows.Forms.TrackBar trackBar_S3;
        private System.Windows.Forms.TrackBar trackBar_S2;
        private System.Windows.Forms.TrackBar trackBar_S1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_RR;
        private System.Windows.Forms.Button button_RS;
        private System.Windows.Forms.Button button_RF;
        private System.Windows.Forms.Button button_LR;
        private System.Windows.Forms.Button button_LS;
        private System.Windows.Forms.Button button_LF;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_FPS;
        private System.Windows.Forms.TextBox textBox_FPS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_cameraOFF;
        private System.Windows.Forms.Button button_cameraON;
    }
}

