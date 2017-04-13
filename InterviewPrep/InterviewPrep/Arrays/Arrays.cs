using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Dequeue;
using InterviewPrep.Dequeue.Generic;

namespace InterviewPrep.Arrays
{
    public class DoubleArray
    {
        public double[] array;

        public DoubleArray(double[] input)
        {
            this.array = input;
        }

        public DoubleArray(string[] input)
        {
            List<double> temp = new List<double>();

            foreach (string s in input)
            {
                temp.Add(double.Parse(s));    
            }
            array = temp.ToArray();
        }

        public static int BinarySearch(int[] array, int lower, int upper, int target)
        {       
            if (upper <= lower)
            {
                if (array[upper] == target)
                {
                    return upper;
                }
                else
                {
                    return -1;
                }
            }

            int center = (lower + upper) / 2;
            if (array[center] == target)
            {
                return center;
            }
            else if (array[center]>target)
            {
                return BinarySearch(array, lower, center-1, target);
            }
            else
            {
                return BinarySearch(array, center+1, upper, target);
            }
        }

        public static int BinarySearchIter(int[] array, int lower, int upper, int target)
        {
            while (lower != upper) {

                int center = (lower + upper) / 2;

                if (array[center] <target)
                {
                    lower = center+1;
                }
                
                else if (array[center] == target)
                {
                    return center;
                }

                else {
                    upper = center -1;
                }
            }

            if (array[lower] == target)
            {
                return lower;
            }
            else {
                return -1;
            }
        }

        public static int Factorial(int n)
        {
            int fact = 1;
            while (n > 0)
            {
                fact = fact * n;
                n = n - 1;
            }

            return fact;
        }

        public static void PrintPermutation(int[] arr)
        {
            int iteration_number = Factorial(arr.Length);
            int temp;
            int temp2;
            while (iteration_number>0)
            {
                temp = arr[(iteration_number-1)%arr.Length];
                temp2 = arr[iteration_number%arr.Length];
                arr[iteration_number%arr.Length] = temp;
                arr[(iteration_number - 1)%arr.Length] = temp2;
                Console.WriteLine(string.Join(",", arr));              
                iteration_number = iteration_number - 1;
            }
            Console.In.Read();
        }


        public static void Permute (String str)
        {
            int length = str.Length;
            Boolean[] used = new Boolean[length];
            StringBuilder outt = new StringBuilder();
            char[] charr = str.ToCharArray();

            DoPermute(charr, outt, used, 0);
        }


        public static void DoPermute (char[] charr, StringBuilder outt, Boolean[] used, int ind)
        {
            int i;
            if (ind == (charr.Length))
            {
                Console.WriteLine(outt.ToString());
                return;
            }
            for (i=0; i<charr.Length; i++){
                if (used[i] == false)
                {
                    outt.Append(charr[i]);
                    used[i] = true;
                    DoPermute(charr, outt, used, ind + 1);
                    used[i] = false;
                    outt.Length -= 1;
                }
            }

        }


        public static int[,] compute_accum_mat(int[,] original_mat)
        {
            int[,] finalMatrix = new int[original_mat.GetLength(0), original_mat.GetLength(1)];
            finalMatrix[0, 0] = original_mat[0, 0];
            for (int i = 0; i < original_mat.GetLength(0); i++)
            {
                for (int j = 0; j < original_mat.GetLength(1); j++)
                {
                    if (i > 0 && j > 0)
                    {
                        finalMatrix[i, j] = finalMatrix[i-1,j]+ finalMatrix[i,j-1]- finalMatrix[i-1,j-1]+original_mat[i,j];
                    }
                    else if (i > 0 && j == 0)
                    {
                        finalMatrix[i, j] = finalMatrix[i - 1, j]  + original_mat[i, j];
                    }
                    else if (j > 0 && i == 0)
                    {
                        finalMatrix[i, j] = finalMatrix[i, j - 1] + original_mat[i, j];
                    }
                }
            }
            return finalMatrix;
        }


        public static int SquareSumBewteenTwoPoints(int[,] original_mat, int x1 , int y1, int x2, int y2 )
        {
            int[,] accumMat = compute_accum_mat(original_mat);
            int xBig = Math.Max(x1, x2);
            int xSmall = Math.Min(x1, x2);
            int yBig = Math.Max(y1, y2);
            int ySmall = Math.Min(y1, y2);
            return (accumMat[xBig, yBig] - accumMat[xSmall, yBig] - accumMat[xBig, ySmall] + accumMat[xSmall, ySmall]); 
        }


