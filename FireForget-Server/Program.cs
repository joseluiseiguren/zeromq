using System;
using System.Text;
using ZMQ;

namespace FireForget_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            using (var server = context.Socket(SocketType.PULL))
            {
                server.Bind("tcp://*:5555");

                while(true)
                {
                    var message = server.Recv(Encoding.UTF8);
                    Console.WriteLine("Recibido: " + message);
                }
            }
        }
    }
}
