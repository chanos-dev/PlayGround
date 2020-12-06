using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<CreateItem> createItems = new Queue<CreateItem>();

            ItemController.Instance.Deploy();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.Compare(input, "flush") == 0)
                {
                    while (createItems.Count != 0)
                    {
                        var item = createItems.Dequeue();
                        ItemController.Instance.Enqueue(item.Ready());
                    }
                }
                else
                {
                    var param = input.Split(' ');

                    if(param.Count() == 1)
                    {
                        createItems.Enqueue(new CreateConsoleItem(param[0]));
                    }
                    else
                    {
                        createItems.Enqueue(new CreateTextFileItem(param[0], param[1]));
                    }
                }
            }
        }
    }
}
