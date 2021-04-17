using NamedPipe;
using NamedPipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    enum Mode
    {
        Text = 1,
        Object,
    }

    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeControl pipeControl = new NamedPipeControl("chanos");

            pipeControl.ClientOpen();

            while(true)
            {
                Console.Write("Input Mode (1:Text, 2:Company Object) : "); 

                var read = Console.ReadLine();

                if (int.TryParse(read, out int result))
                {
                    var mode = (Mode)result;  

                    switch(mode)
                    {
                        case Mode.Text:
                            Console.Write("Text : ");
                            var message = Console.ReadLine();
                            pipeControl.Write(message);
                            break;
                        case Mode.Object:
                            Console.Write("CompanyInfo (CompayCD) : ");
                            var cd = Console.ReadLine().Replace("-", "");

                            Console.Write("CompanyInfo (Name) : ");
                            var name = Console.ReadLine();

                            Console.Write("CompanyInfo (Address) : ");
                            var address = Console.ReadLine();

                            var info = new CompanyInfo()
                            {
                                CompanyCD = Convert.ToInt32(cd),
                                Name = name,
                                Address = address,
                            };

                            pipeControl.WriteObject(info);
                            break;
                    }
                } 
            } 
        }
    }
}
