using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace NU_RobotContest2018_Sim
{
	public partial class FormMain : Form
	{
		double Robot_H = 90.0;
		double Robot_X = 200.0;
		double Robot_Y = 200.0;

		double Robot_Radius = 20.0;
		double Ball_Radius = 10.0;
		double Robot_MoveStep = 5.0;
		double Robot_TurnStep = 2.5;

		double[] Object_X = new double[13];
		double[] Object_Y = new double[13];

		double[] Distance = new double[13];
		double[] Direction = new double[13];
		double[] Delta_Direction = new double[13];

		double Robot_Ball_AcceptedDirection = 5.0;
		double Robot_Ball_AcceptedDistance = 22.0;

		double Robot_Zone_AcceptedDirection = 5.0;
		double Robot_Zone_AcceptedDistance = 22.0;

		double Robot_AvoidanceDistance = 80.0;
		double Robot_AvoidanceDirection = 30.0;

		string clickObj = "Robot";

		int Robot_State = 0;
        int sub_Robot_State = 0;
        int Subvalue_ServoAccepted = 20;
        int minDisIndex;

		bool timerSimFlg = false;

		//Index 0 = Red Ball
		//Index 1 = Green Ball
		//Index 2 = Blue Ball
		//Index 3 = Purple Obstacle
		//Index 4 = Purple Obstacle
		//Index 5 = Purple Obstacle
		//Index 6 = Purple Obstacle
		//Index 7 = Purple Obstacle
		//Index 8 = Purple Obstacle
		//Index 9 = Start/Stop Zone
		//Index 10 = Red Zone
		//Index 11 = Green Zone
		//Index 12 = Blue Zone

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 13; i++)
			{
				Object_X[i] = -1.0;
				Object_Y[i] = -1.0;
			}

			Object_X[9] = 20.0;
			Object_Y[9] = 20.0;

			Object_X[10] = 380.0;
			Object_Y[10] = 20.0;

			Object_X[11] = 380.0;
			Object_Y[11] = 380.0;

			Object_X[12] = 20.0;
			Object_Y[12] = 380.0;

			timerSim.Enabled = false;

		}

		private void timerSim_Tick(object sender, EventArgs e)
		{
            //getMessage();

            getDirection();
			getDistance();
						
			check_State();

			draw();
			showLabel();
		}

		private void button_Robot_Click(object sender, EventArgs e)
		{
			clickObj = "Robot";
		}

		private void button_Ball_Click(object sender, EventArgs e)
		{
			clickObj = "RedBall";
		}

		private void button_Ball_Green_Click(object sender, EventArgs e)
		{
			clickObj = "GreenBall";
		}

		private void button_Ball_Blue_Click(object sender, EventArgs e)
		{
			clickObj = "BlueBall";
		}

		private void button_Obstacle_Click(object sender, EventArgs e)
		{
			clickObj = "Obstacle1";
		}

		private void button_Obstacle2_Click(object sender, EventArgs e)
		{
			clickObj = "Obstacle2";
		}

		private void button_Obstacle3_Click(object sender, EventArgs e)
		{
			clickObj = "Obstacle3";
		}

		private void button_Obstacle4_Click(object sender, EventArgs e)
		{
			clickObj = "Obstacle4";
		}

		private void button_Obstacle5_Click(object sender, EventArgs e)
		{
			clickObj = "Obstacle5";
		}

		private void button_Obstacle6_Click(object sender, EventArgs e)
		{
			clickObj = "Obstacle6";
		}

		private void button_Start_Click(object sender, EventArgs e)
		{
            timerSim.Interval = int.Parse(textBox1.Text);
			timerSimFlg = !timerSimFlg;
			timerSim.Enabled = timerSimFlg;

			if (timerSimFlg == true)
			{
				timerSim.Start();
				button_Start.Text = "Stop";
			}
			else
			{
				timerSim.Stop();
				button_Start.Text = "Start";
			}

		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (clickObj == "Robot")
			{
				Robot_X = e.X;
				Robot_Y = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "RedBall")
			{
				Object_X[0] = e.X;
				Object_Y[0] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "GreenBall")
			{
				Object_X[1] = e.X;
				Object_Y[1] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "BlueBall")
			{
				Object_X[2] = e.X;
				Object_Y[2] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "Obstacle1")
			{
				Object_X[3] = e.X;
				Object_Y[3] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "Obstacle2")
			{
				Object_X[4] = e.X;
				Object_Y[4] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "Obstacle3")
			{
				Object_X[5] = e.X;
				Object_Y[5] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "Obstacle4")
			{
				Object_X[6] = e.X;
				Object_Y[6] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "Obstacle5")
			{
				Object_X[7] = e.X;
				Object_Y[7] = pictureBox1.Height - e.Y;
			}
			else if (clickObj == "Obstacle6")
			{
				Object_X[8] = e.X;
				Object_Y[8] = pictureBox1.Height - e.Y;
			}

			getDirection();
			getDistance();
			draw();
			showLabel();
		}
			
		private void button_MV_FW_Click(object sender, EventArgs e)
		{
			Robot_Move_Forward();
            //getMessage();

            getDirection();
			getDistance();

			draw();
			showLabel();
		}

		private void button_MV_BW_Click(object sender, EventArgs e)
		{
			Robot_Move_Backward();
            //getMessage();

            getDirection();
			getDistance();
			
			draw();
			showLabel();
		}

		private void button_TN_R_Click(object sender, EventArgs e)
		{
			Robot_Turn_Right();
            //getMessage();

            getDirection();
			getDistance();
			
			draw();
			showLabel();
		}

		private void button_TN_L_Click(object sender, EventArgs e)
		{
			Robot_Turn_Left();
            //getMessage();

            getDirection();
			getDistance();

			draw();
			showLabel();
		}

		private void draw()
		{
			pictureBox1.CreateGraphics().Clear(Color.White);


			using (Graphics Ball_Graphics = pictureBox1.CreateGraphics())
			{
				Ball_Graphics.FillEllipse(Brushes.Red, new Rectangle((int)(Object_X[0] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[0] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Ball_Graphics.FillEllipse(Brushes.Green, new Rectangle((int)(Object_X[1] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[1] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Ball_Graphics.FillEllipse(Brushes.Blue, new Rectangle((int)(Object_X[2] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[2] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));
			}

			using (Graphics Obstacle_Graphics = pictureBox1.CreateGraphics())
			{
				Obstacle_Graphics.FillEllipse(Brushes.Purple, new Rectangle((int)(Object_X[3] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[3] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Obstacle_Graphics.FillEllipse(Brushes.Purple, new Rectangle((int)(Object_X[4] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[4] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Obstacle_Graphics.FillEllipse(Brushes.Purple, new Rectangle((int)(Object_X[5] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[5] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Obstacle_Graphics.FillEllipse(Brushes.Purple, new Rectangle((int)(Object_X[6] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[6] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Obstacle_Graphics.FillEllipse(Brushes.Purple, new Rectangle((int)(Object_X[7] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[7] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));

				Obstacle_Graphics.FillEllipse(Brushes.Purple, new Rectangle((int)(Object_X[8] - Ball_Radius), pictureBox1.Height - (int)(Object_Y[8] + Ball_Radius), (int)(Ball_Radius * 2.0), (int)(Ball_Radius * 2.0)));
			}

			using (Graphics Robot_Graphics = pictureBox1.CreateGraphics())
			{
				float Robot_H_X = (float)(Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_Radius * 1.5));
				float Robot_H_Y = (float)(Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_Radius * 1.5));

				Robot_Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(Robot_X - Robot_Radius), pictureBox1.Height - (int)(Robot_Y + Robot_Radius), (int)(Robot_Radius * 2.0), (int)(Robot_Radius * 2.0)));
				Robot_Graphics.DrawLine(new Pen(Color.Cyan, 2.0f), (float)Robot_X, pictureBox1.Height - (float)Robot_Y, (float)Robot_H_X, pictureBox1.Height - (float)Robot_H_Y);
			}

		}

		private void showLabel()
		{
			label2.Text = Robot_H.ToString("0.00");
			label2.Update();

			label1.Text = Direction[0].ToString("0.00");

			label3.Text = Delta_Direction[0].ToString("0.00");

			label4.Text = Robot_State.ToString();

			label5.Text = Distance[0].ToString("0.00");
		}

		private void Robot_Move_Forward()
		{
			Robot_MoveStep = 5.0;
			Robot_X = Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Robot_Y = Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);

			if (Robot_X <= 0)
			{
				Robot_X = 0;
			}
			if (Robot_Y <= 0)
			{
				Robot_Y = 0;
			}

			if (Robot_X >= pictureBox1.Width)
			{
				Robot_X = pictureBox1.Width;
			}
			if (Robot_Y >= pictureBox1.Height)
			{
				Robot_Y = pictureBox1.Height;
			}
		}

		private void Robot_Move_Backward()
		{
			Robot_MoveStep = 5.0;
			Robot_X = Robot_X - (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Robot_Y = Robot_Y - (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);

			if (Robot_X <= 0)
			{
				Robot_X = 0;
			}
			if (Robot_Y <= 0)
			{
				Robot_Y = 0;
			}

			if (Robot_X >= pictureBox1.Width)
			{
				Robot_X = pictureBox1.Width;
			}
			if (Robot_Y >= pictureBox1.Height)
			{
				Robot_Y = pictureBox1.Height;
			}
		}

		private void Robot_Turn_Right()
		{
			Robot_H = Robot_H - Robot_TurnStep;

			if (Robot_H < 0)
			{
				Robot_H = 360 + Robot_H;
			}
		}

		private void Robot_Turn_Left()
		{
			Robot_H = Robot_H + Robot_TurnStep;

			if (Robot_H > 360.0)
			{
				Robot_H = 360 - Robot_H;
			}
		}
		

		private void Robot_Move_Forward_byDistance(double Distance)
		{
			Robot_MoveStep = Distance*0.15;
			
			Robot_X = Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Robot_Y = Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);

			if (Robot_X <= 0)
			{
				Robot_X = 0;
			}
			if (Robot_Y <= 0)
			{
				Robot_Y = 0;
			}

			if (Robot_X >= pictureBox1.Width)
			{
				Robot_X = pictureBox1.Width;
			}
			if (Robot_Y >= pictureBox1.Height)
			{
				Robot_Y = pictureBox1.Height;
			}
		}

		private void Robot_Turn_Right_byDirection(double Direction)
		{
			double _Robot_TurnStep = Math.Abs(Direction) * 0.5;
			Robot_H = Robot_H - _Robot_TurnStep;

			if (Robot_H < 0)
			{
				Robot_H = 360 + Robot_H;
			}
		}

		private void Robot_Turn_Left_byDirection(double Direction)
		{
			double _Robot_TurnStep = Math.Abs(Direction) * 0.5;

			Robot_H = Robot_H + _Robot_TurnStep;

			if (Robot_H > 360.0)
			{
				Robot_H = 360 - Robot_H;
			}
		}


		private void Robot_Move_Forward_AvoidbyDistance(double Distance)
		{
			Robot_MoveStep = Distance * 0.30;

			Robot_X = Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Robot_Y = Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);

			if (Robot_X <= 0)
			{
				Robot_X = 0;
			}
			if (Robot_Y <= 0)
			{
				Robot_Y = 0;
			}

			if (Robot_X >= pictureBox1.Width)
			{
				Robot_X = pictureBox1.Width;
			}
			if (Robot_Y >= pictureBox1.Height)
			{
				Robot_Y = pictureBox1.Height;
			}
		}
		
		private void Robot_Turn_Right_AvoidbyDirection(double Direction)
		{
			double _Robot_TurnStep = (180 -Math.Abs(Direction)) * 0.4;
			Robot_H = Robot_H - _Robot_TurnStep;

			if (Robot_H < 0)
			{
				Robot_H = 360 + Robot_H;
			}
		}

		private void Robot_Turn_Left_AvoidbyDirection(double Direction)
		{
			double _Robot_TurnStep = (180 - Math.Abs(Direction)) * 0.4;

			Robot_H = Robot_H + _Robot_TurnStep;

			if (Robot_H > 360.0)
			{
				Robot_H = 360 - Robot_H;
			}
		}
		


		private void Robot_Turn_WithBall_1()
		{
			Object_X[0] = Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_Ball_AcceptedDistance);
			Object_Y[0] = Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_Ball_AcceptedDistance);
		}

		private void Robot_MoveForward_WithBall_1()
		{
			Object_X[0] = Object_X[0] + (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Object_Y[0] = Object_Y[0] + (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);
		}

		private void Robot_Turn_WithBall_2()
		{
			Object_X[1] = Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_Ball_AcceptedDistance);
			Object_Y[1] = Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_Ball_AcceptedDistance);
		}

		private void Robot_MoveForward_WithBall_2()
		{
			Object_X[1] = Object_X[1] + (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Object_Y[1] = Object_Y[1] + (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);
		}

		private void Robot_Turn_WithBall_3()
		{
			Object_X[2] = Robot_X + (Math.Cos(Robot_H * Math.PI / 180) * Robot_Ball_AcceptedDistance);
			Object_Y[2] = Robot_Y + (Math.Sin(Robot_H * Math.PI / 180) * Robot_Ball_AcceptedDistance);
		}

		private void Robot_MoveForward_WithBall_3()
		{
			Object_X[2] = Object_X[2] + (Math.Cos(Robot_H * Math.PI / 180) * Robot_MoveStep);
			Object_Y[2] = Object_Y[2] + (Math.Sin(Robot_H * Math.PI / 180) * Robot_MoveStep);
		}
		
		private void check_State()
		{
            //(1)Red Ball
            #region State0
            if (Robot_State == 0)
            {
                if (Math.Abs(Delta_Direction[0]) <= Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 1;
                }
                else
                {
                    if (Delta_Direction[0] > 0)
                    {
                        Robot_Turn_Right_byDirection(Delta_Direction[0]);
                    }
                    else
                    {
                        Robot_Turn_Left_byDirection(Delta_Direction[0]);
                    }
                }
            }
            #endregion

            #region State1
            else if (Robot_State == 1)
            {
                if (Math.Abs(Delta_Direction[0]) > Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 0;
                    return;
                }

                if (Math.Abs(Distance[0]) <= Robot_Ball_AcceptedDistance)
                {
                    Robot_State = 2;
                }
                else
                {
                    minDisIndex = findMinDistanceIndex(Robot_State);
                    if (minDisIndex == -1)
                    {
                        Robot_Move_Forward_byDistance(Distance[0]);
                    }
                    else
                    {
                        avoidance();
                        Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
                    }
                }
            }
            #endregion State1

            #region State2
            else if (Robot_State == 2)
            {
                if (Math.Abs(Delta_Direction[0]) > Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 0;
                    return;
                }

                if (Math.Abs(Distance[0]) > Robot_Ball_AcceptedDistance)
                {
                    Robot_State = 1;
                    return;
                }

                if (Math.Abs(Delta_Direction[10]) <= Robot_Zone_AcceptedDirection)
                {
                    Robot_State = 3;
                }
                else
                {
                    if (Delta_Direction[10] > 0)
                    {
                        Robot_Turn_Right_byDirection(Delta_Direction[10]);
                    }
                    else
                    {
                        Robot_Turn_Left_byDirection(Delta_Direction[10]);
                    }
                    Robot_Turn_WithBall_1();
                }
            }
            #endregion

            #region State3
            else if (Robot_State == 3)
            {
                if (Robot_State == 3 && sub_Robot_State == 99)
                {
                    Robot_Move_Backward();
                    if (Math.Abs(Distance[10]) > Robot_Zone_AcceptedDistance + Subvalue_ServoAccepted)
                    {
                        sub_Robot_State = 0;
                        Robot_State = 4;
                    }
                }
                else
                {
                    if (Math.Abs(Delta_Direction[0]) > Robot_Ball_AcceptedDirection)
                    {
                        Robot_State = 0;
                        return;
                    }

                    if (Math.Abs(Distance[0]) > Robot_Ball_AcceptedDistance)
                    {
                        Robot_State = 1;
                        return;
                    }

                    if (Math.Abs(Delta_Direction[10]) > Robot_Zone_AcceptedDirection)
                    {
                        Robot_State = 2;
                        return;
                    }

                    //if (Math.Abs(Distance[10]) <= Robot_Zone_AcceptedDistance)
                    //{
                    //	Robot_State = 4;
                    //	Robot_Move_Backward();
                    //}
                    if (Math.Abs(Distance[10]) <= Robot_Zone_AcceptedDistance)
                    {
                        sub_Robot_State = 99;


                    }


                    else
                    {
                        minDisIndex = findMinDistanceIndex(Robot_State);
                        if (minDisIndex == -1)
                        {
                            Robot_Move_Forward_byDistance(Distance[10]);
                        }
                        else
                        {
                            avoidance();
                            Robot_Turn_WithBall_1();
                            Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
                        }
                        Robot_MoveForward_WithBall_1();
                    }
                }

            }
            #endregion

            //(2) Green Ball
            #region State4
            else if (Robot_State == 4)
            {
                if (Math.Abs(Delta_Direction[1]) <= Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 5;
                }
                else
                {
                    if (Delta_Direction[1] > 0)
                    {
                        Robot_Turn_Right_byDirection(Delta_Direction[1]);
                    }
                    else
                    {
                        Robot_Turn_Left_byDirection(Delta_Direction[1]);
                    }
                }
            }
            #endregion

            #region State5
            else if (Robot_State == 5)
            {
                if (Math.Abs(Delta_Direction[1]) > Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 4;
                    return;
                }

                if (Math.Abs(Distance[1]) <= Robot_Ball_AcceptedDistance)
                {
                    Robot_State = 6;
                }
                else
                {
                    minDisIndex = findMinDistanceIndex(Robot_State);
                    if (minDisIndex == -1)
                    {
                        Robot_Move_Forward_byDistance(Distance[1]);
                    }
                    else
                    {
                        avoidance();
                        Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
                    }
                }
            }
            #endregion

            #region State6
            else if (Robot_State == 6)
            {
                if (Math.Abs(Delta_Direction[1]) > Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 4;
                    return;
                }

                if (Math.Abs(Distance[1]) > Robot_Ball_AcceptedDistance)
                {
                    Robot_State = 5;
                    return;
                }

                if (Math.Abs(Delta_Direction[11]) <= Robot_Zone_AcceptedDirection)
                {
                    Robot_State = 7;
                }
                else
                {
                    if (Delta_Direction[11] > 0)
                    {
                        Robot_Turn_Right_byDirection(Delta_Direction[11]);
                    }
                    else
                    {
                        Robot_Turn_Left_byDirection(Delta_Direction[11]);
                    }
                    Robot_Turn_WithBall_2();
                }
            }
            #endregion

            #region State7
            else if (Robot_State == 7)
            {
                if (Robot_State == 7 && sub_Robot_State == 99)
                {
                    Robot_Move_Backward();
                    if (Math.Abs(Distance[11]) > Robot_Zone_AcceptedDistance + Subvalue_ServoAccepted)
                    {
                        sub_Robot_State = 0;
                        Robot_State = 8;
                    }
                }
                else
                {
                    if (Math.Abs(Delta_Direction[1]) > Robot_Ball_AcceptedDirection)
                    {
                        Robot_State = 4;
                        return;
                    }

                    if (Math.Abs(Distance[1]) > Robot_Ball_AcceptedDistance)
                    {
                        Robot_State = 5;
                        return;
                    }

                    if (Math.Abs(Delta_Direction[11]) > Robot_Zone_AcceptedDirection)
                    {
                        Robot_State = 6;
                        return;
                    }

                    //if (Math.Abs(Distance[11]) <= Robot_Zone_AcceptedDistance)
                    //{
                    //    Robot_State = 8;
                    //    Robot_Move_Backward();
                    //}
                    if (Math.Abs(Distance[11]) <= Robot_Zone_AcceptedDistance)
                    {
                        sub_Robot_State = 99;


                    }
                    else
                    {
                        minDisIndex = findMinDistanceIndex(Robot_State);
                        if (minDisIndex == -1)
                        {
                            Robot_Move_Forward_byDistance(Distance[11]);
                        }
                        else
                        {
                            avoidance();
                            Robot_Turn_WithBall_2();
                            Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
                        }
                        Robot_MoveForward_WithBall_2();
                    }
                }


            }
            #endregion

            //(3) Blue Ball
            #region State8
            else if (Robot_State == 8)
            {
                if (Math.Abs(Delta_Direction[2]) <= Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 9;
                }
                else
                {
                    if (Delta_Direction[2] > 0)
                    {
                        Robot_Turn_Right_byDirection(Delta_Direction[2]);
                    }
                    else
                    {
                        Robot_Turn_Left_byDirection(Delta_Direction[2]);
                    }
                }
            }
            #endregion

            #region State9
            else if (Robot_State == 9)
            {
                if (Math.Abs(Delta_Direction[2]) > Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 8;
                    return;
                }

                if (Math.Abs(Distance[2]) <= Robot_Ball_AcceptedDistance)
                {
                    Robot_State = 10;
                }
                else
                {
                    minDisIndex = findMinDistanceIndex(Robot_State);
                    if (minDisIndex == -1)
                    {
                        Robot_Move_Forward_byDistance(Distance[2]);
                    }
                    else
                    {
                        avoidance();
                        Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
                    }
                }
            }
            #endregion

            #region State10
            else if (Robot_State == 10)
            {
                if (Math.Abs(Delta_Direction[2]) > Robot_Ball_AcceptedDirection)
                {
                    Robot_State = 8;
                    return;
                }

                if (Math.Abs(Distance[2]) > Robot_Ball_AcceptedDistance)
                {
                    Robot_State = 9;
                    return;
                }

                if (Math.Abs(Delta_Direction[12]) <= Robot_Zone_AcceptedDirection)
                {
                    Robot_State = 11;
                }
                else
                {
                    if (Delta_Direction[12] > 0)
                    {
                        Robot_Turn_Right_byDirection(Delta_Direction[12]);
                    }
                    else
                    {
                        Robot_Turn_Left_byDirection(Delta_Direction[12]);
                    }
                    Robot_Turn_WithBall_3();
                }
            }
            #endregion

            #region State11
            else if (Robot_State == 11)
            {
                if (Robot_State == 11 && sub_Robot_State == 99)
                {
                    Robot_Move_Backward();
                    if (Math.Abs(Distance[10]) > Robot_Zone_AcceptedDistance + Subvalue_ServoAccepted)
                    {
                        sub_Robot_State = 0;
                        Robot_State = 12;
                    }
                }
                else
                {
                    if (Math.Abs(Delta_Direction[2]) > Robot_Ball_AcceptedDirection)
                    {
                        Robot_State = 8;
                        return;
                    }

                    if (Math.Abs(Distance[2]) > Robot_Ball_AcceptedDistance)
                    {
                        Robot_State = 9;
                        return;
                    }

                    if (Math.Abs(Delta_Direction[12]) > Robot_Zone_AcceptedDirection)
                    {
                        Robot_State = 10;
                        return;
                    }

                    //if (Math.Abs(Distance[12]) <= Robot_Zone_AcceptedDistance)
                    //{
                    //    Robot_State = 12;
                    //    Robot_Move_Backward();
                    //}
                    if (Math.Abs(Distance[12]) <= Robot_Zone_AcceptedDistance)
                    {
                        sub_Robot_State = 99;


                    }
                    else
                    {

                        minDisIndex = findMinDistanceIndex(Robot_State);
                        if (minDisIndex == -1)
                        {
                            Robot_Move_Forward_byDistance(Distance[12]);
                        }
                        else
                        {
                            avoidance();
                            Robot_Turn_WithBall_3();
                            Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
                        }
                        Robot_MoveForward_WithBall_3();
                    }
                }
 
			}
			#endregion

			//(4) Start/Stop Zone
			#region State12
			else if (Robot_State == 12)
			{

				if (Math.Abs(Delta_Direction[9]) <= Robot_Zone_AcceptedDirection)
				{
					Robot_State = 13;
				}
				else
				{
					if (Delta_Direction[9] > 0)
					{
						Robot_Turn_Right_byDirection(Delta_Direction[9]);
					}
					else
					{
						Robot_Turn_Left_byDirection(Delta_Direction[9]);
					}					
				}
			}
			#endregion

			#region State13
			else if (Robot_State == 13)
			{
				if (Math.Abs(Delta_Direction[9]) > Robot_Zone_AcceptedDirection)
				{
					Robot_State = 12;
					return;
				}

				if (Math.Abs(Distance[9]) <= Robot_Zone_AcceptedDistance)
				{
					Robot_State = 14;
				}
				else
				{
					minDisIndex = findMinDistanceIndex(Robot_State);
					if (minDisIndex == -1)
					{
						Robot_Move_Forward_byDistance(Distance[9]);
					}
					else
					{
						avoidance();
						Robot_Move_Forward_AvoidbyDistance(Distance[minDisIndex]);
					}
				}
			}
			#endregion

		}

		private void getDirection()
		{
			for (int i = 0; i < 13; i++)
			{
				Direction[i] = Math.Atan2((Object_Y[i] - Robot_Y), (Object_X[i] - Robot_X)) * 180 / Math.PI;

				if (Direction[i] < 0)
				{
					Direction[i] = Direction[i] + 360.0;
				}


				Delta_Direction[i] = Robot_H - Direction[i];

				if (Delta_Direction[i] < -180.0)
				{
					Delta_Direction[i] = Delta_Direction[i] + 360;
				}

			}
		}

		private void getDistance()
		{
			for (int i = 0; i < 13; i++)
			{
				Distance[i] = Math.Sqrt(((Object_Y[i] - Robot_Y)* (Object_Y[i] - Robot_Y)) +  ((Object_X[i] - Robot_X)* (Object_X[i] - Robot_X)));
			}
		}

        /*
		private void getMessage()
		{
			string msg1 = "";
			msg1 = msg1 + "(" + (Robot_H/ (double)1.0).ToString("0") + "," + (Robot_X / (double)4.0).ToString("0") + "," + (Robot_Y / (double)4.0).ToString("0") + ");";

			for (int i = 0; i < 3; i++)
			{
				int x = -1;
				int y = -1;

				if (Object_X[i] >= 0)
				{
					x = (int)(Object_X[i] / (double)4.0);
				}

				if (Object_Y[i] >= 0)
				{
					y = (int)(Object_Y[i] / (double)4.0);
				}

				msg1 = msg1 + "(" + x.ToString("0") + "," + y.ToString("0") + ")";
				if (i < 2)
				{
					msg1 = msg1 + ";";
				}
			}

			string msg2 = "";
			for (int i = 3; i < 13; i++)
			{
				int x = -1;
				int y = -1;

				if (Object_X[i] >= 0)
				{
					x = (int)(Object_X[i] / (double)4.0);
				}

				if (Object_Y[i] >= 0)
				{
					y = (int)(Object_Y[i] / (double)4.0);
				}

				msg2 = msg2 + "(" + x.ToString("0") + "," + y.ToString("0") + ")";
				if (i < 12)
				{
					msg2 = msg2 + ";";
				}
			}

			Console.WriteLine(msg1);
			Console.WriteLine(msg2);

			

			// create client instance 
			MqttClient client = new MqttClient("192.168.0.101");
			string clientId = Guid.NewGuid().ToString();
			client.Connect(clientId);		

			// publish a message on "/home/temperature" topic with QoS 2 
			client.Publish("/ESP/MSG1", Encoding.UTF8.GetBytes(msg1), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
			client.Publish("/ESP/MSG2", Encoding.UTF8.GetBytes(msg2), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
		}*/

		private void avoidance()
		{
			if (Delta_Direction[minDisIndex] > 0)
			{
				Robot_Turn_Left_AvoidbyDirection(Delta_Direction[minDisIndex]);
			}
			else
			{
				Robot_Turn_Right_AvoidbyDirection(Delta_Direction[minDisIndex]);
			}
		}

		private int findMinDistanceIndex(int state)
		{
			double minDis = 10000;
			int minIndex = -1;
			int iInitial = 0;

			if (state < 4)
			{
				iInitial = 1;
			}
			else if (state < 8)
			{
				iInitial = 2;
			}
			else if (state < 12)
			{
				iInitial = 3;
			}

			for (int i = iInitial; i < 9; i++)
			{
				if((Object_X[i] >0) && (Object_Y[i] > 0))
				{
					if (Distance[i] < minDis)
					{
						minDis = Distance[i];
						minIndex = i;
					}
					//Console.WriteLine(i + ": " + Distance[i]);
				}				
			}

			//Console.WriteLine("minDisIndex: " + minDisIndex);

			if (minIndex != -1)
			{
				if (
					(Distance[minIndex] <= Robot_AvoidanceDistance)
					&&
					(Delta_Direction[minIndex] <= Robot_AvoidanceDirection)
				)
				{
					return minIndex;
				}
				else
				{
					return -1;
				}
			}
			return minIndex;

		}
		
	}
}
