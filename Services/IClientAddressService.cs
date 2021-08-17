using ClientsAdmin.API.Database;
using ClientsAdmin.API.Models;
using ClientsAdmin.API.Models.Request;
using ClientsAdmin.API.Models.Responses;

namespace ClientsAdmin.API.Services
{
    public interface IClientAddressService
    {
        ClientAddressResponse Create(ClientAddressRequest request);
        PaginatedResponse<ClientAddressResponse> GetAll(int clientId, PaginationParameters pagination = null);
        ClientAddressResponse Update(int clientId, int addressId, ClientAddressRequest request);
    }
}