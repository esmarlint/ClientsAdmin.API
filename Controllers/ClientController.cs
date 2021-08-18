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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] PaginationParameters pagination)
        {
            try
            {
                if (pagination != null && (pagination.Page <= 0 || pagination.PageSize <= 0))
                {
                    pagination = null;
                }


                var paginationResult = clientService.GetAll(pagination);

                var response = new ApiPaginatedResponse<ClientResponse>();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClients(int id)
        {
            try
            {
                var response = new ApiResponse<ClientResponse>();
                response.StatusCode = 200;
                response.Data = clientService.GetById(id);

                return await Task.FromResult(response);
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
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
        {
            try
            {
                var response = new ApiResponse<ClientResponse>();
                response.StatusCode = 201;
                response.Data = clientService.Create(request);

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

        [HttpPut("{clientId}")]
        public async Task<IActionResult> Update(int clientId, [FromBody] CreateClientRequest request)
        {
            try
            {
                var response = new ApiResponse<ClientResponse>();
                response.StatusCode = 201;
                response.Data = clientService.Update(clientId, request);

                return StatusCode(200, response);
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
