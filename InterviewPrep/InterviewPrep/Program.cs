using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Tree;
using InterviewPrep.Arrays;


namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {

            //Double[] a = Recursion.GenericArray<Double>.MergeSort(new Double[]{ 5,4,3,2},0,3);

            /*
            LinkedList num1 = new LinkedList();
            LinkedList num2 = new LinkedList();

            num1.Add(1);
            num1.Add(2);
            num1.Add(3);
            num2.Add(5);
            num2.Add(6);
            num2.Add(7);
            num2.Add(8);

            // num1.Reverse();
            
            LinkedList result = num1.ElementSum(num2);
            LinkedList result2 = num1.ElementSumElegant(num2);
            */


            string s1 = "Aerin Fishkin";
            string rm = "aeiou";
            string removeVowel = StringsArrays.Strings.RemoveChars(s1, rm);

            //string s1 = "banal";
            //Console.Out.WriteLine(Strings.RemoveDupCharsWBuffer(s1));

            int[,] orr2 = new int[,] { { 1, 2, 3,8,9,11,13 }, {3,7,12,15,16,17,18 }, { 9,16,20,22,23,24,25} };
            Tuple<int, int> tup = DoubleArray.find_X(orr2, 12);
            //Console.Out.Write(tup);

            int[,] orr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            //Console.Out.WriteLine(orr[0,0]);
            //DoubleArray.compute_accum_mat(orr);
            int[,] mindi_mat = DoubleArray.mindi_loop(orr);
            //Console.Out.WriteLine(orr[1, 1]);


            int[,] testMatrix = new int[,] {   { 0,1,1,1,1,0 },
                                               { 0,1,1,1,1,0 }, 
                                               { 0,1,1,1,1,0 },
                                               { 0,1,1,1,1,0 },
                                               { 0,1,1,1,1,0 },
                                               { 1,1,1,0,0,1 }
                                           };

            int result = DoubleArray.ReturnBiggestSquareSize(testMatrix);
            int result2 = DoubleArray.LargestSquareMatrixOfOne(testMatrix);

            //char vv = Strings.first_non_rep_char("total");
            //Console.Out.WriteLine(vv);

            // Construct a binary search tree.
            Node n1 = new Node(null, null, 1);
            Node n4 = new Node(null, null, 4);
            Node n3 = new Node(n1, n4, 3);
            Node n7 = new Node(null, null, 7);
            Node n14 = new Node(null, null, 14);
            Node n13 = new Node(null, null, 13);
            Node n12 = new Node(null, n13, 12);
            Node n10 = new Node(n7, n12, 10);
            Node n5 = new Node(n3, n10, 5); // root


            Node commonAncestor = Node.CommonAncestorForBT(n7, n13, n5);
            Console.Out.WriteLine("the common ancestor's value is "+commonAncestor.Value);


            Node maParent = Node.FindParent(n5, n13);
            Console.Out.WriteLine("My name is " + (n13.Value) + " and my mama name is " + (maParent.Value));

            Node theNext = Node.WhoIsNextInOrder(n5, n1);
            Console.Out.WriteLine("My name is " + (n1.Value) + " and my next one (in order traversal) is " + (theNext.Value));


            Node newNode = Node.CopyTheTree(n5);
            //n7 = new Node(null, null, 34);
            //n10.Left.Value = 35;
            //n7.Value = 34;

            int md = Node.GetMaxDepth(n5,0);
            Boolean boo = Node.IsItBalancedTree(n5);

            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Node the_tree= Node.MinHeightBT(arr1, 0, 6);



            //Node.PreorderTraverseRecurse(n5);
            Console.Out.WriteLine("------------------");
            //Node.PreorderTraverseNoRecurse(n5);
            
            //Stack<Node> stk = new Stack<Node>();
            //stk.Push(n5);
            //stk.Push(n10);
            //stk.Pop();

            Console.In.Read();

            /*
            int[] d1 = new int[] { 1, 2, 3,4 };
            int[] d2 = new int[10];
            int i;
            for (i = 0; i < 10; i++)
            {
                d2[i] = i;
            }
            Console.Out.WriteLine(i);
            Console.WriteLine(string.Join(",", d2));
            */


            // DoubleArray a = new DoubleArray(d1);
            // Because BinarySearch was a static method, we call it through the DoubleArray without instantiating it.
            // If it was non-static, we would call it via - a.BinarySeach()
            //int res = DoubleArray.BinarySearchIter(d2, 0, d2.Length,21);
            //Console.Out.Write(res);
            //DoubleArray.Permute("Pan");
            //DoubleArray.PrintPermutation(d1);

        }
    }
}
