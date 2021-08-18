using ClientsAdmin.API.Database;
using ClientsAdmin.API.Models;
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
        ClientResponse GetById(int id);

        PaginatedResponse<ClientResponse> GetAll(PaginationParameters pagination = null);

        ClientResponse Create(CreateClientRequest client);
        ClientResponse Update(int clientId, CreateClientRequest request);
    }
}
