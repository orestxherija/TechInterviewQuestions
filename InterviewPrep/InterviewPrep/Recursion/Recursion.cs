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
    }
}
