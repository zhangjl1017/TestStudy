/*
 * 由SharpDevelop创建。
 * 用户： jianleizhang
 * 日期: 2016/7/18
 * 时间: 14:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Collections;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
namespace MySQLBatch
{
	/// <summary>
	/// Description of ThreadCreationProgram.
	/// </summary>
	public class ThreadCreationProgram
	{
		//static AutoResetEvent mEvent = new AutoResetEvent(false);
		static int startTime=System.Environment.TickCount;
		 public static void insertSql(object data)
        {
		 	ArrayList userList = data as ArrayList;
            DataCon dc = new DataCon();
			string str="insert into user(name,password,email) values ";
			for(int i=0;i<userList.Count-1;i++){
				User user=(User)userList[i];
				str+="('"+user.name+"','"+user.password+"','"+user.email+"'),";
			}
			User userTemp=(User)userList[userList.Count-1];
			str+="('"+userTemp.name+"','"+userTemp.password+"','"+userTemp.email+"')";
			dc.getcom(str);
			int endTime=System.Environment.TickCount;  
 			int runTime=endTime-startTime;//(注意单位是毫秒哦！) 
			Console.WriteLine("SQL插入消耗的时间2："+runTime/1000.0);
			Console.WriteLine("zjl==========================zjl");
			//mEvent.WaitOne(); 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Program is begining:");
            ArrayList userList = new ArrayList();
			User u=new User("zjl","admin","admin@qq.com");
			for(int i=0;i<10000;i++){
				userList.Add(u);
			}
			
			
            Thread childThread1 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread1.Start(userList);
            /*
            Thread childThread2 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread2.Start(userList);
            Thread childThread3 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread3.Start(userList);
            Thread childThread4 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread4.Start(userList);
            Thread childThread5 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread5.Start(userList);
            Thread childThread6 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread6.Start(userList);
            Thread childThread7 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread7.Start(userList);
            Thread childThread8 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread8.Start(userList);
            Thread childThread9 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread9.Start(userList);
            Thread childThread10 = new Thread(new ParameterizedThreadStart(insertSql));
            childThread10.Start(userList);
            */
           // mEvent.Set();  
            
			
			Console.WriteLine("Press any key to continue . . .");
			Console.ReadKey(true);
        }
	}
}
