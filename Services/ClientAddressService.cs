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
    public class ClientAddressService : IClientAddressService
    {
        private readonly ApplicationDbContext context;

        public ClientAddressService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public PaginatedResponse<ClientAddressResponse> GetAll(int clientId, PaginationParameters pagination = null)
        {
            var data = new PaginatedResponse<ClientAddressResponse>();
            data.Page = 1;

            var result = context.ClientsAdresses.AsNoTracking().Where(e => e.IdClient == clientId);

            if (pagination != null)
            {
                data.Total = result.Count();
                data.Page = pagination.Page;
                data.PageSize = pagination.PageSize;

                result = result.Paginate(pagination.Page, pagination.PageSize);
            }

            data.Data = result.Select(e => new ClientAddressResponse
            {
                Id = e.Id,
                IdClient = e.IdClient,
                Address = e.Address,
            })
            .ToList();

            return data;
        }

        public ClientsAdress Create(ClientAddressRequest request)
        {
            var address = new ClientsAdress();
            address.Address = request.Address;
            address.IdClient = request.IdClient;

            var entry = context.ClientsAdresses.Add(address);
            context.SaveChanges();

            return entry.Entity;
        }

        public int Update(ClientAddressRequest request)
        {
            var address = context.ClientsAdresses.FirstOrDefault(e => e.Id == request.Id);
            address.Address = request.Address;
            int result = context.SaveChanges();

            return result;
        }

    }
}
