using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BuisnessLayer.Service;
using Insurance.Entity;
using Insurance.BuisnessLayer.Exceptions;
using Insurance.BuisnessLayer.Util;

namespace Insurance.BuisnessLayer.Repository
{
    public class InsuranceRepository : IInsuranceService
    {
        private readonly DBConnection dBConnection;

        public bool CreatePolicy(Policy policy)
        {
            if (GetPolicy(dBConnection.PolicyId) != null)
            {
                throw new PolicyAlreadyExistException($"Policy with ID {policy.PolicyId} already exists.");
            }

            dBConnection.Add(policy);
            return true;
        }

        public Policy GetPolicy(string policyId)
        {
            var policy = dBConnection.Find(p => p.PolicyId == policyId);
            if (policy == null)
            {
                throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
            }
            return policy;
        }

        public IEnumerable<Policy> GetAllPolicies()
        {
            return (IEnumerable<Policy>)dBConnection;
        }

        public bool UpdatePolicy(Policy updatedPolicy)
        {
            var existingPolicy;
            existingPolicy.PolicyId=updatedPolicy.PolicyId;
            existingPolicy.PolicyName = updatedPolicy.PolicyName;
            existingPolicy.Amount = updatedPolicy.Amount;
            return true; 
        }

        public bool DeletePolicy(string policyId)
        {
            var policy = GetPolicy(policyId);
            dBConnection.Remove(policy);
            return true;
        }
    }
}
