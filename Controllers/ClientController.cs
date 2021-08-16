using ClientsAdmin.API.Database;
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
        public async Task<dynamic> GetClients()
        {
            var result = await Task.FromResult(clientService.GetClients());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<dynamic> GetClients(int id)
        {
            var result = await Task.FromResult(clientService.GetClient(id));
            return result;
        }

        [HttpPost]
        public async Task<dynamic> CreateClient([FromBody] Client client)
        {
            var result = await Task.FromResult(clientService.CreateClient(client));
            return result;
        }

    }
}
