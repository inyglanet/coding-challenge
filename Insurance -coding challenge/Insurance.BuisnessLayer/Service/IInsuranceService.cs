using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Entity;

namespace Insurance.BuisnessLayer.Service
{
    public interface IInsuranceService
    {
        bool CreatePolicy(Policy policy);
        Policy GetPolicy(string policyId);
        IEnumerable<Policy> GetAllPolicies();
        bool UpdatePolicy(Policy policy);
        bool DeletePolicy(string policyId);
    }
}
