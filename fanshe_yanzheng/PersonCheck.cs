﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectTest.Model;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ReflectTest.Business
{
    public class PersonCheck
    {
        #region 获取所有的错误提示
        public static string GetErrorMessage(Person person)
        {
            PropertyInfo[] propertyInfos = person.GetType().GetProperties(); // 获取一个类的所有属性
            Console.WriteLine(person.GetType());
            
            string errorMsg = string.Empty;

            //对所有公用属性（Name,Num,Address)遍历
            foreach (PropertyInfo info in propertyInfos)
            {
            	Console.WriteLine(info);
                errorMsg += GetSignalPropertity(info, person);
            }
            return errorMsg;
        }
        #endregion

        // 获取单个公共属性的Attribute.也就是model类里面的[PersonCheck]信息
        private static string GetSignalPropertity(PropertyInfo propertyInfo, Person person)
        {
            // 因为对于此示例，每个Properties(属性)只有一个Attribute(标签),所以用了first()来获取，
            // 不过有一点，就是必须在属性里面添加[PersonCheck]标签，但是可以不设置表情里面的字段.因为没有的.GetCustomAttributes()返回为null.指向first会报错.
           // for(int i=0;i<sizeof(propertyInfo);i++){
            
            PersonCheckAttribute attribute = propertyInfo.GetCustomAttributes(true).First() as PersonCheckAttribute;
            
            string errorMsg = string.Empty;
            object[] o=null;

            //以下的if语句是判断标签里面的设置，设置了什么就执行什么数据校验
            if (attribute.CheckEmpty)
            {
                string obj = propertyInfo.GetValue(person,o) as string;
                if (string.IsNullOrEmpty(obj))
                {
                    errorMsg += Environment.NewLine + string.Format("{0} 不能为空", propertyInfo.Name);
                }
            }

            if (attribute.CheckMaxLength)
            {
                string obj = propertyInfo.GetValue(person,o) as string;
                if (obj != null && obj.Length > attribute.MaxLength)
                {
                    errorMsg += Environment.NewLine + string.Format("{0} 最大长度为{1}", propertyInfo.Name, attribute.MaxLength);
                }
            }

            // 对于判断数字邮箱都可以通过正则表达式
            if (attribute.CheckRegex)
            {
                string obj = propertyInfo.GetValue(person,o) as string;
                Regex regex = new Regex(attribute.RegexStr);
                if (obj != null && !regex.IsMatch(obj))
                {
                    errorMsg += Environment.NewLine + string.Format("{0} 格式不对", propertyInfo.Name);
                }
            }

            return errorMsg;
        }
    }
}