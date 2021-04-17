using NamedPipe.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipe
{
    public class NamedPipeControl
    {
        private const int TIMEOUT = 60000; // 60 sec

        private string PipeName { get; set; }

        NamedPipeServerStream ServerStream { get; set; }

        NamedPipeClientStream ClientStream { get; set; }

        public NamedPipeControl(string pipe)
        {
            PipeName = pipe;
        }

        public async void ServerOpen()
        {
            ServerStream = new NamedPipeServerStream(PipeName);

            Console.WriteLine("Wait a client.");

            ServerStream.WaitForConnection();  

            Console.WriteLine("Connected Client!");

            while (ServerStream.IsConnected)
            {
                var readBytes = new byte[4096];
                await ServerStream.ReadAsync(readBytes, 0, (int)readBytes.Length); 

                var message = Encoding.UTF8.GetString(readBytes).TrimEnd('\0');

                var info = ConvertJsonToString<CompanyInfo>(message); 

                if (info is null)
                {
                    if (!string.IsNullOrEmpty(message))
                        Console.WriteLine($"Read :{message.TrimEnd('\0')}");
                }
                else
                {
                    Console.WriteLine(info);
                }
            }

            Console.WriteLine($"Disconnected!");
        }

        private T ConvertJsonToString<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }            
        }

        public void ClientOpen()
        {
            ClientStream = new NamedPipeClientStream(PipeName);

            ClientStream.Connect(TIMEOUT); 
        }

        public async void Write(string message)
        {
            if (string.IsNullOrEmpty(message)) 
                return; 

            var bytes = Encoding.UTF8.GetBytes(message);

            await ClientStream.WriteAsync(bytes, 0, bytes.Length);
            ClientStream.Flush();
        }
        
        public async void WriteObject(object info)
        {
            if (info is null)  
                return; 

            var json = JsonConvert.SerializeObject(info);

            var bytes = Encoding.UTF8.GetBytes(json);

            await ClientStream.WriteAsync(bytes, 0, bytes.Length);
            ClientStream.Flush();
        }
    } 
}
