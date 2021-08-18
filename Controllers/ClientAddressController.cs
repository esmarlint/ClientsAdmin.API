using ClientsAdmin.API.Models;
using ClientsAdmin.API.Models.Request;
using ClientsAdmin.API.Models.Responses;
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
            try
            {
                var paginationResult = addressService.GetAll(clientId);

                var response = new ApiPaginatedResponse<ClientAddressResponse>();
                response.StatusCode = 200;
                response.Page = paginationResult.Page;
                response.PageSize = paginationResult.PageSize;
                response.Total = paginationResult.Total;
                response.Data = paginationResult.Data;

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    Message = "Request fail"
                });
            }
        }

        [HttpPut("{clientId}/{addressId}")]
        public async Task<IActionResult> Update(int clientId, int addressId ,[FromBody] ClientAddressRequest request)
        {
            try
            {
                var result = addressService.Update(clientId, addressId, request);

                var response = new ApiResponse<ClientAddressResponse>();
                response.StatusCode = 200;
                response.Data = result;

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    Message = "Request fail"
                });
            }
        }

        [HttpDelete("{clientId}/{addressId}")]
        public async Task<IActionResult> Delete(int clientId, int addressId)
        {
            try
            {
                var result = addressService.Delete(clientId, addressId);

                var response = new ApiResponse<ClientAddressResponse>();
                response.StatusCode = 200;
                response.Data = result;

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    Message = "Request fail"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientAddressRequest request)
        {
            try
            {
                var result = addressService.Create(request);

                var response = new ApiResponse<ClientAddressResponse>();
                response.StatusCode = 201;
                response.Data = result;

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    Message = "Request fail"
                });
            }
        }

    }
}
