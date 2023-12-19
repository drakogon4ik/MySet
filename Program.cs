using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 7, 3, -100, 40, 2, -1, 7, 80, 7 };
            MySet node = TurnIntoChain(arr);
            Console.WriteLine(node);
            node.InsertTo(7);
            node.InsertTo(9);
            node.InsertTo(9);
            node.InsertTo(0);
            Console.WriteLine(node);
            Console.WriteLine(node.BelongTo(0));
            Console.WriteLine(node);
        }

        static MySet TurnIntoChain(int[] arr)
        {
            bool t = true;
            IntNode node = null;
            int[] temparr = new int[arr.Length];
            for (int i = arr.Length - 1; i > -1; i--)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    if (arr[i] == temparr[k])
                        t = false;
                }
                if (t)
                {
                    node = new IntNode(arr[i], node);
                    temparr[i] = arr[i];
                }
                t = true;
            }
            MySet temp = new MySet();
            temp.SetNode(node);
            return temp;
        }
    }


    class MySet
    {
        private IntNode node;

        public MySet()
        {
            this.node = null;
        }

        public IntNode GetNode()
        {
            return node;
        }

        public void SetNode(IntNode node)
        {
            this.node = node;
        }
        private void Insert(int num, IntNode p)
        {
            if (p == null)
            {
                node = new IntNode(num, node);
                return;
            }

            if (p.GetInfo() == num)
            {
                return;
            }
            Insert(num, p.GetNext());
        }
        public void InsertTo(int num)
        {
            Insert(num, this.node);
        }

        private bool Belong(int num, IntNode temp)
        {
            if (temp == null)
                return false;
            else if (temp.GetInfo() == num)
                return true;
            if (Belong(num, temp.GetNext()))
                return true;
            else
                return false;
        }

        public bool BelongTo(int num)
        {
            return Belong(num, node);
        }

        public override string ToString()
        {
            IntNode p = this.node;
            string s = "{ ";
            while (p != null)
            {
                s += p.GetInfo();
                if (p.GetNext() != null)
                    s += ", ";
                p = p.GetNext();
            }
            s += " }";
            return s;
        }
    }


    class IntNode
    {
        private int info;
        private IntNode next;


        public IntNode(int info)
        {
            this.info = info;
            this.next = null;
        }


        public IntNode(int info, IntNode next)
        {
            this.info = info;
            this.next = next;
        }


        public int GetInfo()
        {
            return info;
        }


        public IntNode GetNext()
        {
            return next;
        }


        public void SetInfo(int info)
        {
            this.info = info;
        }


        public void SetNext(IntNode next)
        {
            this.next = next;
        }


        public override string ToString()
        {

            return this.info + " " + this.next;
        }
    }
}
