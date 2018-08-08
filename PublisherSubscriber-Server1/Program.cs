using System;
using System.Text;
using ZMQ;

namespace PublisherSubscriber_Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            using (var server = context.Socket(SocketType.SUB))
            {
                server.Connect("tcp://localhost:5555");
                server.Subscribe("", Encoding.UTF8);
                while (true)
                {
                    var message = server.Recv(Encoding.UTF8);
                    Console.WriteLine("Server 1 - Recibido: " + message);
                }
            }
        }
    }
}
