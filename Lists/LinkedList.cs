using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerin_InterviewPrep
{      
        public class LinkedList
        {
            public class Node
            {
                public object NodeContent;
                public Node Next;
            }

            private int size; // field
        
            public int Count // property
            {
                get
                {
                    return size;
                }
            }

            /// <summary>
            /// The head of the list.
            /// </summary>
            private Node head;

            /// <summary>
            /// The current node, used to avoid adding nodes before the head
            /// </summary>
            private Node current;

            public LinkedList()
            {
                size = 0;
                head = null;
            }
            
            /// <summary>
            /// Reverses the linked list.
            /// </summary>
            public void Reverse()
            {
                Stack<Node> listStack = new Stack<Node>();
                Node currentNode = this.head;
                while (currentNode.Next != null)
                {
                    listStack.Push(currentNode);
                    currentNode = currentNode.Next;
                }

                this.head = currentNode;

                while (listStack.Count > 0)
                {
                    currentNode.Next = listStack.Pop();
                    currentNode = currentNode.Next;
                }

                currentNode.Next = null;
                this.current = currentNode;
            }



            public LinkedList ElementSum(LinkedList other)
            {
                LinkedList linkedListSum = new LinkedList();
                this.Reverse();
                other.Reverse();

                Node n1 = this.head;
                Node n2 = other.head;

                int passAround = 0 ;
                int leftover = 0;
                int tempSum = 0;

            while ((n1 != null) || (n2!= null))
                {
                int num1 = ( n1==null ? 0: (int)n1.NodeContent);
                int num2 = ( n2 == null ? 0 : (int)n2.NodeContent);
                tempSum = num1 + num2 + passAround;
                passAround = (int)(tempSum / 10);
                leftover = tempSum % 10;
                linkedListSum.Add(leftover);
                n1 = (n1 == null ? null : n1.Next);
                n2 = (n2 == null ? null : n2.Next);
                }
            this.Reverse();
            other.Reverse();
            linkedListSum.Reverse();
            return linkedListSum; 
        }












        public LinkedList ElementSumElegant(LinkedList other)
        {
            LinkedList linkedListSum = new LinkedList();
            this.Reverse();
            other.Reverse();

            Node n1 = this.head, n2 = other.head;
            int toAdd = 0, carryOver = 0;

            while ((n1 != null) || (n2 != null))
            {
                int num1 = (int) (n1 == null ? 0 : n1.NodeContent);
                int num2 = (int) (n2 == null ? 0 : n2.NodeContent);
                toAdd = (num1 + num2 + carryOver) % 10;
                carryOver = (int)(num1 + num2 + carryOver) / 10;
                linkedListSum.Add(toAdd);
                n1 = (n1 == null ? null : n1.Next);
                n2 = (n2 == null ? null : n2.Next);
            }

            this.Reverse();
            other.Reverse();
            linkedListSum.Reverse();
            return linkedListSum;
        }

            /// <summary>
            /// Add a new Node to the list.
            /// </summary>
        public void Add(object content)
            {
                size++;

                // This is a more verbose implementation to avoid adding nodes to the head of the list
                var node = new Node()
                {
                    NodeContent = content
                };

                if (head == null)
                {
                    // This is the first node. Make it the head
                    head = node;
                }
                else
                {
                    // This is not the head. Make it current's next node.
                    this.current.Next = node;
                }

                // Makes newly added node the current node
                this.current = node;


                // This implementation is simpler but adds nodes in reverse order. It adds nodes to the head of the list

                //head = new Node()
                //{
                //    Next = head,
                //    NodeContent = content
                //};
            }

            /// <summary>
            ///  Throwing this in to help test the list
            /// </summary>
            public void ListNodes()
            {
                Node tempNode = head;

                while (tempNode != null)
                {
                    Console.WriteLine(tempNode.NodeContent);
                    tempNode = tempNode.Next;
                }
            }



            /// <summary>
            /// Returns the Node in the specified position or null if inexistent
            /// </summary>
            /// <param name="Position">One based position of the node to retrieve</param>
            /// <returns>The desired node or null if inexistent</returns>
            public Node Retrieve(int Position)
            {
                Node tempNode = head;
                Node retNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == Position - 1)
                    {
                        retNode = tempNode;
                        break;
                    }
                    count++;
                    tempNode = tempNode.Next;
                }

                return retNode;
            }

            /// <summary>
            /// Delete a Node in the specified position
            /// </summary>
            /// <param name="Position">Position of node to be deleted</param>
            /// <returns>Successful</returns>
            public bool Delete(int Position)
            {
                if (Position == 1)
                {
                    head = null;
                    current = null;
                    return true;
                }

                if (Position > 1 && Position <= size)
                {
                    Node tempNode = head;

                    Node lastNode = null;
                    int count = 0;

                    while (tempNode != null)
                    {
                        if (count == Position - 1)
                        {
                            lastNode.Next = tempNode.Next;
                            return true;
                        }
                        count++;

                        lastNode = tempNode;
                        tempNode = tempNode.Next;
                    }
                }

                return false;
            }
        }
    




}
