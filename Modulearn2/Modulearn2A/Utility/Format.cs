using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modulearn2A.Utility
{
    public static class Format
    {
        public static bool IsEmailFormat(string emailStr)
        {
            return Regex.IsMatch(emailStr,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
