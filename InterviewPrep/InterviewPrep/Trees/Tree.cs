using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterviewPrep.Tree
{
    public class Node
    {
        // Properties
        public Node Left;
        public Node Right;
        public int Value;

        // Constructor
        public Node(Node left, Node right, int value)
        {
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }

        public static void PreorderTraverseRecurse(Node root)
        {
            if (root != null)
            {
                Console.Out.WriteLine(root.Value);
                PreorderTraverseRecurse(root.Left);
                PreorderTraverseRecurse(root.Right);
            }
            else
            {
                return;
            }
        }


        public static void PreorderTraverseNoRecurse(Node root)
        {
            Stack<Node> stk = new Stack<Node>();
            Node popped;
            //stk.Pop();

            while (root != null)
            {
                Console.Out.WriteLine(root.Value);
                if (root.Left != null)
                {
                    if (root.Right != null)
                    {
                        stk.Push(root.Right);
                    }
                    root = root.Left;
                }
                else if (root.Right != null)
                {
                    root = root.Right;
                }
                else
                {
                    if (stk.Count != 0)
                    {
                        popped = stk.Pop();
                        root = popped;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static Node CopyTheTree(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Node newNode = new Node(null, null, root.Value);
            newNode.Left= CopyTheTree(root.Left);
            newNode.Right= CopyTheTree(root.Right);
            return newNode;
        }

        public static int GetMaxDepth(Node root, int maxDepth)
        {
            if (root == null)
            {
                return maxDepth;
            }
            else {
                int tempMD1 = GetMaxDepth(root.Left, maxDepth + 1);
                int tempMD2 = GetMaxDepth(root.Right, maxDepth + 1);
                return Math.Max(tempMD1, tempMD2);
            }
        }

        public static int GetMinDepth(Node root, int maxDepth)
        {
            if (root == null)
            {
                return maxDepth;
            }
            else {
                int tempMD1 = GetMaxDepth(root.Left, maxDepth + 1);
                int tempMD2 = GetMaxDepth(root.Right, maxDepth + 1);
                return Math.Min(tempMD1, tempMD2);
            }
        }


        public static Boolean IsItBalancedTree(Node root)
        {
            if (root != null)
            {
                int MaxDep = GetMaxDepth(root, 0);
                int MinDep = GetMinDepth(root, 0);
                if (MaxDep - MinDep > 1)
                {
                    return false;
                }
                else { return true; }
            }
            else
            {
                return true;
            }

        }


        public static Node MinHeightBT(int[] arr, int lower, int higher)
        {
            if (higher <= lower)
            {
                return new Node(null, null, arr[lower]);
            }
            else
            {
                int center = ((lower + higher) / 2);
                Node c_root = new Node(null, null, arr[center]);
                c_root.Left = MinHeightBT(arr, lower, center - 1);
                c_root.Right = MinHeightBT(arr, center + 1, higher);
                return c_root;
            }


        }
        public static Node CommonAncestorForBT(Node n1, Node n2, Node root)
        {
            if (root == null)
            {
                return null;
            }
            if (root.Value < n1.Value && root.Value < n2.Value
                )
            {
                return CommonAncestorForBT(n1, n2, root.Right);
            }
            else if (root.Value < n1.Value && root.Value > n2.Value)
            {
                return CommonAncestorForBT(n1, n2, root.Left);
            }
            else
            {
                return root;
            }
        }


        public static Node FindParent(Node root, Node node)
        {
            if (root == null || node == null)
            {
                return null;
            }
            else if ((root.Right != null && root.Right.Value == node.Value) || (root.Left != null && root.Left.Value == node.Value))
            {
                return root;
            }
            else
            {
                Node found = FindParent(root.Right, node);

                if (found == null)
                {
                    found = FindParent(root.Left, node);
                }

                return found;
            }
        }

        public static Node GetLeftMost(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return GetLeftMost(node.Left);
        }

        public static Node WhoIsNextInOrder(Node root, Node node)
        {
            if (node.Right != null)
            {
                return GetLeftMost(node.Right);
            }
            else // node.Right == null
            {
                Node p = new Node(null, null, -1);
                Node Next = new Node(null, null, -1);
                bool found = false;
                p = FindParent(root, node);
                while (found == false)
                {
                    if (p.Left == node) { Next = p; return Next; }
                    node = p;
                    p = FindParent(root, node);
                }
                return Next;
            }
        }

        private static int globalDepth = 0;
        public static void PrintLeftSide(Node root, int localDepth)
        {
            if (root == null)
            {
                return;
            }
            if (localDepth > globalDepth)
            {
                Console.WriteLine(root.Value);
                globalDepth++;
            }
            PrintLeftSide(root.Left, localDepth + 1);
            PrintLeftSide(root.Right, localDepth + 1);
        }

        private static int firstKthSum = 0;
        private static int firstKthSumReturned = 0;
        private static int count = 0;

        public static void FirstKthSum(Node root, int k)
        {
            if (root == null)
            {
                return;
            }
            FirstKthSum(root.Left, k);
            count += 1;
            firstKthSum += root.Value;
            if (k == count)
            {
                firstKthSumReturned = firstKthSum;
                return;
            }
            FirstKthSum(root.Right, k);
        }


        public static int FirstKthSumHelper(Node root, int k)
        {
            FirstKthSum(root, k);
            return firstKthSumReturned;
        }



        public static void PrintRoot2Leaves(Node root, List<int> path)
        {
            if (root == null) { return; }
            path.Add(root.Value);
            if (root.Left == null && root.Right == null)
            {
                Console.WriteLine(string.Join(",", path));
                return;
            }
            else {
                PrintRoot2Leaves(root.Left, new List<int>(path));
                PrintRoot2Leaves(root.Right, new List<int>(path));
            }
        }

        /*
        public static void PrintRoot2LeavesRelatively(Node root, List<int> path, List<int> rela)
        {
            if (root == null) { return; }
            path.Add(root.Value);
            if (root.Left == null && root.Right == null)
            {
                Console.WriteLine(string.Join(",", path));
                return;
            }
            else {
                PrintRoot2Leaves(root.Left, new List<int>(path), );
                PrintRoot2Leaves(root.Right, new List<int>(path), );
            }
        }
        */


        public static void LevelOrderPrint(Node root, int level)
        {
            if (root == null)
            {
                return;
            }
            else if (level > 0)
            {
                Console.WriteLine(root);
                LevelOrderPrint(root.Left, level-1);
                LevelOrderPrint(root.Right, level-1);
            }
            else
            {
                Console.WriteLine(root.Left);
                Console.WriteLine(root.Right);
            }
        }
        





    }
} 