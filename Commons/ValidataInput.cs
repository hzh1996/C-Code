using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commons
{
    public static class ValidataInput
    {
        public static bool IsNumber(string txt)//判断是不是数字
        {
            Regex objRegex = new Regex(@"^[0-9]*$");//是否为数字
            return objRegex.IsMatch(txt);
        }

        public static bool IsSNO(string txt)//判断是不是学号
        {
            Regex objRegex = new Regex(@"^[9][5]\d{3}$");//是否为95开头的6位数字
            return objRegex.IsMatch(txt);
        }

        public static bool IsJNum(string txt)//判断是不是学号
        {
            Regex objRegex = new Regex(@"^[1][0]\d{3}$");//是否为95开头的6位数字
            return objRegex.IsMatch(txt);
        }
        public static bool IsPWD(string txt)//判断是不是学号
        {
            Regex objRegex = new Regex(@"\d{5}$");//是否为95开头的6位数字
            return objRegex.IsMatch(txt);
        }

        public static bool IsChinese(string txt)//判断是不是汉字
        {
            Regex objRegex = new Regex(@"^[\u4e00-\u9fa5]{0,}$");
            return objRegex.IsMatch(txt);
        }

        public static bool IsGender(string txt)//判断性别
        {
            Regex objRegex = new Regex(@"^男|女");
            return objRegex.IsMatch(txt);
        }

        public static bool IsMobileNo(string txt)//判断手机号码
        {
            Regex objRegex = new Regex(@"^[1][3578]\d{9}$");
            return objRegex.IsMatch(txt);
        }

        public static bool IsEmail(string txt)//判断Email地址
        {
            Regex objRegex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return objRegex.IsMatch(txt);
        }
    }
}
