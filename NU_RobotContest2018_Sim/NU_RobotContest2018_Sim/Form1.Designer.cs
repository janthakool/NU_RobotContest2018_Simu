namespace NU_RobotContest2018_Sim
{
	partial class FormMain
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Robot = new System.Windows.Forms.Button();
            this.button_Ball_Red = new System.Windows.Forms.Button();
            this.button_Obstacle1 = new System.Windows.Forms.Button();
            this.button_MV_FW = new System.Windows.Forms.Button();
            this.button_MV_BW = new System.Windows.Forms.Button();
            this.button_TN_R = new System.Windows.Forms.Button();
            this.button_TN_L = new System.Windows.Forms.Button();
            this.button_Ball_Green = new System.Windows.Forms.Button();
            this.button_Ball_Blue = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerSim = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Obstacle2 = new System.Windows.Forms.Button();
            this.button_Obstacle3 = new System.Windows.Forms.Button();
            this.button_Obstacle4 = new System.Windows.Forms.Button();
            this.button_Obstacle5 = new System.Windows.Forms.Button();
            this.button_Obstacle6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // button_Robot
            // 
            this.button_Robot.Location = new System.Drawing.Point(418, 12);
            this.button_Robot.Name = "button_Robot";
            this.button_Robot.Size = new System.Drawing.Size(75, 23);
            this.button_Robot.TabIndex = 1;
            this.button_Robot.Text = "Robot";
            this.button_Robot.UseVisualStyleBackColor = true;
            this.button_Robot.Click += new System.EventHandler(this.button_Robot_Click);
            // 
            // button_Ball_Red
            // 
            this.button_Ball_Red.Location = new System.Drawing.Point(418, 41);
            this.button_Ball_Red.Name = "button_Ball_Red";
            this.button_Ball_Red.Size = new System.Drawing.Size(75, 23);
            this.button_Ball_Red.TabIndex = 2;
            this.button_Ball_Red.Text = "Red Ball";
            this.button_Ball_Red.UseVisualStyleBackColor = true;
            this.button_Ball_Red.Click += new System.EventHandler(this.button_Ball_Click);
            // 
            // button_Obstacle1
            // 
            this.button_Obstacle1.Location = new System.Drawing.Point(418, 128);
            this.button_Obstacle1.Name = "button_Obstacle1";
            this.button_Obstacle1.Size = new System.Drawing.Size(75, 23);
            this.button_Obstacle1.TabIndex = 3;
            this.button_Obstacle1.Text = "Obstacle1";
            this.button_Obstacle1.UseVisualStyleBackColor = true;
            this.button_Obstacle1.Click += new System.EventHandler(this.button_Obstacle_Click);
            // 
            // button_MV_FW
            // 
            this.button_MV_FW.Location = new System.Drawing.Point(625, 322);
            this.button_MV_FW.Name = "button_MV_FW";
            this.button_MV_FW.Size = new System.Drawing.Size(75, 23);
            this.button_MV_FW.TabIndex = 4;
            this.button_MV_FW.Text = "FW";
            this.button_MV_FW.UseVisualStyleBackColor = true;
            this.button_MV_FW.Click += new System.EventHandler(this.button_MV_FW_Click);
            // 
            // button_MV_BW
            // 
            this.button_MV_BW.Location = new System.Drawing.Point(625, 380);
            this.button_MV_BW.Name = "button_MV_BW";
            this.button_MV_BW.Size = new System.Drawing.Size(75, 23);
            this.button_MV_BW.TabIndex = 5;
            this.button_MV_BW.Text = "BW";
            this.button_MV_BW.UseVisualStyleBackColor = true;
            this.button_MV_BW.Click += new System.EventHandler(this.button_MV_BW_Click);
            // 
            // button_TN_R
            // 
            this.button_TN_R.Location = new System.Drawing.Point(692, 351);
            this.button_TN_R.Name = "button_TN_R";
            this.button_TN_R.Size = new System.Drawing.Size(75, 23);
            this.button_TN_R.TabIndex = 6;
            this.button_TN_R.Text = "TR";
            this.button_TN_R.UseVisualStyleBackColor = true;
            this.button_TN_R.Click += new System.EventHandler(this.button_TN_R_Click);
            // 
            // button_TN_L
            // 
            this.button_TN_L.Location = new System.Drawing.Point(563, 351);
            this.button_TN_L.Name = "button_TN_L";
            this.button_TN_L.Size = new System.Drawing.Size(75, 23);
            this.button_TN_L.TabIndex = 7;
            this.button_TN_L.Text = "TL";
            this.button_TN_L.UseVisualStyleBackColor = true;
            this.button_TN_L.Click += new System.EventHandler(this.button_TN_L_Click);
            // 
            // button_Ball_Green
            // 
            this.button_Ball_Green.Location = new System.Drawing.Point(418, 70);
            this.button_Ball_Green.Name = "button_Ball_Green";
            this.button_Ball_Green.Size = new System.Drawing.Size(75, 23);
            this.button_Ball_Green.TabIndex = 8;
            this.button_Ball_Green.Text = "Green Ball";
            this.button_Ball_Green.UseVisualStyleBackColor = true;
            this.button_Ball_Green.Click += new System.EventHandler(this.button_Ball_Green_Click);
            // 
            // button_Ball_Blue
            // 
            this.button_Ball_Blue.Location = new System.Drawing.Point(418, 99);
            this.button_Ball_Blue.Name = "button_Ball_Blue";
            this.button_Ball_Blue.Size = new System.Drawing.Size(75, 23);
            this.button_Ball_Blue.TabIndex = 9;
            this.button_Ball_Blue.Text = "Blue Ball";
            this.button_Ball_Blue.UseVisualStyleBackColor = true;
            this.button_Ball_Blue.Click += new System.EventHandler(this.button_Ball_Blue_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(418, 389);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 10;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "label3";
            // 
            // timerSim
            // 
            this.timerSim.Interval = 1000;
            this.timerSim.Tick += new System.EventHandler(this.timerSim_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(639, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "label5";
            // 
            // button_Obstacle2
            // 
            this.button_Obstacle2.Location = new System.Drawing.Point(418, 157);
            this.button_Obstacle2.Name = "button_Obstacle2";
            this.button_Obstacle2.Size = new System.Drawing.Size(75, 23);
            this.button_Obstacle2.TabIndex = 16;
            this.button_Obstacle2.Text = "Obstacle2";
            this.button_Obstacle2.UseVisualStyleBackColor = true;
            this.button_Obstacle2.Click += new System.EventHandler(this.button_Obstacle2_Click);
            // 
            // button_Obstacle3
            // 
            this.button_Obstacle3.Location = new System.Drawing.Point(418, 186);
            this.button_Obstacle3.Name = "button_Obstacle3";
            this.button_Obstacle3.Size = new System.Drawing.Size(75, 23);
            this.button_Obstacle3.TabIndex = 17;
            this.button_Obstacle3.Text = "Obstacle3";
            this.button_Obstacle3.UseVisualStyleBackColor = true;
            this.button_Obstacle3.Click += new System.EventHandler(this.button_Obstacle3_Click);
            // 
            // button_Obstacle4
            // 
            this.button_Obstacle4.Location = new System.Drawing.Point(418, 215);
            this.button_Obstacle4.Name = "button_Obstacle4";
            this.button_Obstacle4.Size = new System.Drawing.Size(75, 23);
            this.button_Obstacle4.TabIndex = 18;
            this.button_Obstacle4.Text = "Obstacle4";
            this.button_Obstacle4.UseVisualStyleBackColor = true;
            this.button_Obstacle4.Click += new System.EventHandler(this.button_Obstacle4_Click);
            // 
            // button_Obstacle5
            // 
            this.button_Obstacle5.Location = new System.Drawing.Point(418, 244);
            this.button_Obstacle5.Name = "button_Obstacle5";
            this.button_Obstacle5.Size = new System.Drawing.Size(75, 23);
            this.button_Obstacle5.TabIndex = 19;
            this.button_Obstacle5.Text = "Obstacle5";
            this.button_Obstacle5.UseVisualStyleBackColor = true;
            this.button_Obstacle5.Click += new System.EventHandler(this.button_Obstacle5_Click);
            // 
            // button_Obstacle6
            // 
            this.button_Obstacle6.Location = new System.Drawing.Point(418, 273);
            this.button_Obstacle6.Name = "button_Obstacle6";
            this.button_Obstacle6.Size = new System.Drawing.Size(75, 23);
            this.button_Obstacle6.TabIndex = 20;
            this.button_Obstacle6.Text = "Obstacle6";
            this.button_Obstacle6.UseVisualStyleBackColor = true;
            this.button_Obstacle6.Click += new System.EventHandler(this.button_Obstacle6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(418, 312);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "500";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Obstacle6);
            this.Controls.Add(this.button_Obstacle5);
            this.Controls.Add(this.button_Obstacle4);
            this.Controls.Add(this.button_Obstacle3);
            this.Controls.Add(this.button_Obstacle2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_Ball_Blue);
            this.Controls.Add(this.button_Ball_Green);
            this.Controls.Add(this.button_TN_L);
            this.Controls.Add(this.button_TN_R);
            this.Controls.Add(this.button_MV_BW);
            this.Controls.Add(this.button_MV_FW);
            this.Controls.Add(this.button_Obstacle1);
            this.Controls.Add(this.button_Ball_Red);
            this.Controls.Add(this.button_Robot);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NU-Robot Contest 2018 Simulation";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button_Robot;
		private System.Windows.Forms.Button button_Ball_Red;
		private System.Windows.Forms.Button button_Obstacle1;
		private System.Windows.Forms.Button button_MV_FW;
		private System.Windows.Forms.Button button_MV_BW;
		private System.Windows.Forms.Button button_TN_R;
		private System.Windows.Forms.Button button_TN_L;
		private System.Windows.Forms.Button button_Ball_Green;
		private System.Windows.Forms.Button button_Ball_Blue;
		private System.Windows.Forms.Button button_Start;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timerSim;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button_Obstacle2;
		private System.Windows.Forms.Button button_Obstacle3;
		private System.Windows.Forms.Button button_Obstacle4;
		private System.Windows.Forms.Button button_Obstacle5;
		private System.Windows.Forms.Button button_Obstacle6;
        private System.Windows.Forms.TextBox textBox1;
    }
}

