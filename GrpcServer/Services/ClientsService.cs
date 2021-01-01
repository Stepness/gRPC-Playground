using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class ClientsService : Client.ClientBase
    {
        private readonly ILogger<ClientsService> _logger;

        public ClientsService(ILogger<ClientsService> logger)
        {
            _logger = logger;
        }

        public override Task<ClientModel> GetClientInfo(ClientLookupModel request, ServerCallContext context)
        {
            ClientModel output = new ClientModel();

            if (request.Id == 1)
            {
                output.Age = 142;
                output.FirstName = "Egmonte";
                output.LastName = "Natale";
            }
            else if(request.Id == 3)
            {
                output.Age = 14;
                output.FirstName = "Wakko";
                output.LastName = "Warner";
                output.IsIt = true;
            }
            else if( request.Id == 2)
            {
                output.Age = 10;
                output.FirstName = "Dot";
                output.LastName = "Princess Angelina Contessa Louisa Francesca Banana Fanna Bo Besca III";
                output.IsIt = true;
            }

            return Task.FromResult(output);
        }
    }
}
