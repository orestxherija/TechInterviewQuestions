using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.StringsArrays
{
    class Strings
    {
        public static char first_non_rep_char(string str)
        {
            char[] s = str.ToCharArray();
            int len = s.Length;
            //HashSet<char> hashRemove = new HashSet<char>(r);
            bool[] appeared_once = new bool[128];
            bool[] appeared_twice = new bool[128];
            int src;
            for (src = 0; src < s.Length; src++)
            {
                if (!appeared_once[(int)s[src]])
                {
                    appeared_once[(int)s[src]] = true;
                }
                else
                {
                    if(appeared_once[(int)s[src]])
                    { appeared_twice[(int)s[src]] = true; }
                }
            }
            for (src = 0; src < s.Length; src++)
            {
                if (appeared_once[(int)s[src]] && !appeared_twice[(int)s[src]])
                {
                    return s[src];
                }             
            }
            return '-';
        }


        public static string removeChars(string str, string remove)
        {
            char[] s = str.ToCharArray(); // Mountain View is my town. I harrased white dude.
            char[] r = remove.ToCharArray(); //aeiou
            HashSet<char> hashRemove = new HashSet<char>(r);
            bool[] flags = new bool[128];
            int len = s.Length; //35
            int src, dst;
            for (src = 0; src < r.Length; ++src)
            {
                flags[r[src]] = true;
            }

            src = 0;
            dst = 0;

            while(src < len)
            {
                if (!flags[(int)s[src]])
                {
                    s[dst] = s[src];
                    dst = dst + 1;
                }
                else
                {
                    System.Console.WriteLine((int)s[src] + "-" + s[src]);
                }
                ++src;
            }

            Console.Out.WriteLine(new string(s, 0, dst));
            return new string(s, 0, dst);
        }


        public static string RemoveDupChars(string str)
        {
            char[] s = str.ToCharArray(); // banana
            int len = s.Length;
            int i, j, tail;
            char x;
            bool repeated = false;
            tail = 1;

            for (i = 1; i < len; ++i)
            {
                x = s[i];
                for (j = 0; j < tail; j++)
                {
                    if (s[j] == x)
                    {
                        repeated = true;
                    }
                }
                if (repeated == false)
                {

                    s[tail] = s[i];
                    tail++;
                }
                repeated = false;

            }

            return new string(s, 0, tail);
        }



        public static string RemoveDupCharsWBuffer(string str)
        {
            char[] s = str.ToCharArray(); // banana
            int len = s.Length;
            int i, j, tail;
            char x;
            tail = 1;
            bool[] flags = new bool[128];
            
            for (i = 1; i < len; ++i)
            {

                x = s[i];
                if (flags[x]!=true)
                {
                    s[tail] = s[i];
                    tail++;
                }

                flags[x] = true;
            }
                               

            return new string(s, 0, tail);
        }





    }
}
