using ClientsAdmin.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Services
{
    public interface IClientService
    {
        Client GetClient(int id);

        List<Client> GetClients();

        Client CreateClient(Client client);
    }
}
