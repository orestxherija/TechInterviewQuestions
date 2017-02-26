using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerin_InterviewPrep.Recursion
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="target"></param>
        /// <returns></returns>
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
            char[] inn = str.ToCharArray();

            DoPermute(inn, outt, used, length, 0);
        }


        public static void DoPermute (char[] inn, StringBuilder outt, Boolean[] used, int length, int level)
        {
            if (level == length)
            {
                Console.WriteLine(outt.ToString());
                return;
            }
            for (int i=0; i< length; ++i)
            {
                outt.Append(inn[i]);
                used[i] = true;
                DoPermute(inn, outt, used, length, level + 1);
                used[i] = false;
                outt.Length = 0;
            }

        }


        public static void compute_accum_mat(int[,] original_mat)
        {
            for (int i = 0; i < original_mat.GetLength(0); i++)
            {
                for (int j =0; j<original_mat.GetLength(0); j++)
                {
                    if (i>0 && j > 0)
                    { 
                        original_mat[i, j] = original_mat[i-1,j]+original_mat[i,j-1]-original_mat[i-1,j-1]+original_mat[i,j];
                    }
                    else if (i > 0 && j<1) {
                        original_mat[i, j] = original_mat[i - 1, j]  + original_mat[i, j];
                    }
                    else if (j > 0 && i<1)
                    {
                        original_mat[i, j] =   original_mat[i, j - 1] + original_mat[i, j];
                    }
                }
            }
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
