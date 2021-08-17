using System;
using System.Collections.Generic;

#nullable disable

namespace ClientsAdmin.API.Database
{
    public partial class ClientsAdress
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string Address { get; set; }

        public virtual Client IdClientNavigation { get; set; }
    }
}
