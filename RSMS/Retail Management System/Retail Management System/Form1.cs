using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //authenticating username and password from file 
            bool check = false;
            if (File.ReadAllText(@"D:\RSMS\authentication.txt").Contains(textBox1.Text))
            {
                if (File.ReadAllText(@"D:\RSMS\authentication.txt").Contains(textBox2.Text))
                {
                    check = true;
                }
            }

            if(check == true)
            {
                this.Hide();
                Dashboard d = new Dashboard();
                d.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
