using AutoMapper;
using CarPolicy.Domain.DTOs;
using CarPolicy.Domain.Entities;
using CarPolicy.Domain.Interfaces;
using CarPolicy.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Services
{
    public class PolicyServices : IPolicyServices
    {
        private readonly IDBRepository _dbRepository;
        private readonly IMapper _mapper;

        public PolicyServices(IDBRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<GeneralResponse> CreatePolicy(Policy policy)
        {
            try
            {
                if(DateTime.Now > policy.PolicyEndDate)
                {
                    GeneralResponse response = new GeneralResponse
                    {
                        Success = false,
                        Message = "La póliza no está vigente"
                    };
                    return response;
                }
                PolicyDTO policyDTO = _mapper.Map<PolicyDTO>(policy);
                GeneralResponse create = await _dbRepository.CreatePolicy(policyDTO);
                return create;
            }
            catch
            {
                GeneralResponse response = new GeneralResponse
                {
                    Success = false,
                    Message = "Ocurrió un error al insertar la póliza"
                };
                return response;
            }
        }

        public async Task<GeneralResponse> CreatePolicySimulation(Policy policy)
        {
            try
            {
                if (DateTime.Now > policy.PolicyEndDate)
                {
                    GeneralResponse response = new GeneralResponse
                    {
                        Success = false,
                        Message = "La póliza no está vigente"
                    };
                    return response;
                }
                PolicyDTO policyDTO = _mapper.Map<PolicyDTO>(policy);
                GeneralResponse create = await _dbRepository.CreatePolicySimulation(policyDTO);
                return create;
            }
            catch
            {
                GeneralResponse response = new GeneralResponse
                {
                    Success = false,
                    Message = "Ocurrió un error al insertar la póliza"
                };
                return response;
            }
        }

        public async Task<Policy> GetPolicyByNumberOrPlate(string id)
        {
            try
            {
                Policy policy = _mapper.Map<Policy>(await _dbRepository.GetPolicyByNumberOrPlate(id));
                return policy;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Policy> GetPolicyByNumberOrPlateSimulation(string id)
        {
            try
            {
                Policy policy = _mapper.Map<Policy>(await _dbRepository.GetPolicyByNumberOrPlateSimulation(id));
                return policy;
            }
            catch
            {
                return null;
            }
        }
    }
}
