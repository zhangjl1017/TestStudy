/*
 * 由SharpDevelop创建。
 * 用户： jianleizhang
 * 日期: 2016/7/19
 * 时间: 10:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;  
using System.Collections.Generic;  
using System.ComponentModel;  
using System.Data;   
using System.Linq;  
using System.Text;  
using System.Net.Sockets;  
using System.Net;  
using System.Threading;  

namespace ServerServer
{
	class Program
	{
		private static byte[] result = new byte[1024];  
        private static int myProt = 8885;   //端口  
        static Socket serverSocket;  
        static void Main(string[] args)  
        {  
            //服务器IP地址  
            Console.WriteLine("Server begining................");
            Console.ReadKey(true);
            /*
            IPAddress ip = IPAddress.Parse("127.0.0.1");  
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口  
            serverSocket.Listen(10);    //设定最多10个排队连接请求  
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());  
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(ListenClientConnect);  
            myThread.Start();  
            Console.ReadKey(true);  
            */
        }  
  
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private static void ListenClientConnect()  
        {  
            while (true)  
            {  
                Socket clientSocket = serverSocket.Accept();  
                clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));  
                Thread receiveThread = new Thread(ReceiveMessage);  
                receiveThread.Start(clientSocket);  
            }  
        }  
  
        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void ReceiveMessage(object clientSocket)  
        {  
            Socket myClientSocket = (Socket)clientSocket;  
            while (true)  
            {  
                try  
                {  
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(result);  
                    Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(result, 0, receiveNumber));  
                }  
                catch(Exception ex)  
                {  
                    Console.WriteLine(ex.Message);  
                    myClientSocket.Shutdown(SocketShutdown.Both);  
                    myClientSocket.Close();  
                    break;  
                }  
            }  
        }  
	}
}