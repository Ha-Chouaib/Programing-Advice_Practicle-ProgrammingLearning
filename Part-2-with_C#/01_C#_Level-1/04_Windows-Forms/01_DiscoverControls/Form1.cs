using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FirstWinFormsPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void On_Enter(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Black;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Text = "ALLAH Almosta3an";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 