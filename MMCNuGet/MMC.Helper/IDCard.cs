using System;
using System.Collections.Generic;
using System.Text;

namespace MMC.Helper
{
    /// <summary>
    /// 身份证帮助类
    /// </summary>
    public static class IDCard
    {
        /// <summary>
        /// 是否成年
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsAdult(string input)
        {
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                if (input.Length != 15 && input.Length != 18)
                {
                    return false;
                }

                string birthday;
                if (input.Length == 18)
                {
                    birthday = input.Substring(6, 4) + "-" + input.Substring(10, 2) + "-" + input.Substring(12, 2);
                }
                else
                {
                    birthday = "19" + input.Substring(6, 2) + "-" + input.Substring(8, 2) + "-" + input.Substring(10, 2);
                }

                DateTime birthDate = DateTime.Parse(birthday);
                DateTime nowDateTime = DateTime.Now;
                int age = nowDateTime.Year - birthDate.Year;
                if (nowDateTime.Month < birthDate.Month || (nowDateTime.Month == birthDate.Month && nowDateTime.Day < birthDate.Day))
                {
                    age--;
                }

                return 18 <= age ;
            }
            return false;
        }
    }
}
