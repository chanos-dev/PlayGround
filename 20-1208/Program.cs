using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20_1208
{
    class Program
    {
        public static event EventHandler Clicked;

        static void Main(string[] args)
        {  
            List<int> lists = null;

            int? cnt = lists?.Count;

            Console.WriteLine(cnt);

            lists = new List<int>();

            lists.Add(1);

            cnt = lists?.Count;

            Console.WriteLine(cnt);

            lists = null;

            cnt = lists?.Count ?? 0;

            Console.WriteLine(cnt);

            Clicked?.Invoke(null, null);

            var temp = new Dictionary<string, int>()
            {
                ["Five"] = 5,
                ["Six"] = 6,
            };

            foreach (var c in temp.Keys)
                Console.WriteLine(temp[c]);

            var a = new[] { 1, 2, 3 };

            foreach (var c in a)
                Console.WriteLine(c);

            var b = new List<int>(a)
            {
                [0] = 2,
                [1] = 3,
            };

            foreach(var c in b)
                Console.WriteLine(c);

            string TEST = "text";

            Console.WriteLine($"{nameof(TEST)} : {TEST}");

            int z = 0;
            int x = 0;

            Div(z, x);

            Console.WriteLine("Next!");


            Console.ReadLine();
        }

        private static async void Div(int z, int x)
        {
            try
            {
                Console.WriteLine(z / x);
            }
            catch (DivideByZeroException)
            {
                await log();
            }
        }

        private static Task log()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Write log!!");
            }); 
        }
    }
}
