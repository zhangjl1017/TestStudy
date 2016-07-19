using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Database;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //update 表名 set 字段1=text1，字段2=text2，字段3=text3 where 条件
        /**
         * Delete FROM patient WHERE PatientNo="+Pno
         * 
        */
        DataCon dc = new DataCon();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet1.user' table. You can move, or remove it, as needed.
            this.userTableAdapter1.Fill(this.testDataSet1.user);
            // TODO: This line of code loads data into the 'testDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.testDataSet.user);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "insert into User(name,password,email) values('{0}','{1}','{2}')";
            string strcmd = string.Format(str, textBox1.Text, textBox2.Text, textBox3.Text).ToString();
            dc.getcom(strcmd);
            count++;
            label5.Text =count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str1 = "select * from user";
            string str2 = "user";
            dataGridView1.DataSource = dc.getds(str1, str2).Tables[str2];
            count++;
            label5.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Delete FROM user WHERE id={0}";

            string str2 = string.Format(str, int.Parse(textBox4.Text));
            dc.getcom(str2);
            count++;
            label5.Text = count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "update user set name='{0}'，password='{1}'，email='{2}' where id={3}";
            string str2 = string.Format(str, textBox1.Text, textBox2.Text, textBox3.Text,int.Parse(textBox4.Text)).ToString();
            dc.getcom(str2);
            count++;
            label5.Text = count.ToString();
        }
    }
}
