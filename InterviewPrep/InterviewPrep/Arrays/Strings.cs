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


        public static string RemoveChars(string str, string remove)
        {
            char[] stringArray = str.ToCharArray(); // Mountain View is my town. I harrased white dude.
            char[] remArray = remove.ToCharArray(); //aeiou
            bool[] flags = new bool[128];
            int i, src, dst;
            for (i = 0; i < remArray.Length; i++)
            {
                flags[remArray[i]] = true;
            }
            src = 0;
            dst = 0;
            for (src=0;src< stringArray.Length ;src ++)
                if (!flags[(int)stringArray[src]])
                {
                    stringArray[dst] = stringArray[src];
                    dst = dst + 1;
                }
            return new string (stringArray, 0,dst);
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
