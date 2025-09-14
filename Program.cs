namespace ConsoleApp1
{
    using System;

    namespace LinkedListExample
    {
        // تعریف کلاس نود (Node)
        public class Node
        {
            public int Data;   // داده
            public Node Next;  // اشاره‌گر به نود بعدی

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        // تعریف کلاس لیست پیوندی
        public class LinkedList
        {
            private Node head; // اولین نود لیست

            // افزودن به انتهای لیست
            public void Add(int data)
            {
                Node newNode = new Node(data);

                if (head == null)
                {
                    head = newNode;
                    return;
                }

                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            // حذف یک مقدار
            public void Remove(int data)
            {
                if (head == null) return;

                if (head.Data == data)
                {
                    head = head.Next;
                    return;
                }

                Node current = head;
                while (current.Next != null)
                {
                    if (current.Next.Data == data)
                    {
                        current.Next = current.Next.Next;
                        return;
                    }
                    current = current.Next;
                }
            }

            // جستجو
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }

            // چاپ لیست
            public void Print()
            {
                Node current = head;
                while (current != null)
                {
                    Console.Write(current.Data + " -> ");
                    current = current.Next;
                }
                Console.WriteLine("null");
            }
        }

        // تست لیست پیوندی
        class Program
        {
            static void Main(string[] args)
            {
                LinkedList list = new LinkedList();

                list.Add(10);
                list.Add(20);
                list.Add(30);

                Console.WriteLine("لیست بعد از افزودن:");
                list.Print();

                Console.WriteLine("\nآیا مقدار 20 وجود دارد؟ " + list.Contains(20));

                list.Remove(20);
                Console.WriteLine("\nلیست بعد از حذف 20:");
                list.Print();

                Console.WriteLine("\nآیا مقدار 20 وجود دارد؟ " + list.Contains(20));
            }
        }
    }
    using System;

namespace StackExample
    {
        public class Stack
        {
            private int[] items;  // آرایه برای ذخیره داده‌ها
            private int top;      // اندیس آخرین عنصر
            private int maxSize;  // ظرفیت پشته

            public Stack(int size)
            {
                maxSize = size;
                items = new int[maxSize];
                top = -1; // یعنی پشته خالی است
            }

            // افزودن به پشته (Push)
            public void Push(int data)
            {
                if (IsFull())
                {
                    Console.WriteLine("پشته پر است!");
                    return;
                }
                items[++top] = data;
            }

            // حذف از پشته (Pop)
            public int Pop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("پشته خالی است!");
                    return -1;
                }
                return items[top--];
            }

            // مشاهده عنصر بالای پشته بدون حذف (Peek)
            public int Peek()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("پشته خالی است!");
                    return -1;
                }
                return items[top];
            }

            // بررسی خالی بودن پشته
            public bool IsEmpty()
            {
                return top == -1;
            }

            // بررسی پر بودن پشته
            public bool IsFull()
            {
                return top == maxSize - 1;
            }

            // نمایش عناصر پشته
            public void Print()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("پشته خالی است!");
                    return;
                }

                Console.WriteLine("محتوای پشته:");
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(items[i]);
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Stack stack = new Stack(5);

                stack.Push(10);
                stack.Push(20);
                stack.Push(30);

                stack.Print();

                Console.WriteLine("\nعنصر بالای پشته: " + stack.Peek());

                Console.WriteLine("\nحذف عنصر: " + stack.Pop());
                Console.WriteLine("حذف عنصر: " + stack.Pop());

                stack.Print();
            }
        }
    }
    using System;

namespace BinaryTreeExample
    {
        // تعریف کلاس Node
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;

            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        // تعریف کلاس Tree
        public class BinaryTree
        {
            public Node Root;

            public BinaryTree()
            {
                Root = null;
            }

            // افزودن مقدار به درخت (Binary Search Tree)
            public void Insert(int data)
            {
                Root = InsertRec(Root, data);
            }

            private Node InsertRec(Node root, int data)
            {
                if (root == null)
                {
                    root = new Node(data);
                    return root;
                }

                if (data < root.Data)
                    root.Left = InsertRec(root.Left, data);
                else if (data > root.Data)
                    root.Right = InsertRec(root.Right, data);

                return root;
            }

            // پیمایش پیش‌ترتیب (PreOrder)
            public void PreOrder(Node node)
            {
                if (node == null) return;

                Console.Write(node.Data + " ");
                PreOrder(node.Left);
                PreOrder(node.Right);
            }

            // پیمایش میان‌ترتیب (InOrder)
            public void InOrder(Node node)
            {
                if (node == null) return;

                InOrder(node.Left);
                Console.Write(node.Data + " ");
                InOrder(node.Right);
            }

            // پیمایش پس‌ترتیب (PostOrder)
            public void PostOrder(Node node)
            {
                if (node == null) return;

                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.Write(node.Data + " ");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                BinaryTree tree = new BinaryTree();

                tree.Insert(50);
                tree.Insert(30);
                tree.Insert(70);
                tree.Insert(20);
                tree.Insert(40);
                tree.Insert(60);
                tree.Insert(80);

                Console.WriteLine("پیمایش InOrder:");
                tree.InOrder(tree.Root);

                Console.WriteLine("\n\nپیمایش PreOrder:");
                tree.PreOrder(tree.Root);

                Console.WriteLine("\n\nپیمایش PostOrder:");
                tree.PostOrder(tree.Root);
            }
        }
    }

}
