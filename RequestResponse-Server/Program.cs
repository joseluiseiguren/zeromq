using System;
using System.Text;
using ZMQ;

namespace RequestResponse_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            using (var server = context.Socket(SocketType.REP))
            {
                server.Bind("tcp://*:5555");
                while (true)
                {
                    var message = server.Recv(Encoding.UTF8);
                    Console.WriteLine("Server - Recibido: " + message);

                    Console.WriteLine("Procesando...");
                    System.Threading.Thread.Sleep(2000);

                    var messageProseced = "Server - Respuesta: OK";
                    server.Send(messageProseced, Encoding.UTF8);
                    Console.WriteLine("Respondido OK");
                    Console.WriteLine();
                }
            }
        }
    }
}