        public static int ReturnBiggestSquareSize(int[,] original_mat)
        {
            int biggestSize = 1;
            int tempSum;
            int[,] accumMat= compute_accum_mat(original_mat);
            for ( int i = 0; i < original_mat.GetLength(0); i++)
            {
                for (int j = 0; j < original_mat.GetLength(1); j++)
                 {
                    for (int k=1; (((i+ k) < original_mat.GetLength(0)) &&((j+ k)< original_mat.GetLength(1)) ); k++ )
                    {
                        tempSum = SquareSumBewteenTwoPoints(original_mat,i, j, i + k, j + k);
                        if (tempSum == k*k)
                        {
                            if (k > biggestSize) 
                            { biggestSize = k; }
                        }
                    }
                }
            }

            return biggestSize+1;
        }


        public static int LargestSquareMatrixOfOne(int[,] original_mat)
        {
            int[,] AccumulatedMatrix = new int[original_mat.GetLength(0), original_mat.GetLength(1)];
            AccumulatedMatrix[0, 0] = original_mat[0, 0];
            int biggestSize = 1;
            for (int i = 0; i < original_mat.GetLength(0); i++)
            {
                for (int j = 0; j < original_mat.GetLength(1); j++)
                {
                    if (i > 0 && j > 0)
                    {
                        if (original_mat[i, j] == 1)
                        {
                            AccumulatedMatrix[i, j] = Math.Min(AccumulatedMatrix[i - 1, j - 1], (Math.Min(AccumulatedMatrix[i - 1, j], AccumulatedMatrix[i, j - 1]))) + 1;
                            if (AccumulatedMatrix[i, j] > biggestSize)
                            {
                                biggestSize = AccumulatedMatrix[i, j];
                            }
                        }
                        else
                        {
                            AccumulatedMatrix[i, j] = 0;
                        }
                    }
                    else if ( (i > 0 && j == 0) || (j > 0 && i == 0))
                    {
                        if (original_mat[i, j] == 1) { AccumulatedMatrix[i, j] = 1; }
                        else { AccumulatedMatrix[i, j] = 0; }
                    }
                }
            }
            return biggestSize;
        }



        public static int[,] mindi_loop(int[,] original_mat)
        {
            int[,] mindi_mat = new int[original_mat.GetLength(0), original_mat.GetLength(1)];
            for (int i = 0; i < original_mat.GetLength(0); i++)
            {
                for (int j = 0; j < original_mat.GetLength(1); j++)
                {
                    if (i > 0 && j > 0)
                    {
                        mindi_mat[i, j] = Math.Min(mindi_mat[i - 1, j], mindi_mat[i, j - 1]) + original_mat[i, j];         
                    }
                    else if (i > 0 && j < 1)
                    {
                        mindi_mat[i, j] = mindi_mat[i - 1, j] + original_mat[i, j];
                    }
                    else if (j > 0 && i < 1)
                    {
                        mindi_mat[i, j] = mindi_mat[i, j - 1] + original_mat[i, j];
                    }
                    else if (i==0 && j == 0)
                    {
                        mindi_mat[i, j] = original_mat[i, j];
                    }
                }
            }
            return mindi_mat;
        }   





        public static Tuple<int,int> find_X( int[,] matrix, int X)
        {
            int i = 0, j = 0;
            while (i < matrix.GetLength(0) && matrix[i, 0] <= X )
            {
                
                while (i < matrix.GetLength(1) && matrix[i, j] <= X)
                {
                    if (matrix[i, j] == X)
                    {
                        return Tuple.Create(i, j);    
                    }
                    j++;
                }
                i++; j = 0;
            }
            return null;
        }



        public static HashSet<string> ZeroOneCombination(string set, StringBuilder subset, HashSet<string> allSubsets)
        {
            int i;
            if (subset.Length == set.Length)
            {
                string temp = subset.ToString();
                allSubsets.Add(temp);
                return allSubsets;
            }
            for (i = 0; i < 2; i++)
            {
                subset.Append(i.ToString());
                HashSet<string> temp2 = ZeroOneCombination(set, subset, allSubsets);
                allSubsets.UnionWith(temp2);
                subset.Length -= 1; 
            }
            return allSubsets; // Challenge: how to return one final allSubsets?
        }


        public static int Ways2PayNCents(int n)
        {
            int numberOfWays=0;
            int cent, nickel, dime, quarter;
            for (quarter = 0; quarter <= n/25; quarter++)
            {
                for (dime = 0; dime <= n/10; dime++)
                {
                    for (nickel = 0; nickel <= n/5; nickel++)
                    {
                        cent = n - (quarter * 25 + dime * 10 + nickel * 5);
                        if (cent >= 0)
                        {
                            numberOfWays += 1;
                            Console.WriteLine("{0},{1},{2},{3}", quarter, dime, nickel, cent);
                        }                   
                    }
                }
            }
            return numberOfWays;            
        }



