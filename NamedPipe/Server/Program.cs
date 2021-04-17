using NamedPipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeControl pipeControl = new NamedPipeControl("chanos");            

            pipeControl.ServerOpen();

            while (true)
            {                
                Console.ReadLine();
            }
        }
    }
}
