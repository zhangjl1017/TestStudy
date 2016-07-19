using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1.Database
{
    class DataOperate
    {
 
        DataCon datacon = new DataCon();//声明DataCon类的一个对象，以调用其方法
        #region  文件压缩
        /// <summary>
        /// 文件压缩
        /// </summary>
        /// <param name="M_str_DFile">压缩前文件及路径</param>
        /// <param name="M_str_CFile">压缩后文件及路径</param>
        public void compressFile(string M_str_DFile, string M_str_CFile)
        {
            if (!File.Exists(M_str_DFile)) throw new FileNotFoundException();
            using (FileStream sourceStream = new FileStream(M_str_DFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[sourceStream.Length];
                int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);
                if (checkCounter != buffer.Length) throw new ApplicationException();
                using (FileStream destinationStream = new FileStream(M_str_CFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (GZipStream compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true))
                    {
                        compressedStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
        #endregion

        #region  验证文本框输入为数字
        /// <summary>
        /// 验证文本框输入为数字
        /// </summary>
        /// <param name="M_str_num">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateNum(string M_str_num)
        {
            return Regex.IsMatch(M_str_num, "^[0-9]*$");
        }
        #endregion

        #region  验证文本框输入为电话号码
        /// <summary>
        /// 验证文本框输入为电话号码
        /// </summary>
        /// <param name="M_str_phone">输入字符串</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validatePhone(string M_str_phone)
        {
            return Regex.IsMatch(M_str_phone, @"\d{3,4}-\d{7,8}");
        }
        #endregion

        #region  验证文本框输入为传真号码
        /// <summary>
        /// 验证文本框输入为传真号码
        /// </summary>
        /// <param name="M_str_fax">输入字符串</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateFax(string M_str_fax)
        {
            return Regex.IsMatch(M_str_fax, @"86-\d{2,3}-\d{7,8}");
        }
        #endregion

        #region  添加新用户
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="P_str_UserName">用户名</param>
        /// <param name="P_str_UserPwd">用户密码</param>
        /// <param name="P_str_UserRight">用户权限</param>
        /// <returns>返回一个int类型的值</returns>
        public int InsertUser(string P_str_UserName, string P_str_UserPwd, string P_str_UserRight)
        {
            MySqlConnection sqlcon = datacon.getcon();
            MySqlCommand sqlcom = new MySqlCommand("proc_insertUser", sqlcon);
            string str = "insert into User(name,password,email) values('{0}','{1}','{2}')";
            //string strcmd=string.Format(str,P_str_UserName,P_str_UserPwd,P_str_UserRight);
            string strcmd = string.Format(str, P_str_UserName, P_str_UserPwd, P_str_UserRight).ToString();
            MySqlCommand mycmd = new MySqlCommand(strcmd,sqlcon);
            sqlcon.Open();
            try
            {
                if (mycmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("数据插入成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                mycmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return 1;
        }
        #endregion

        
    }
}
