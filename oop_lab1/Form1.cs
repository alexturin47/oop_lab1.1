using System;
using System.Drawing;
using System.Windows.Forms;

namespace oop_lab1
{
    
    public partial class mainform : Form
    {
        private tPoint[] point;
        private Graphics g;
        private bool keySt;
        private Bitmap bitmap;
        private const int h = 5;


        public mainform()
        {
            InitializeComponent();           
        }

        private void RandomDraw_Click(object sender, EventArgs e)
        {
            keySt = false;
            Random rnd = new Random();
            int stepX = rnd.Next(-3,3);
            int stepY = rnd.Next(-3,3);
            RandomDraw.Text = "Сменить направление";

            while (!keySt)
            {
                g.Clear(pictureBox1.BackColor);
                for (int i = 0; i < 100; i++)
                {
                    point[i].Hide(g);
                    point[i].Move(stepX, stepY, pictureBox1.Width, pictureBox1.Height);
                    point[i].Draw(g);
                }
                Application.DoEvents();
                pictureBox1.Image = bitmap;
            }

            RandomDraw.Text = "Случайное направоление";
            
        }

        private void mainform_Shown(object sender, EventArgs e)
        {
            point = new tPoint[100];
            Random rnd = new Random();
            int wScr = pictureBox1.Width;
            int hScr = pictureBox1.Height;
            keySt = false;
            Color clr;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);

            for (int i = 0; i < 100; i++)
            {
                int X = rnd.Next(1, wScr);
                int Y = rnd.Next(1, hScr);
                int Red = rnd.Next(0, 255);
                int Green = rnd.Next(0, 255);
                int Blue = rnd.Next(0, 255);
                clr = Color.FromArgb(Red, Green, Blue);
                point[i] = new tPoint(X, Y, clr);
                point[i].Draw(g);
            }
            pictureBox1.Image = bitmap;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            keySt = true;
        }

        private void mainform_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            point[i].Hide(g);
                            point[i].Move(0, -h, pictureBox1.Width, pictureBox1.Height);
                            point[i].Draw(g);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            point[i].Hide(g);
                            point[i].Move(0, h, pictureBox1.Width, pictureBox1.Height);
                            point[i].Draw(g);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            point[i].Hide(g);
                            point[i].Move(-h, 0, pictureBox1.Width, pictureBox1.Height);
                            point[i].Draw(g);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            point[i].Hide(g);
                            point[i].Move(h, 0, pictureBox1.Width, pictureBox1.Height);
                            point[i].Draw(g);
                        }
                        break;
                    }
            }

            pictureBox1.Image = bitmap;

        }

        private void RandomDraw_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down )
                e.IsInputKey = true; 
        }

        private void stopBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.IsInputKey = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            keySt = true;
            Application.Exit();          
        }
    }
}
