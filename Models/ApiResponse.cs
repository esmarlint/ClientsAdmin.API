using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
