using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public long ContactNumber { get; set; }
        public List<Policy> Policy{ get; set; }
    }
}
