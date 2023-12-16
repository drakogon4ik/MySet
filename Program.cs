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
            node.InsertTo(80);
            Console.WriteLine(node);
            Console.WriteLine(node.BelongTo(5));
        }

        static MySet TurnIntoChain(int[] arr)
        {
            IntNode node = null;
            for (int i = arr.Length - 1; i > -1; i--)
            {
                node = new IntNode(arr[i], node);
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
            node = new IntNode(num, node);
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
