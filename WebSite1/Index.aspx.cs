using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    DataCon dc = new DataCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = Session["name"].ToString();
        string str1 = "select * from blog";
        string str2 = "blog";
        GridView1.DataSource = dc.getds(str1, str2).Tables[str2];
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string time=DateTime.Now.ToString();            
        string str = "insert into blog(username,title,content,creattime) values('{0}','{1}','{2}','{3}')";
        string strcmd = string.Format(str,Label4.Text, TextBox1.Text, TextBox2.Text,time).ToString();
        dc.getcom(strcmd);
        Label2.Text = "插入成功";
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default2.aspx");
    }
}