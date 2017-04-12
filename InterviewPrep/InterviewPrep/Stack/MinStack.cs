using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.MinStack
{
    public class MinStack 
    {
        Stack<int> s1 = new Stack<int>();
        Stack<int> s2 = new Stack<int>();
        int tempMin = int.MaxValue;

        public void Push(int n1)
        {
            s1.Push(n1);
            if (n1 < tempMin)
            {
                tempMin = n1;
                s2.Push(tempMin);
            }
         }
        public int Pop()
        {
            int returnValue = s1.Pop();
            if (returnValue == s2.Peek()) { s2.Pop(); }
            return returnValue;
        }
        
        public int PeekMin()
        {
            return s2.Peek();
        }

    }
}
