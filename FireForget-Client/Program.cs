using System;
using System.Text;
using ZMQ;

namespace ZeroMq
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            using (var client = context.Socket(SocketType.PUSH))
            {
                client.Connect("tcp://localhost:5555");
                for (int i = 0; i < 100; i++)
                {
                    string mensage = "Prueba " + i.ToString();
                    client.Send(mensage, Encoding.UTF8);
                    Console.WriteLine("Enviado: " + mensage);
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.ReadKey();
        }
    }
}
