using CarPolicy.Domain.Entities;
using CarPolicy.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Interfaces
{
    public interface IPolicyServices
    {
        Task<Policy> GetPolicyByNumberOrPlate(string id);
        Task<GeneralResponse> CreatePolicy(Policy policy);
        Task<Policy> GetPolicyByNumberOrPlateSimulation(string id);
        Task<GeneralResponse> CreatePolicySimulation(Policy policy);
    }
}
