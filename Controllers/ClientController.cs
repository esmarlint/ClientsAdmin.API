using ClientsAdmin.API.Database;
using ClientsAdmin.API.Models;
using ClientsAdmin.API.Models.Request;
using ClientsAdmin.API.Models.Responses;
using ClientsAdmin.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<ClientResponse>>> GetClients()
        {
            var clients = clientService.GetClients();

            var response = new ApiResponse<List<ClientResponse>>();
            response.StatusCode = 200;
            response.Data = clients;

            return await Task.FromResult(response);
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<ClientResponse>> GetClients(int id)
        {
            var response = new ApiResponse<ClientResponse>();
            response.StatusCode = 200;
            response.Data = clientService.GetClient(id);

            return await Task.FromResult(response);
        }

        [HttpPost]
        public async Task<ApiResponse<ClientResponse>> CreateClient([FromBody] CreateClientRequest request)
        {
            var response = new ApiResponse<ClientResponse>();
            response.StatusCode = 201;
            response.Data = clientService.CreateClient(request);

            return await Task.FromResult(response);
        }

    }
}
