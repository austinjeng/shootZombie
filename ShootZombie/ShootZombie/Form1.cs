using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootZombie
{
    public partial class Form1 : Form
    {
        PictureBox[,] a = new PictureBox[4, 4];
        Random rand = new Random();
        int pictureboxWidth = 110;
        int pictureboxHeight = 110;
        int pictureboxSpace = 0;
        int count = 0;
        int timeLeft = 30;
        UInt64 hp = 200;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            createArray();
        }

        void createArray()
        {
           
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int pictureboxX = 3 + pictureboxSpace + x * (pictureboxWidth + pictureboxSpace);
                    int pictureboxY = 100 + pictureboxSpace + y * (pictureboxHeight + pictureboxSpace);
                    
                    a[x, y] = new PictureBox();
                    a[x, y].Location = new System.Drawing.Point(pictureboxX, pictureboxY);
                    a[x, y].Size = new System.Drawing.Size(pictureboxWidth, pictureboxHeight);
                    a[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    a[x, y].BackColor = Color.Transparent;
                    if (x == 3)
                    {
                        int j = rand.Next(0, 4);
                        a[j, y].Image = ShootZombie.Properties.Resources.Pns_01;
                    }
                    this.Controls.Add(a[x, y]);
                }
            }
        }

        void createFirstRow()
        {
            bool flag = false;
            int j = rand.Next(0, 4);

            if (count == 216 && flag == false)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Saitama;
                flag = true;
                return;
            }
            
            if (count >= 0 && count < 40)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_01;
            }
            else if (count >= 40 && count < 80)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_02;
            }
            else if (count >= 80 && count < 120)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_03;
            }
            else if (count >= 120 && count < 170)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_04;
            }
            else if (count >= 170 && count < 217)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_05;
            }


            this.Controls.Add(a[j, 0]);

        }

        private void buttonPress(object sender, KeyEventArgs e)
        {
            timer.Start();
            if (e.KeyValue == 'C')
            {
                if (a[0, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    a[0, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0, j = 0; x < 4; x++, j++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[j, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[0, 3].Image == null)
                {
                    hp -= 10;
                    label2.Text = hp.ToString();
                }
            }

            if (e.KeyValue == 'V')
            {
                if (a[1, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    a[1, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0, j = 0; x < 4; x++, j++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[j, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[1, 3].Image == null)
                {
                    hp -= 10;
                    label2.Text = hp.ToString();
                }
            }

            if (e.KeyValue == 'N')
            {
                if (a[2, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    a[2, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0, j = 0; x < 4; x++, j++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[j, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[2, 3].Image == null)
                {
                    hp -= 10;
                    label2.Text = hp.ToString();
                }
            }

            if (e.KeyValue == 'M')
            {
                if (a[3, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    a[3, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0, j = 0; x < 4; x++, j++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[j, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[3, 3].Image == null)
                {
                    hp -= 10;
                    label2.Text = hp.ToString();
                }
            }
            if (hp == 0)
            {
                timer.Stop();
                MessageBox.Show("Game Over!" + " Your score is " + score);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                label1.Text = (timeLeft % 60).ToString();

                if(count >= 220)
                {
                    timer.Stop();
                    MessageBox.Show("You win!"+ " Your score is " + score);
                }
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Time's up!" + " Your score is " + score);
            }
        }
        void scoreCalculate()
        {
            if (count >= 0 && count < 40)
            {
                score += 100;
            }
            else if (count >= 40 && count < 80)
            {
                score += 500;
            }
            else if (count >= 80 && count < 120)
            {
                score += 1000;
            }
            else if (count >= 120 && count < 170)
            {
                score += 2000;
            }
            else if (count >= 170 && count < 220)
            {
                score += 5000;
            }
            else if (count == 220)
            {
                score += 10000;
            }
        }
    }
}
