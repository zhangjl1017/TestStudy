/*
 * 由SharpDevelop创建。
 * 用户： jianleizhang
 * 日期: 2016/7/15
 * 时间: 17:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace MySQLBatch
{
	/// <summary>
	/// Description of User.
	/// </summary>
	public class User
	{
		public string name;
		public string password;
		public string email;
		
		public User(string name,string password,string email)
		{
			this.name=name;
			this.password=password;
			this.email=email;
		}
	}
}
