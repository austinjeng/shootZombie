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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var gameForm = new Form1();
            gameForm.Location = this.Location;
            gameForm.StartPosition = FormStartPosition.CenterScreen;
            gameForm.FormClosing += delegate { this.Show(); };
            gameForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var helpForm = new Form3();
            helpForm.Location = this.Location;
            helpForm.StartPosition = FormStartPosition.CenterScreen;
            helpForm.FormClosing += delegate { this.Show(); };
            helpForm.Show();
            this.Hide();
        }
    }
}
