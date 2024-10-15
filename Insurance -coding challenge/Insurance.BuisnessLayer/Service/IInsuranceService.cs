﻿using System;
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
        Policy GetPolicy(int policyId);
        IEnumerable<Policy> GetAllPolicies();
        bool UpdatePolicy(Policy policy);
        bool DeletePolicy(int policyId);
    }
}
