using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        getMySQL getData = new getMySQL();
        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            string str = this.comboBox1.Text;
        }
              
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            List<string> exampleList = getData.getexampleList(comboBox1.Text);

            foreach (string i in exampleList)
            {
                comboBox2.Items.Add(i);
            }
            string intro = getData.getIntroduce(comboBox1.Text);
            richTextBox1.Text = intro;
            pictureBox1.Image = getData.getUML(comboBox1.Text);
            panel1.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {        
                string code = getData.getCode(comboBox2.Text);
                richTextBox2.Text = code;
                richTextBox2.Text = code;
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        { 
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            List<string> moshiList = getData.getmoshList();
            foreach(string i in moshiList)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }
    }
}
