using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;

public partial class Default2 : System.Web.UI.Page
{
    DataCon dc = new DataCon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == null || TextBox1.Text == "")
        {
            Label4.Text = "用户名不能为空";
            return;

        }
        else {
            string str = "select * from User where name='{0}'";
            string strcmd = string.Format(str, TextBox1.Text).ToString();
            MySqlDataReader  msdr= dc.getread(strcmd);
            if (msdr.Read()) {
                Label4.Text = "用户已经存在";
                TextBox1.Text = "";
                return;
             }
        }

        if (TextBox2.Text.Length < 6 || TextBox2.Text.Length > 16)
        {
            Label4.Text = "密码不符合标准！密码长度在6~16之间";
            return;
        }
        else
        {
            if (TextBox2.Text != TextBox3.Text)
            {
                Label4.Text = "二次密码不一致，请重新输入！";

                TextBox3.Text = "";
                TextBox2.Text = "";
                return;
            }
            else if (TextBox3.Text == TextBox2.Text)
            {
                string str = "insert into User(name,password) values('{0}','{1}')";
                string strcmd = string.Format(str, TextBox1.Text, TextBox2.Text).ToString();
                dc.getcom(strcmd);
                Label4.Text = "用户注册成功";
                Session["name"] = TextBox1.Text;
                Response.Redirect("Index.aspx");

            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "select * from User where name='{0}' and password='{1}'";
        string strcmd = string.Format(str, TextBox4.Text,TextBox5.Text).ToString();
        MySqlDataReader msdr = dc.getread(strcmd);
        if (msdr.Read())
        {
            Session["name"] = TextBox4.Text;
            Response.Redirect("Index.aspx");
            
            return;
        }
        else {
            TextBox4.Text = "";
            TextBox5.Text = "";
            Label7.Text = "用户名和密码不匹配";
        }

    }
}