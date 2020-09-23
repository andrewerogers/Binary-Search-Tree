using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LevenshteinDistance("abasdf","a34ffffa"));
        }



        public static int LevenshteinDistance(string str1, string str2)
        { 
            return Helper(str1, str2, str1.Length, str2.Length);
        }

        private static int Helper(string str1, string str2, int len1, int len2)
        {
            // Base cases for recursion
            if (len1 == 0)
            {
                return len2;
            }
            else if (len2 == 0)
            {
                return len1;
            }

            // There are three cases here; we can either remove the current character from string 2, we can
            // insert the current character in string 1 into string 2, or we can substitute the current character. 
            int cost = 0;
            if (!str1[len1 - 1].Equals(str2[len2 - 1]))
            {
                cost = 1;
            }

            int[] options = {Helper(str1, str2, len1, len2-1)+1, Helper(str1, str2, len1-1, len2)+1,
                                                Helper(str1, str2, len1-1, len2-1)+cost};

            return options.Min();
        }
    }
}
