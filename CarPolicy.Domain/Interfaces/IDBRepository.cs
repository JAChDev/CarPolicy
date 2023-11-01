using CarPolicy.Domain.DTOs;
using CarPolicy.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Interfaces
{
    public interface IDBRepository
    {
        Task<PolicyDTO> GetPolicyByNumberOrPlate(string id);
        Task<GeneralResponse> CreatePolicy(PolicyDTO policy);
        Task<PolicyDTO> GetPolicyByNumberOrPlateSimulation(string id);
        Task<GeneralResponse> CreatePolicySimulation(PolicyDTO policy);

    }
}
