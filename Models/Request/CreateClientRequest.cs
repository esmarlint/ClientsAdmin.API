using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Models.Request
{
    public class CreateClientRequest
    {
        public string SocialReason { get; set; }
        public string ComercialName { get; set; }
        public string Rnc { get; set; }
        public string Phone { get; set; }
    }
}
