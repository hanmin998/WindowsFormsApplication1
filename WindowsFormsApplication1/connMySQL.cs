using System;
using MySql.Data.MySqlClient;//导入用MySql的包
using System.Data;
//引用DataTable


namespace WindowsFormsApplication1
{
    public class DBHelper
    {
        protected string database = "shemo";
        protected string local = "127.0.0.1";
        protected string user = "root";
        protected string password = "root";
        /// <summary>
        /// 得到连接对象
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConn()
        {
            MySqlConnection mysqlconn = new MySqlConnection("Database='" + database + "';Data Source='" + local + "';User Id='" + user + "';Password='" + password + "';Charset=utf8");
            return mysqlconn;
        }
    }


    public class SQLHelper : DBHelper
    {
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        /// 
        Form1 form;
        public DataTable Selectinfo(string sql)
        {
            MySqlConnection mysqlconn = null;
            MySqlDataAdapter sda = null;
            DataTable dt = null;
            try
            {
                mysqlconn = base.GetConn();

                sda = new MySqlDataAdapter(sql, mysqlconn);
                dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 增删改操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>执行后的条数</returns>
        public int AddDelUpdate(string sql)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                conn = base.GetConn();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;


            }
            catch (Exception)
            {

                throw;
            }

        }
        public int execCommand(MySql.Data.MySqlClient.MySqlCommand command)
        {
            MySqlCommand cmd = command;
            MySqlConnection conn = null;

            try
            {
                conn = base.GetConn();
                conn.Open();
                cmd.Connection = conn;
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
