using ClientsAdmin.API.Database;
using ClientsAdmin.API.Models;
using ClientsAdmin.API.Models.Request;
using ClientsAdmin.API.Models.Responses;

namespace ClientsAdmin.API.Services
{
    public interface IClientAddressService
    {
        ClientsAdress Create(ClientAddressRequest request);
        PaginatedResponse<ClientAddressResponse> GetAll(int clientId, PaginationParameters pagination = null);
        int Update(ClientAddressRequest request);
    }
}