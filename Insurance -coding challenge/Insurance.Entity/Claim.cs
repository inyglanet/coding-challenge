using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Entity
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimName { get; set; }
        public DateTime DateField { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }
        public string Policy { get; set; }
        public List<Client> Client { get; set; }
        

    }
}
