using System;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {
        int gravity = 10; 
        int pipeSpeed = 5; 
        int score = 0; 

        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);

        }
         

        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Interval = 30;
            gameTimer.Tick += new EventHandler(GameTimer_Tick);
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;


            if (pipeTop.Left < -50)
            {
                pipeTop.Left = this.ClientSize.Width + 50;
                score++;
            }
            if (pipeBottom.Left < -50)
            {
                pipeBottom.Left = this.ClientSize.Width + 50;
                score++;
            }

            lblScore.Text = "Score: " + score;


            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            lblScore.Text = "GAME OVER : " + score;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10; 
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10; 
            }
        }

        private void ground_Click(object sender, EventArgs e)
        {

        }
    }
}
