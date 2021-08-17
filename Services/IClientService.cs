using ClientsAdmin.API.Database;
using ClientsAdmin.API.Models.Request;
using ClientsAdmin.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Services
{
    public interface IClientService
    {
        ClientResponse GetClient(int id);

        List<ClientResponse> GetClients();

        ClientResponse CreateClient(CreateClientRequest client);
    }
}
