using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_0106
{
    class TESTClass
    {
        public ClassCollection ClassCollection { get; set; }
    }
    
    class ClassCollection
    {
        public ClassA ClassA { get; set; }
        public ClassB ClassB { get; set; }
    }

    class ClassA
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    class ClassB
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    class Program
    {
        enum TEST
        {
            one,
            two
        }

        static void Main(string[] args)
        {
            List<int> lists = new List<int>();

            lists.Add(10);
            lists.Add(20);
            lists.Add(30);
            lists.Add(40);
            lists.Add(50);
            lists.Add(60);
            lists.Add(70);
            lists.Add(80);
            lists.Add(90);

            Parallel.ForEach(lists, item =>
            {
                Console.WriteLine(item.ToString());
            });

            /////////////////
            ///

            ClassA classA = new ClassA();
            classA.Text = "Hello, World.";
            classA.Type = "Type is ClassA";

            ClassB classB = new ClassB();
            classB.Text = "the dog is cute.";
            classB.Type = "Type is ClassB";


            ClassCollection classCollection = new ClassCollection();
            classCollection.ClassA = classA;
            classCollection.ClassB = classB;

            TESTClass testClass = new TESTClass();
            testClass.ClassCollection = classCollection;

            var aa = testClass.ClassCollection.GetType().GetProperties();            

            foreach (var a in aa)
            {
                dynamic oo = testClass.ClassCollection.GetType().GetProperty(a.Name).GetValue(testClass.ClassCollection, null);

                Console.WriteLine($"{oo.Text} \t {oo.Type}");

                //Console.WriteLine(a.GetValue(, null));
            }


            return;

            //https://www.virustotal.com/vtapi/v2/url/report?apikey=55fa20c2e92957295299918dc93ea623329e806c3233ef0099904b43893b5199&resource=https://www.naver.com/
            string url = "https://www.virustotal.com";
            string[] arr1 = new string[] { "vtapi" };
            string[] arr2 = new string[] { "v2", "url", "report" };

            Console.WriteLine(string.Join("/", Enumerable.Concat(new string[] { url }, arr1).Concat(arr2)));

            if (foo(10, out int b))
            {
                Console.WriteLine(b.ToString());
            }

            Console.WriteLine(TEST.one.ToString());
        }

        static bool foo(int i, out int a)
        {
            bool isSuccess = true;

            try
            {
                a = i * i;
            }
            catch
            {
                isSuccess = false;
                a = -1;
            }

            return isSuccess;
        }
    }
}
