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

        public ClientAddressResponse Create(ClientAddressRequest request)
        {
            var address = new ClientsAdress();
            address.Address = request.Address;
            address.IdClient = request.IdClient;

            context.ClientsAdresses.Add(address);
            context.SaveChanges();

            var result = new ClientAddressResponse();
            result.Address = address.Address;
            result.Id = address.Id;
            result.IdClient = address.IdClient;

            return result;
        }

        public ClientAddressResponse Update(int clientId, int addressId, ClientAddressRequest request)
        {
            var address = context.ClientsAdresses.FirstOrDefault(e => e.IdClient == clientId && e.Id == addressId);
            address.Address = request.Address;
            context.ClientsAdresses.Update(address);
            context.SaveChanges();

            var result = new ClientAddressResponse();
            result.Address = address.Address;
            result.Id = address.Id;
            result.IdClient = address.IdClient;

            return result;
        }

        public ClientAddressResponse Delete(int clientId,int addressId)
        {
            var address = context.ClientsAdresses.FirstOrDefault(e => e.IdClient == clientId && e.Id == addressId);
            
            context.ClientsAdresses.Remove(address);
            context.SaveChanges();

            var result = new ClientAddressResponse();
            result.Address = address.Address;
            result.Id = address.Id;
            result.IdClient = address.IdClient;

            return result;
        }

    }
}
