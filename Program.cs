using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StringToInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(Atoi(s));
            Console.ReadKey();
        }

        static int Atoi(string s)
        {
            s = s.Trim();
            int res = 0;
            int i = 0;
            int sign = 1;
            if (string.IsNullOrEmpty(s))
                return 0;

            if (s[0] == '+' || s[0] == '-')
            {
                sign = (s[0] == '-') ? -1 : 1;
                i++;
            }

            while (i < s.Length && char.IsDigit(s[i]))
            {
                res = Num(s, i);
                if (res != int.MinValue)
                    res = res * sign;
                break;
            }
            return res;
        }

        static int Num(string s, int i)
        {
            int res = 0;
            int i1 = i;
            while (char.IsDigit(s[i]))
            {
                int digit = s[i] - '0';
                if ((res * 10 + digit) / 10 != res)
                {
                    if (i1 > 0 && s[i1 - 1] == '-')
                        res = int.MinValue;
                    else
                        res = int.MaxValue;
                    break;
                }
                else res = res * 10 + digit;
                if (i < s.Length - 1)
                    i++;
                else break;
            }
            return res;
        }
    }
}
