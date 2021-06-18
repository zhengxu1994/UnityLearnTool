using System;
using System.Text;

namespace ZFramework
{
    public static class StringUtils
    {
        private static StringBuilder sb = new StringBuilder();

        public static StringBuilder Builder
        {
            get
            {
                sb.Clear();
                return sb;
            }
        }

        public static string Append(this string a,string b)
        {
            StringBuilder sb = Builder;
            sb.Append(a);
            sb.Append(b);
            return sb.ToString();
        }
    }
}