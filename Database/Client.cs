using System;
using System.Collections.Generic;

#nullable disable

namespace ClientsAdmin.API.Database
{
    public partial class Client
    {
        public Client()
        {
            ClientsAdresses = new HashSet<ClientsAdress>();
        }

        public int Id { get; set; }
        public string SocialReason { get; set; }
        public string ComercialName { get; set; }
        public string Rnc { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<ClientsAdress> ClientsAdresses { get; set; }
    }
}
