using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Trees
{
    internal class Program
    {
        public class Node
        {
            public int element;
            public Node left;
            public Node right;
            public Node (int e, Node l, Node r)
            {
                element = e;
                left = l;
                right = r;
            }
        }
        class Binarysearchtree
        {
            public Node root;
            public Binarysearchtree()
            {
                root = null;
            }
            public void Insertion_ite(Node troot, int e)
            {
                Node temp = null;
                while(troot != null)
                {
                    temp = troot;
                    if (e == troot.element)
                    {
                        return;
                    }else if(e<troot.element)
                    {
                        troot = troot.left;
                    }else if(e>troot.element)
                    {
                        troot = troot.right;
                    }

                }
                Node n = new Node (e,null,null);
                if(root != null)
                {
                    if (e < temp.element)
                    {
                        temp.left = n;
                    }
                    else
                    {
                        temp.right = n;
                    }
                }
                else
                {
                    root = n;
                }

            }
            public Node Insertion_rec(Node troot, int e)
            {
                if (troot != null)
                {
                    if (e < troot.element)
                    {
                        troot.left = Insertion_rec(troot.left, e);
                    }
                    else if(e> troot.element)
                    {
                        troot.right = Insertion_rec(troot.right, e);
                    }
                    
                }
                else
                {
                    Node n = new Node(e, null, null);
                    troot = n;

                }
                return troot;
            }
            public void inOrder(Node troot)
            {
                if(troot!= null)
                {
                    inOrder(troot.left);
                    Console.Write(troot.element+" ");
                    inOrder(troot.right);
                }
            }
            public void preOrder(Node troot)
            {
                if( troot!= null)
                {
                    Console.Write(troot.element+" ");
                    preOrder(troot.left);
                    preOrder(troot.right) ;
                }

            }
            public void postOrder(Node troot)
            {
                if(troot!= null)
                {
                    postOrder(troot.left);
                    postOrder(troot.right);
                    Console.Write(troot.element+" ");
                }
            }
            

                public void levelOrder()
                {
                    if (root == null)
                    {
                        return;
                    }

                    Queue<Node> queue = new Queue<Node>();
                    queue.Enqueue(root);

                    while (queue.Count > 0)
                    {
                        Node current = queue.Dequeue();
                        Console.Write(current.element + " ");

                        if (current.left != null)
                        {
                            queue.Enqueue(current.left);
                        }

                        if (current.right != null)
                        {
                            queue.Enqueue(current.right);
                        }
                    }
                }
            public bool search_ite(int key)
            {
                Node troot = root;
                while (troot != null)
                {
                    if(key == troot.element)
                    {
                        return true;
                    }
                    else if(key<troot.element)
                    {
                        troot = troot.left;
                    }
                    else if (key > troot.element)
                    {
                        troot = troot.right;

                    }
                }
                return false;
            }
            public bool search_rec(Node troot, int key)
            {
                if(troot != null)
                {
                    if(key == troot.element)
                    {
                        return true;
                    }
                    else if(key < troot.element)
                    {
                        return search_rec(troot.left, key); 
                    }
                    else if(key > troot.element)
                    {
                        return search_rec(troot.right, key);
                    }
                }
                
                    return false;
                
            }
            public bool delete(int e)
            {
                Node p = root;
                Node pp = null;
                while (p != null && p.element != e) 
                {
                    pp= p;
                    if(e<p.element)
                    {
                        p=p.left;
                    }
                    else
                    {
                        p=p.right;
                    }
                }
                if (p == null)
                {
                    return false;
                }
                if(p.left != null && p.right != null)
                {
                    Node s = p.left;
                    Node ps = p;
                    while (s.right != null)
                    {
                        ps = s;
                        s= s.right;
                    }
                    p.element = s.element;
                    p = s;
                    pp = ps;
                }
                Node c = null;
                if(p.left != null) 
                {
                    c = p.left;
                }
                else
                {
                    c= p.right;
                }
                if (p == root)
                {
                    root = c;
                }else
                {
                    if(p == pp.left)
                    {
                        pp.left = c;

                    }
                    else
                    {
                        pp.right = c;
                    }
                }
                return true;    
                
            }
            public int Count(Node troot)
            {
                if (troot != null)
                {
                    int x = Count(troot.left);
                    int y = Count(troot.right);
                    return x + y+1;
                }
                return 0;   
            }
            public int Higth(Node troot)
            {
                if(troot != null)
                {
                    int x = Higth(troot.left);
                    int y = Higth(troot.right);
                    if (x > y)
                    {
                        return x+1;
                    }
                    else
                    {
                        return y + 1;
                    }
                }
                return 0;
            }
            

        }
        static void Main(string[] args)
        {
            Binarysearchtree b = new Binarysearchtree();
            Console.WriteLine("Itrative Insertion elemnet in a Binary Tree:  ");
            b.Insertion_ite(b.root, 5);
            b.Insertion_ite(b.root, 3);
            b.Insertion_ite(b.root, 8);
            b.Insertion_ite(b.root, 1);
            b.Insertion_ite(b.root, 4);
           

            Console.WriteLine("Traverse this tree using INORDER traversal method: ");
            b.inOrder(b.root);
            Console.WriteLine();
            Console.WriteLine("Recursively insert elemnet : ");
            b.Insertion_rec(b.root, 6);
            b.Insertion_rec(b.root, 9);
            b.inOrder(b.root);
            Console.WriteLine();
            Console.WriteLine("Traverse this tree using PREORDER traversal method: ");
            b.preOrder(b.root);
            Console.WriteLine();
            Console.WriteLine("Traverse this tree using POSTORDER traversal method: ");
            b.postOrder(b.root);
            Console.WriteLine();
            Console.WriteLine("Traverse this tree using LEVELORDER traversal method: ");
            b.levelOrder();
            Console.WriteLine();
            Console.WriteLine("Searching 6 the tree itratively: "+ b.search_ite(6));
            
            Console.WriteLine("Searching 6 the tree recursively: " + b.search_rec(b.root, 6));
            Console.WriteLine("Deleting elemnet 6 :");
            b.delete(6);
            b.levelOrder();
            Console.WriteLine();
            Console.WriteLine("Number of Nodes present in this tree is:"+ b.Count(b.root));
            Console.WriteLine("Higth of this tree is: "+ b.Higth(b.root));


            Console.ReadLine();
        }
    }
}
