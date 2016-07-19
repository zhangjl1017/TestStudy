using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1.Database
{
    class DataCon
    {
        #region  建立数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        public MySqlConnection getcon()
        {
            //string M_str_sqlcon = "Data Source=(local);Database=db_SMS;User id=sa;PWD=";
            //string M_str_sqlcon = "server=localhost;User Id=root;password=1230;Database=test";
            string constr = "server=localhost;User Id=root;password=1230;Database=test";
            MySqlConnection myCon = new MySqlConnection(constr);
            //SqlConnection myCon = new SqlConnection(M_str_sqlcon);
            return myCon;
        }
        #endregion

        #region  执行SqlCommand命令
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public void getcom(string M_str_sqlstr)
        {
            MySqlConnection sqlcon = this.getcon();
            sqlcon.Open();
            MySqlCommand sqlcom = new MySqlCommand(M_str_sqlstr, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
        }
        #endregion

        #region  创建DataSet对象
        /// <summary>
        /// 创建一个DataSet对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <param name="M_str_table">表名</param>
        /// <returns>返回DataSet对象</returns>
        public DataSet getds(string M_str_sqlstr, string M_str_table)
        {
            MySqlConnection sqlcon = this.getcon();

            MySqlDataAdapter sqlda = new MySqlDataAdapter(M_str_sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds, M_str_table);
            return myds;
        }
        #endregion

        #region  创建SqlDataReader对象
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public MySqlDataReader getread(string M_str_sqlstr)
        {
            MySqlConnection sqlcon = this.getcon();
            MySqlCommand sqlcom = new MySqlCommand(M_str_sqlstr, sqlcon);
            sqlcon.Open();
            MySqlDataReader sqlread = sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlread;
        }
        #endregion
    }
}
