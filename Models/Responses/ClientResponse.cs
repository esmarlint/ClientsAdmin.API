using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAdmin.API.Models.Responses
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string SocialReason { get; set; }
        public string ComercialName { get; set; }
        public string Rnc { get; set; }
        public string Phone { get; set; }
        public int Adresses { get; set; }
    }

    public class ClientAddressResponse
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string Address { get; set; }
    }
}