        /// <summary>
        /// We are going to fill the biggest coins one by one.
        /// </summary>
        /// <param name="n"> the amount of money </param>
        public static void MakeChange (int n)
        {
            int n1, n2, n3; // residual of amount after each coin
            int quarter, dime, nickel; // These are number of 25c, 10c, 5c, 1c
            for (quarter = n/25; quarter >= 0; quarter--)
            {
                n1 = n - 25 * quarter;
                for (dime = n1/10; dime >= 0; dime--)
                {
                    n2 = n1 - 10 * dime;
                    for (nickel = n2/5; nickel >= 0 && (n2 - 5*nickel) >= 0; nickel--)
                    {
                        n3 = n2 - 5 * nickel;
                        Console.WriteLine("{0},{1},{2},{3}", quarter, dime, nickel, n3); // n3 becomes the number of cent.
                    }
                }
            }
        }



        public static Stack<int> SpiralTraverse(int[,] arr)
        {
            Stack<int> trav = new Stack<int>();
            int m = arr.GetLength(0)-1; //end point (m,n)
            int n = arr.GetLength(1)-1;
            int k = 0; int l = 0; // starting point (k,l)
            int i; //index
            while( k <= m && l <= n)
            {
                for (i= l; i <= n; i++)
                {
                    trav.Push((int)arr[k, i]);
                }
                k++;
                for (i = k; i <= m; i++)
                {
                    trav.Push((int)arr[i, n]);
                }
                n--;
                if (k < m)
                {
                    for (i= n;i>= l; i--)
                    {
                        trav.Push((int)arr[m,i]);
                    }
                    m--;
                }
                if (l < n)
                {
                    for (i= m;i>= k; i--)
                    {
                        trav.Push((int)arr[i, l]);
                    }
                    l++;
                }
            }
            return trav;
        }

        public static void printKMax(int[] arr, int n, int k)
        {
            Deque<int> qi = new Deque<int>();
            int i;
            for (i=0;i< k; i++) // first window of the array
            {
                while ((qi.Count > 0) && (arr[i] >= arr[qi.PeekBack()]))
                {
                    qi.PopBack();
                }
                qi.PushBack(i);
            }
           
            for(i=k ;i< n; ++i)
            {
                Console.WriteLine(arr[qi.PeekFront()]); // the front item is the largest element in previous window.
                while (qi.Count > 0 && qi.PeekFront() <= i - k) // this is where the comparison is happening!
                {
                    qi.PopFront(); //now it's out of its window k 
                }
                while(qi.Count>0 && arr[i]>=arr[qi.PeekBack()]) // repeat
                {
                    qi.PopBack();
                }
                qi.PushBack(i);
            }

            Console.WriteLine(arr[qi.PeekFront()]);
        }

        public static void FindSameProductPairs(int[] arr)
        {
            int i, j, prod;
            int n = arr.Length;
            Tuple<int, int> t1;
            Dictionary<int, List<Tuple<int, int>>> d = new Dictionary<int, List<Tuple<int, int>>>() ;
            for (i=0;i<(n-1); i++)
            {
                for (j=(i+1);j<n;j++)
                {
                    prod = arr[i] * arr[j];

                    t1 = Tuple.Create(arr[i], arr[j]);

                    if (d.ContainsKey(prod))
                    {
                        d[prod].Add(t1);
                    }
                    else
                    {
                        List<Tuple<int, int>> emptyList = new List<Tuple<int, int>>();
                        d.Add(prod, emptyList);
                        d[prod].Add(t1);
                    }
                }
            }

            foreach (int product in d.Keys)
            {
                Console.Out.Write(product + "-");
                foreach (Tuple<int, int> tup in d[product])
                {
                    Console.Out.Write(tup.Item1 + "," + tup.Item2 + " || ");
                }
                Console.Out.WriteLine("");
            }

            
        }









    }

    public class GenericArray<T> where T : IComparable
    {
        public static void MergeSort(T[] arr, int start, int end)
        {
            int mid = (int)((end + start) / 2);
            if (end <= start)
            {
                return;
            }

            MergeSort(arr, start, mid - 1);
            MergeSort(arr, mid, end);
            Merge(arr, 0, mid, end);
        }

        private static void Merge(T[] arr, int start, int mid, int end)
        {
            T[] final = new T[end - start + 1];
            int firstCounter = 0, secondCounter = mid, index = 0;

            while (firstCounter <= (mid-1) && secondCounter <= end)
            {
                if (arr[firstCounter].CompareTo(arr[secondCounter]) > 0)
                {
                    final[index++] = arr[secondCounter++];
                }
                else
                {
                    final[index++] = arr[firstCounter++];
                }
            }            
        }










    }
}
