using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Recursion
{
    class Recursion
    {
        public static int WaysToExit(int x, int y)
        {
            if (x==0 || y == 0)
            {
                return 1;
            }
            else
            {
                return (WaysToExit(x - 1, y) + WaysToExit(x , y-1));
            }
        }

        public static bool IsBlocked(int x, int y)
        {
            return false;
        }


        /// <summary>
        /// List of either 0 or 1: 0 means right, 1 means down. 
        /// </summary>
        public static void WaysToExitWObstacle(int x, int y, StringBuilder temp, List<string> paths)
        {
            if (x == 0 && y == 0)
            {
                Console.WriteLine(temp);
                
            }
            else if (IsBlocked(x, y))
            {
                temp.Length -= 1;
            }
            else {
                if (x == 0 && y!=0) 
                {
                    temp.Append(1);
                    WaysToExitWObstacle(x, y-1, temp, paths);
                    if (temp.Length > 0) { temp.Length -= 1; }
                }
                else if (y == 0 && x!=0)
                {
                    temp.Append(0);
                    WaysToExitWObstacle(x - 1, y, temp, paths);
                    if (temp.Length > 0) { temp.Length -= 1; }

                }
                else
                {
                    temp.Append(0);
                    WaysToExitWObstacle(x - 1, y, temp, paths);
                    if (temp.Length > 0) { temp.Length -= 1; }
                    temp.Append(1);
                    WaysToExitWObstacle(x, y - 1, temp, paths);
                    if (temp.Length > 0) { temp.Length -= 1; }

                }
            }
        }


        public static void CombiParentheses(int open, int close, StringBuilder str)
        {
            if (open == 0 && close == 0)
            {
                Console.WriteLine(str.ToString());
                str.Clear();
            }
            if (open > 0) //when you open a new parentheses, then you have to close one parentheses to balance it out.
            {                
                CombiParentheses(open - 1, close + 1, str.Append("{"));
            }
            if (close > 0)
            {                
                CombiParentheses(open , close - 1, str.Append("}"));
            }
        }





    }
}
