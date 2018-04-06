using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Snake
{
    public partial class Snake : Form
    {

        public Button yem;
        public Button beden;
        public Timer timer1;
        Random rand = new Random();
        List<Button> snake = new List<Button>();
        public int TopPos = 0;
        public int LeftPos = 0;
       
        public int counter = 60;
        
        public Snake()
        {
            InitializeComponent();
            ilan = new Button();
            ilan.Text = "yilan";
            ilan.FlatStyle = FlatStyle.Flat;
            ilan.BackColor = Color.Brown;
            ilan.Width = 40;
            ilan.Height = 40;
            ilan.Top = TopPos;
            ilan.Left = LeftPos;
            ilan.Enabled = false;
            Controls.Add(ilan);
            snake.Add(ilan);
            mealcreate();
            MealEatMethod();
              
     
        }

       

        private void up_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < snake.Count; i++)
                {
                    snake[i].Top = snake[i].Top - 40;
                    if (snake[i].Top > 400)
                    {
                        snake[i].Top = 0;
                    }
                    else if (snake[i].Top < 0)
                    {
                        snake[i].Top = 400;
                    }

                }






                //if (snake[snake.Count]==snake.[snake.Count])
                //{

                //}
                MealEatMethod();
            //    ExtendTheLenghtUp(); //////////////
               


            }
          
            if (e.KeyCode == Keys.Down)
            {
         //       TimeCountDownMethod();
                MealEatMethod();
                ilan.Top = ilan.Top + 40;
                if (ilan.Top > 400)
                {
                    ilan.Top = 0;
                }
                else if (ilan.Top < 0)
                {
                    ilan.Top = 400;
                }


            }

            if (e.KeyCode == Keys.Left)
            {
            //    TimeCountDownMethod();

                MealEatMethod();
                ilan.Left = ilan.Left - 40;
                if (ilan.Left > 400)
                {
                    ilan.Left = 0;
                }
                else if (ilan.Left < 0)
                {
                    ilan.Left = 400;
                }

            }
           
            if (e.KeyCode == Keys.Right)
            {
             //   TimeCountDownMethod();

                MealEatMethod();
                ilan.Left = ilan.Left + 40;
                if (ilan.Left > 400)
                {
                    ilan.Left = 0;
                }
                else if (ilan.Left < 0)
                {
                    ilan.Left = 400;
                }

            }
           
        }
        void mealcreate()
        {


            while (true)
            {
                int x = rand.Next(1, 400);
                
                if (x % 40 == 0)
                {
                yem = new Button();
                Controls.Add(yem);

                yem.Top = x;
                    yem.Left = x;
                    yem.Text = "yem";
                    yem.Width = 40;
                    yem.Height = 40;
                    yem.BackColor = Color.Tomato;
                    yem.Enabled = false;
                    break;
                }
                
            }
            
        }
        void MealEatMethod()
        {
            if ((ilan.Top == yem.Top) && (ilan.Left == yem.Left))
            {
                ilan.BackColor = Color.Green;
                playSimpleSound();
                Controls.Remove(yem);
                ExtendTheLenghtUp();
                //////////////////////
                //beden = new Button();
                //beden.Width = 40;
                //beden.Height = 40;
                //Controls.Add(beden);
                //snake.Add(beden);
                //beden.Enabled = false;
                mealcreate();
            }
        }
        void TimeCountDownMethod()
        {

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            label1.Text = counter.ToString();


             void timer1_Tick(object sender, EventArgs e)
            {
                counter--;

                if ((counter == 3) || (counter == 2) || (counter == 1))
                {
                    label1.Font = new Font("Arial", 16);
                }
                if (counter == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over");

                }
               
                label1.Text = "Time: " + counter.ToString();
                label1.BackColor = Color.Black;
                label1.ForeColor = Color.White;
            }
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\P106\Desktop\c#\ses.wav");
            simpleSound.Play();
        }



        void ExtendTheLenghtUp()
        {
            beden = new Button();
            beden.Width = 40;
            beden.Height = 40;
           
            beden.Left = snake[snake.Count-1].Left;
            beden.Top = snake[snake.Count-1].Top+40;
            Controls.Add(beden);
            snake.Add(beden);
            beden.Enabled = false;

        }
        void extendTheLenghtDown()
        {
            beden = new Button();
            beden.Width = 40;
            beden.Height = 40;

            beden.Left = snake[snake.Count - 1].Left;
            beden.Top = snake[snake.Count - 1].Top-40;
            Controls.Add(beden);
            snake.Add(beden);
            beden.Enabled = false;
        }
        void extendTheLenghtLeft()
        {
            beden = new Button();
            beden.Width = 40;
            beden.Height = 40;

            beden.Left = snake[snake.Count - 1].Left + 40;
            beden.Top = snake[snake.Count - 1].Top;
            Controls.Add(beden);
            snake.Add(beden);
            beden.Enabled = false;
        } 
        void extendTheLenghtRight()
        {
            beden = new Button();
            beden.Width = 40;
            beden.Height = 40;

            beden.Left = snake[snake.Count - 1].Left + 40;
            beden.Top = snake[snake.Count - 1].Top;
            Controls.Add(beden);
            snake.Add(beden);
            beden.Enabled = false;
        }



        private void Snake_Load(object sender, EventArgs e)
        {
            TimeCountDownMethod();
            snake.Add(ilan);
        }
    }
}
