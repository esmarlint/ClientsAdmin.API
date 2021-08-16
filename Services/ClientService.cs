using ClientsAdmin.API.Context;
using ClientsAdmin.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext context;

        public ClientService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Client CreateClient(Client client)
        {
            var entry = context.Clients.Add(client);
            context.SaveChanges();

            return entry.Entity;
        }

        public Client GetClient(int id)
        {
            Client client = context.Clients.FirstOrDefault(c => c.Id == id);
            return client;
        }

        public List<Client> GetClients()
        {
            return context.Clients.ToList();
        }
    }
}
