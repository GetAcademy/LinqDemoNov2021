using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemoNov2021
{
    public static class StringExtensions
    {
        public static string SpaceIt(this string s)
        {
            return " " + s;
        }
    }
}
