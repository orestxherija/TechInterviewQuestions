using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Tree;

using InterviewPrep.Arrays;
using InterviewPrep.Recursion;
using InterviewPrep.Dequeue;
using InterviewPrep.Dequeue.Generic;
using InterviewPrep.MinStack;

namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {

            DoubleArray.Permute("ABC");

            int xxx;
            for (xxx =2; xxx>1; --xxx)
            {
                Console.WriteLine("yes");
            }

            //Double[] a = Recursion.GenericArray<Double>.MergeSort(new Double[]{ 5,4,3,2},0,3);

            int[] array1 = new int[]{1, 2, 3,6 };
            DoubleArray.FindSameProductPairs(array1);

            MinStack.MinStack ms = new MinStack.MinStack();
            ms.Push(5);
            ms.Push(6);
            ms.Push(4);
            ms.Push(3);
            int pm2 = ms.PeekMin();
            ms.Pop();
            int pm3 = ms.PeekMin();
            ms.Pop();
            int pm1 = ms.PeekMin();


            LinkedList ll = new LinkedList();
            LinkedList ll2 = new LinkedList();

            ll.Add(1);
            ll.Add(2);
            ll.Add(3);

            ll2.Add(5);
            ll2.Add(6);
            ll2.Add(7);
            ll2.Add(8);

            ll.Reverse();
            
            LinkedList ll_result = ll.ElementSum(ll2);
            LinkedList ll_result2 = ll.ElementSumElegant(ll2);
            

            string s1 = "Aerin Fishkin";
            string rm = "aeiou";
            string removeVowel = StringsArrays.Strings.RemoveChars(s1, rm);

            int stringFromInteger = StringsArrays.Strings.StringToSignedInteger("408");
            string intergerFromString= StringsArrays.Strings.IntegerToString(-707);

            bool unique = StringsArrays.Strings.StringContainsAllUnique("chrism");
            string RemoveDuplicatedCharacters = StringsArrays.Strings.RemoveDuplicatedCharacters("aqbcd");

            bool anagram = StringsArrays.Strings.AreTheseAnagrams("iceman","cinema");

            StringsArrays.Strings.Permutation("abcd");


            string set = "abc";
            StringBuilder subset = new StringBuilder();
            HashSet<string> allSubsets = new HashSet<string>();
            HashSet<string> result2 = DoubleArray.ZeroOneCombination(set,subset,allSubsets);

            int result5 = DoubleArray.Ways2PayNCents(15);
            int result6 = Recursion.Recursion.WaysToExit(3,3 );

            List<string> listOfPaths = new List<string>();
            StringBuilder tempString = new StringBuilder();
            Recursion.Recursion.WaysToExitWObstacle(2, 2, tempString, listOfPaths);

            StringBuilder tempString2 = new StringBuilder();
            Recursion.Recursion.CombiParentheses(3, 0, tempString2);


            int[,] x1 = new int[,] { { 1, 0, 3 }, { 4, 5, 6 } };
            int[,] x = StringsArrays.Strings.MakeRowsColumnsZero(x1); 

            //int a = 'c' - 'a'; // this is 2.

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
            int result3 = DoubleArray.LargestSquareMatrixOfOne(testMatrix);

            int[,] traverseMatrix = new int[,] { { 11, 12, 13 },
                                                 { 21, 22, 23 },
                                                 { 31, 32, 33 }
                                                };
            Stack<int> stackResult1 = DoubleArray.SpiralTraverse(traverseMatrix);

            int[] randomArray = { 4, 9, 8, 6, 3, 1, 11, 14, 7, 9 };
            DoubleArray.printKMax(randomArray, randomArray.Length, 3);



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

            Node t2 = Node.BiggestBetweenBSTNodes(n5, n4, n10);


            int result0 = Node.FirstKthSumHelper(n5, 3);
            Console.WriteLine("=================");
            List<int> emptyList = new List<int>();
            Node.PrintRoot2Leaves(n5,emptyList);
            Node.PrintLeftSide(n5,1);


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
            //
            //DoubleArray.PrintPermutation(d1);

        }
    }
}
