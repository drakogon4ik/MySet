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
            int[] arr = { 100, 50, 30, 15, 3 };
            int[] arr1 = { 100, 50, 30, 15, 3 };
            MySet node = TurnIntoChain(arr);
            MySet node1 = TurnIntoChain(arr1);
            Console.WriteLine(node.IsSame(node1));
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


        public int CheckLen()
        {
            int n = 0;
            while(node != null)
            {
                n++;
                node = node.GetNext();
            }
            return n;
        }


        private IntNode InsertOrdered(int num, IntNode res)
        {
            if (res == null)
                return new IntNode(num);
            IntNode temp = res;
            while (temp != null)
            {
                if (temp.GetInfo() == num)
                    return res;
                temp = temp.GetNext();
            }
            IntNode b = res;
            if (num >= res.GetInfo())
                return new IntNode(num, res);
            while (res != null)
            {
                if (res.GetNext() == null)
                {
                    IntNode r = new IntNode(num);
                    r.SetNext(res.GetNext());
                    res.SetNext(r);
                    return b;
                }
                if ((res.GetInfo() >= num) && (num >= res.GetNext().GetInfo()))
                {
                    IntNode r = new IntNode(num);
                    r.SetNext(res.GetNext());
                    res.SetNext(r);
                    return b;
                }
                res = res.GetNext();
            }
            return res;
        }

        public void InsertOrderedToBS(int num)
        {
            node = InsertOrdered(num, node);
        }


        private bool Ordered(IntNode obj)
        {
            if ((obj == null) || (obj.GetNext() == null))
                return true;
            while ((obj.GetNext() != null) && (obj.GetInfo() == obj.GetNext().GetInfo()))
                obj = obj.GetNext();
            if (obj.GetNext() == null)
                return true;
            if (obj.GetInfo() > obj.GetNext().GetInfo())
            {
                while (obj.GetNext() != null)
                {
                    if (obj.GetNext().GetInfo() > obj.GetInfo())
                        return false;
                    obj = obj.GetNext();
                }
            }
            else
            {
                while (obj.GetNext() != null)
                {
                    if (obj.GetNext().GetInfo() < obj.GetInfo())
                        return false;
                    obj = obj.GetNext();
                }
            }
            return true;
        }

        public bool IsOrdered()
        {
            return Ordered(node);
        }


        public bool IsSame(MySet otherset)
        {
            int n = 0;
            while (node != null)
            {
                if (!otherset.BelongTo(node.GetInfo()))
                    return false;
                node = node.GetNext();
                n++;
            }
            if (n != otherset.CheckLen())
                return false;
            return true;
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
