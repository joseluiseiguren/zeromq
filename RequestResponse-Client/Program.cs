using System;
using System.Text;
using ZMQ;

namespace RequestResponse_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            using (var client = context.Socket(SocketType.REQ))
            {
                client.Connect("tcp://localhost:5555");
                for (int i = 0; i < 100; i++)
                {
                    string mensage = "Prueba " + i.ToString();
                    client.Send(mensage, Encoding.UTF8);
                    Console.WriteLine("Enviado: " + mensage);

                    Console.WriteLine("Esperando respuesta del server...");

                    var replyMsg = client.Recv(Encoding.UTF8);
                    Console.WriteLine("Resp del Server: " + replyMsg);
                    Console.WriteLine();

                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.ReadKey();
        }
    }
}
