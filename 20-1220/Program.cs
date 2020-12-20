using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20_1220
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Add(1);

            Console.WriteLine(list.First(item => item == 1));
            Console.WriteLine(list.FirstOrDefault(item => item == 2));

            double C = 25.50;
            double F = C * 9 / 5 + 32; //77.9
            double F2 = C * (9 / 5) + 32; // 57.5            

            Console.WriteLine(F);
            Console.WriteLine(F2);

            class1 c = new class1();
            List<int> aa = c.List;
            aa.Add(10);
            c.Print();

            List<int> bb = c.List2;
            bb.Add(20);
            c.Print2();

            var cc = c.List3;

            List<string> strs = new List<string>
            {
                "Filename is Fs1000.txt",
                "Filename is FS1000.txt",
                "Filename is fs1000.txt",
                "Filename is fS1000.txt"
            };

            FilterData(strs, "fs1000");
        }

        static void FilterData(IList list, string filter)
        {
            foreach(string item in list)
            {
                if (item.IndexOf(filter) > 0)
                //if (item.IndexOf(filter, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Console.WriteLine(item);
                } 
            }
        }
    }

    class class1
    {
        private List<int> list = new List<int>();

        public List<int> List
        {
            get
            {
                return list;
            }
        }

        public List<int> List2 { get; private set; } = new List<int>();

        public ReadOnlyCollection<int> List3
        {
            get
            {
                //var ro = new ReadOnlyCollection<int>(List);
                //return ro;

                return list.AsReadOnly();
            }
        }

        public void Print()
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void Print2()
        {
            foreach (var item in List2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
