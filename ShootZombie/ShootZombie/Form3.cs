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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainForm = new Form2();
            mainForm.Location = this.Location;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.FormClosing += delegate { this.Show(); };
            mainForm.Show();
            this.Close();
        }
    }
}
