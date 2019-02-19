using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utillib
{
    public class Check
    {
        /// <summary>
        ///检验字符串是否为null 或者空值
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsEmpty(string Value) {
            if (string.IsNullOrWhiteSpace(Value))
                return true;
            else
                return false;
        }

    }
}
