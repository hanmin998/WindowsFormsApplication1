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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SQLHelper helper = new SQLHelper();

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytes = null;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                bytes = File.ReadAllBytes(file);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "insert into moshi(photo) values(@picture)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@picture", MySql.Data.MySqlClient.MySqlDbType.Blob).Value = bytes;
                int affectedrows = helper.execCommand(cmd);
                if (affectedrows > 0)
                {
                    Debug.WriteLine("插入成功");
                }
                else
                {
                    Debug.WriteLine("插入失败");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "insert into example(code) values(@code)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@code", MySql.Data.MySqlClient.MySqlDbType.LongText).Value = richTextBox1.Text;

            int affectedrows = helper.execCommand(cmd);
            if (affectedrows > 0)
            {
                Debug.WriteLine("插入成功");
            }
            else
            {
                Debug.WriteLine("插入失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "insert into moshi(introduce) values(@introduce)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@introduce", MySql.Data.MySqlClient.MySqlDbType.LongText).Value = richTextBox1.Text;
            int affectedrows = helper.execCommand(cmd);
            if (affectedrows > 0)
            {
                Debug.WriteLine("插入成功");
            }
            else
            {
                Debug.WriteLine("插入失败");
            }
            
        }
    }
}
