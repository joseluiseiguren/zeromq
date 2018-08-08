using System;
using System.Text;
using ZMQ;

namespace PublisherSubscriber_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            using (var client = context.Socket(SocketType.PUB))
            {
                client.Bind("tcp://*:5555");
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
