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
            node.InsertTo(7);
            Console.WriteLine(node);
            Console.WriteLine(node.BelongTo(5));
        }


        static MySet TurnIntoChain(int[] arr)
        {
            MySet node = null;
            for (int i = arr.Length - 1; i > -1; i--)
            {
                node = new MySet(arr[i], node);
            }
            return node;
        }


    }


    class MySet
    {
        private int info;
        private MySet next;


        public MySet(int info)
        {
            this.info = info;
            this.next = null;
        }


        public MySet(int info, MySet next)
        {
            this.info = info;
            this.next = next;
        }


        public int GetInfo()
        {
            return info;
        }


        public MySet GetNext()
        {
            return next;
        }


        public void SetInfo(int info)
        {
            this.info = info;
        }


        public void SetNext(MySet next)
        {
            this.next = next;
        }


        private void Insert(MySet node, int num)
        {
            MySet comming = new MySet(num, null);
            if (node == null)
                node = comming;
            else if (node.GetNext() == null)
            {
                comming.SetNext(node.GetNext());
                node.SetNext(comming);
            }
            else
            {
                Insert(node.GetNext(), num);
            }
        }

        public void InsertTo(int num)
        {
            MySet node = new MySet(info, next);
            Insert(node, num);
        }


        private bool Belong(MySet node, int num)
        {
            if (node == null)
                return false;
            else if (node.GetInfo() == num)
                return true;
            if (Belong(node.GetNext(), num))
                return true;
            else
                return false;
        }

        public bool BelongTo(int num)
        {
            MySet node = new MySet(info, next);
            return Belong(node, num);
        }


        public override string ToString()
        {

            return this.info + " " + this.next;
        }
    }
}
