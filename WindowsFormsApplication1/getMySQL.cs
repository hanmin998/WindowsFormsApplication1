using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace WindowsFormsApplication1
{
   
    class getMySQL
    {
        SQLHelper helper = new SQLHelper();
        public List<string> getmoshList()
        {
            List<string> result = new List<string>();

            try
            {
                string sql = string.Format("select * from moshi");
                DataTable dt = helper.Selectinfo(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add((string)dt.Rows[i]["name"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public List<string> getexampleList(string belong)
        {
            List<string> result = new List<string>();

            try
            {
                string sql = string.Format("select * from example where belongs = '"+belong+"'");
                Debug.WriteLine(sql);
                DataTable dt = helper.Selectinfo(sql);
                Debug.WriteLine(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add((string)dt.Rows[i]["name"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string getIntroduce(string name)
        {
            string result = "";
            try
            {
                string sql = string.Format("select * from moshi where name='" + name + "'");
                DataTable dt = helper.Selectinfo(sql);
                result = (string)dt.Rows[0]["introduce"];
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
        public Image getUML(string name)
        {
            Image result = null;
            byte[] imageBytes = null;
            try
            {
                string sql = string.Format("select * from moshi where name='" + name + "'");
                DataTable dt = helper.Selectinfo(sql);
                imageBytes = (byte[])dt.Rows[0]["photo"];
                MemoryStream ms = new MemoryStream(imageBytes);
                    result = Image.FromStream(ms, true);
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
        public string getCode(string name)
        {
            string result = "";

            try
            {
                string sql = string.Format("select * from example where name='" + name + "'");
                DataTable dt = helper.Selectinfo(sql);
                result = (string)dt.Rows[0]["code"];
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
    }
}
