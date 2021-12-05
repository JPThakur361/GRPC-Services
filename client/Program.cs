using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string target = "27.0.0.1:50052";
        static async Task Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected Successfully .");
            });
            var client = new SqrtService.SqrtServiceClient(channel);
            var number = 16;
            try
            {
                var response = client.Sqrt(new SqrtResponse() { Number = number });
            }
            catch (Exception)
            {

                throw;
            }

            channel.ShutdownAsync().Wait();
            Console.ReadKey();



        }
    }
}
