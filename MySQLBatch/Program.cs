/*
 * 由SharpDevelop创建。
 * 用户： jianleizhang
 * 日期: 2016/7/15
 * 时间: 16:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Threading;

namespace MySQLBatch
{
	class Program
	{
		public static void insertSql(ArrayList userList){
			DataCon dc = new DataCon();
			string str="insert into user(name,password,email) values ";
			for(int i=0;i<userList.Count-1;i++){
				User a=(User)userList[i];
				str+="('"+a.name+"','"+a.password+"','"+a.email+"'),";
			}
			User a1=(User)userList[userList.Count-1];
			str+="('"+a1.name+"','"+a1.password+"','"+a1.email+"')";
			dc.getcom(str);
		}
		public static void Main12(string[] args)
		{
	
			Console.WriteLine("Hello World!");
			
			
			ArrayList al = new ArrayList();
			User u=new User("zjl","admin","admin@qq.com");
			for(int i=0;i<2500;i++){
				al.Add(u);
			}
			
			/*
			DataCon dc = new DataCon();

			for(int i=0;i<10000;i++){
				User a=(User)al[0];	
			}
			*/
			
			int startTime=System.Environment.TickCount;  
			
			//Program p=new Program();
			//p.insertSql(al);
			//Thread t1 = new Thread(new ThreadStart(insertSql));
			/*
			ThreadStart childref = new ThreadStart(insertSql);
            Thread childThread1 = new Thread(childref);
            Thread childThread2 = new Thread(childref);
            Thread childThread3 = new Thread(childref);
            Thread childThread4 = new Thread(childref);
            childThread1.Start();
            childThread2.Start();
            childThread3.Start();
            childThread4.Start();
            */
            //t1.Start();
			
			
			
			//使用一条事务进行多条插入方法
			/*
			string str="insert into user(name,password,email) values ";
			for(int i=0;i<9999;i++){
				User a=(User)al[i];
				str+="('"+a.name+"','"+a.password+"','"+a.email+"'),";
			}
			User a1=(User)al[9999];
			str+="('"+a1.name+"','"+a1.password+"','"+a1.email+"')";
			dc.getcom(str);
			
			*/
			
			
			/*
			MySqlCommand sqlcom;
			MySqlConnection sqlcon = dc.getcon();
            sqlcon.Open();
            //逐条插入方法
			for(int i=0;i<10000;i++){
				User a=(User)al[i];
            	string strcmd = string.Format(str, a.name, a.password, a.email).ToString();
            	//sqlcmm.CommandText=strcmd;
				//sqlcm.ExeucteNonQuery();
            	
            	
            	sqlcom = new MySqlCommand(strcmd, sqlcon);
            	sqlcom.ExecuteNonQuery();
            	sqlcom.Dispose();
            	//dc.getcom(strcmd);
			}
			
            sqlcon.Close();
            sqlcon.Dispose();
            */
			int endTime=System.Environment.TickCount;  
 			int runTime=endTime-startTime;//(注意单位是毫秒哦！) 
			Console.WriteLine("SQL插入消耗的时间2："+runTime);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
			
		}
	}
}