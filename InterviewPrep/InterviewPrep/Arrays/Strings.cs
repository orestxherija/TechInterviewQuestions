using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace InterviewPrep.StringsArrays
{
    class Strings
    {
        public static Boolean StringContainsAllUnique(string str)
        {
            bool[] used = new bool[128];
            int len = str.Length;
            int i = 0;
            for (i=0;i< len; i++)
            {
                if (used[str[i]]) { return false; }
                used[str[i]] = true;
            }
            return true;
        }

        /// <summary>
        /// Remove Duplicated Characters without using any buffer.
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        /// TEST CASE: "aaaaa", "aaabb", "abdce", "a"
        public static string RemoveDuplicatedCharacters(string stringInput)
        {
            if (stringInput == null) return null;
            if (stringInput.Length <= 1) return stringInput;
            char[] c = stringInput.ToCharArray();
            int tail = 0;
            int i, j;
            for (i = 0; i < c.Length; i++)
            {
                for (j = 0; j < i+1; j++)
                {
                    if ((c[i] == c[j]) && (i!= j))
                    {
                        break;
                    }
                    if (j==i)
                    {
                        c[tail] = c[i];
                        tail += 1;
                    }
                }
            }       
            return new string (c, 0, tail);
        }


        public static int StringToSignedInteger(string str)
        {
            int i;
            int digit;
            double integer ;
            bool isNeg = false;
            i = 0;
            integer = 0.0;
            digit = str.Length-1;
                        
            if (str[0] == '-')
            {
                isNeg = true;
                i = 1;
                digit = digit - 1;
            }
            while (i<str.Length)
            { 
                integer = integer + (double)(str[i] - '0') * Math.Pow(10.0, (double)digit);
                i += 1;
                digit -= 1;
            }
            if (isNeg) { integer = integer * (-1.0); }
            return (int)integer;
        }

        
        public static string IntegerToString(int integer)
        {
            int i;
            int absInteger;
            string reversedStrr;
            absInteger= Math.Abs(integer);
            i = 0;
            Stack<char> charStack = new Stack<char>();
            
            while (absInteger > 1)
            {
                charStack.Push( (char)((absInteger % 10) + '0') );
                absInteger = absInteger / 10;
                i += 1 ;
            }
            if (integer < 0)
            {
                charStack.Push( '-' );
            }
            StringBuilder str = new StringBuilder();
            while (charStack.Count > 0)
            {
                str.Append(  charStack.Pop());
            }
            return str.ToString();
        }

    

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
