using System;
using System.Collections.Generic;
using System.Text;

namespace StrEnd
{
    public static  class StringHelper
    {
        public static bool StrEnd(string firstStr, string secondStr)
        {
            firstStr = firstStr.Trim();
            secondStr = secondStr.Trim();

            if (firstStr.Length < secondStr.Length)
                return false;

            var firstStrEnd = firstStr.Substring(firstStr.Length - secondStr.Length);

            return firstStrEnd == secondStr;
        }
    }
}
