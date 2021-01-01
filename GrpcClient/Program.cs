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
            //var input = new HelloRequest { Name = "Step" };

            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);

            //var reply = await client.SayHelloAsync(input);

            //Console.WriteLine(reply.Message);


            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var clientClient = new Client.ClientClient(channel);

            for (int i = 0; i < 5; i++)
            {
                var clientRequested = new ClientLookupModel { Id = i };

                var reply = await clientClient.GetClientInfoAsync(clientRequested);

                Console.WriteLine($"Age:{reply.Age}\n FirstName:{reply.FirstName}\n LastName:{reply.LastName}\n IsItWarner?:{reply.IsIt}");
            }
            Console.ReadLine();
        }
    }
}
