using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReflectTest.Model;
using ReflectTest.Business;

namespace ConsoleApplicationStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Num = "afjsdfajs12";
            p.Address = "zjl0405@hotmail.com";
            Console.Write(PersonCheck.GetErrorMessage(p));
            
            Console.WriteLine();
            string str = "insert into User(name,password,email) values({0},{1},{2})";
            string P_str_UserName="12";
            string P_str_UserPwd="12";
            string P_str_UserRight="12";
            string strcmd=string.Format(str,P_str_UserName,P_str_UserPwd,P_str_UserRight).ToString();
            Console.WriteLine(strcmd);
            Console.ReadKey(true);
        }
    }
}
