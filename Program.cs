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
            Console.WriteLine(node);
            Console.WriteLine(node.BelongTo(7));
        }

        static MySet TurnIntoChain(int[] arr)
        {
            bool t = true;
            IntNode node = null;
            int[] temparr = new int[arr.Length];
            for (int i = arr.Length - 1; i > -1; i--)
            {
                for(int k = 0; k < arr.Length; k++)
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
            MySet temp = new MySet(node);
            return temp;
        }
    }


    class MySet
    {
        private IntNode node;

        public MySet(IntNode node)
        {
            this.node = node;
        }

        public IntNode GetNode()
        {
            return node;
        }

        public void SetNode(IntNode node)
        {
            this.node = node;
        }

        public void InsertTo(int num)
        {
            IntNode comming = new IntNode(num, null);
            if (node == null)
                node = comming;
            else if ((node.GetNext() == null) && (node.GetInfo() != num))
            {
                comming.SetNext(node.GetNext());
                node.SetNext(comming);
            }
            else if (node.GetInfo() != num)
            {
                MySet temp = new MySet(node.GetNext());
                temp.InsertTo(num);
            }
        }

        public bool BelongTo(int num)
        {
            if (node == null)
                return false;
            else if (node.GetInfo() == num)
                return true;
            node = node.GetNext();
            if (BelongTo(num))
                return true;
            else
                return false;
        }

        public override string ToString()
        {

            return this.node.GetInfo() + " " + this.node.GetNext();
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
