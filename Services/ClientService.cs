using ClientsAdmin.API.Context;
using ClientsAdmin.API.Database;
using ClientsAdmin.API.Extensions;
using ClientsAdmin.API.Models;
using ClientsAdmin.API.Models.Request;
using ClientsAdmin.API.Models.Responses;
using Microsoft.EntityFrameworkCore;
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

        public ClientResponse CreateClient(CreateClientRequest request)
        {
            var client = ConvertCreateClientRequestToClient(request);
            var entry = context.Clients.Add(client);
            context.SaveChanges();

            var result = ConvertClientToClientResponse(entry.Entity);

            return result;
        }

        public ClientResponse GetClient(int id)
        {
            Client client = context.Clients
                .AsNoTracking()
                .Include(e => e.ClientsAdresses)
                .FirstOrDefault(c => c.Id == id);

            if (client == null) return null;

            ClientResponse response = ConvertClientToClientResponse(client);

            return response;
        }

        public PaginatedResponse<ClientResponse> GetClients(PaginationParameters pagination = null)
        {
            var data = new PaginatedResponse<ClientResponse>();
            data.Page = 1;

            var result = context.Clients.AsNoTracking();

            if (pagination != null)
            {
                data.Total = result.Count();
                data.Page = pagination.Page;
                data.PageSize = pagination.PageSize;

                result = result.Paginate(pagination.Page, pagination.PageSize);
            }


            data.Data = result.Select(e => ConvertClientToClientResponse(e))
                .ToList();

            return data;
        }

        public static ClientResponse ConvertClientToClientResponse(Client client)
        {
            ClientResponse response = new ClientResponse();
            response.Id = client.Id;
            response.Phone = client.Phone;
            response.Rnc = client.Rnc;
            response.SocialReason = client.SocialReason;
            response.ComercialName = client.ComercialName;
            response.Adresses = client.ClientsAdresses.Count;

            return response;
        }

        public static Client ConvertCreateClientRequestToClient(CreateClientRequest request)
        {
            var response = new Client();

            response.Phone = request.Phone;
            response.Rnc = request.Rnc;
            response.SocialReason = request.SocialReason;
            response.ComercialName = request.ComercialName;

            return response;
        }

    }
}
