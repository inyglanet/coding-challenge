using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BuisnessLayer.Service;
using Insurance.Entity;
using Insurance.BuisnessLayer.Exceptions;

namespace Insurance.BuisnessLayer.Repository
{
    public class InsuranceRepository : IInsuranceService
    {
        private readonly List<Policy> policyDatabase = new List<Policy>();

        public bool CreatePolicy(Policy policy)
        {
            if (GetPolicy(policy.PolicyId) != null)
            {
                throw new PolicyAlreadyExistException($"Policy with ID {policy.PolicyId} already exists.");
            }

            policyDatabase.Add(policy);
            return true; // Successfully added the policy
        }

        public Policy GetPolicy(string policyId)
        {
            var policy = policyDatabase.Find(p => p.PolicyId == policyId);
            if (policy == null)
            {
                throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");
            }
            return policy;
        }

        public IEnumerable<Policy> GetAllPolicies()
        {
            return policyDatabase;
        }

        public bool UpdatePolicy(Policy updatedPolicy)
        {
            var existingPolicy = GetPolicy(updatedPolicy.PolicyId);
            existingPolicy.PolicyName = updatedPolicy.PolicyName;
            existingPolicy.PremiumAmount = updatedPolicy.PremiumAmount;
            return true; 
        }

        public bool DeletePolicy(string policyId)
        {
            var policy = GetPolicy(policyId);
            policyDatabase.Remove(policy);
            return true;
        }
    }
}
