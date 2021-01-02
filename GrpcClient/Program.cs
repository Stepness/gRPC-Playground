using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var connection = new Greeter.GreeterClient(channel);
            var connection2 = new Client.ClientClient(channel);
            do
            {
                Console.WriteLine(" 1 - Per Salutare \n 2 - Per ricevere \n 3 - Per inviare");
                switch (Console.ReadLine())
                {
                    case "1":

                        var input1 = new HelloRequest { Name = "Step" };
                        var reply = await connection.SayHelloAsync(input1);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(reply.Message);
                        break;

                    case "2":
                        for (int i = 0; i < 5; i++)
                        {
                            var clientRequested = new ClientLookupModel { Id = i };

                            var reply2 = await connection2.GetClientInfoAsync(clientRequested);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Age:{reply2.Age}\n FirstName:{reply2.FirstName}\n LastName:{reply2.LastName}\n IsItWarner?:{reply2.IsIt}");
                        }
                        break;

                    case "3":
                        var input3 = new ClientModel { Age = 10, FirstName = "Dot", LastName = "Princess Angelina Contessa Louisa Francesca Banana Fanna Bo Besca III", IsIt = true };
                        var reply3 = await connection2.SaveClientInfoAsync(input3);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(reply3.Success);
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("\n\n");
            }
            while (true);
        }
    }
}
