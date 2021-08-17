using ClientsAdmin.API.Models;
using ClientsAdmin.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientAddressController : ControllerBase
    {
        private readonly IClientAddressService addressService;

        public ClientAddressController(IClientAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetAll(int clientId, [FromQuery] PaginationParameters pagination)
        {
            var response = addressService.GetAll(clientId);
            return Ok(response);
        }

    }
}
