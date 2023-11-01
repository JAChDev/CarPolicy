using AutoMapper;
using CarPolicy.Domain.Entities;
using CarPolicy.Domain.Interfaces;
using CarPolicy.Domain.Responses;
using CarPolicy.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarPolicy.WebApi.Controllers
{
    [Route("api/policy")]
    [ApiController]
    public class PolicyController:ControllerBase
    {
        private readonly IPolicyServices _policyServices;
        private readonly IMapper _mapper;

        public PolicyController(IPolicyServices policyServices, IMapper mapper)
        {
            _policyServices = policyServices;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("createPolicy")]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyModel policyModel)
        {
            try
            {
                GeneralResponse response = await _policyServices.CreatePolicy(_mapper.Map<Policy>(policyModel));
                ApiResponse httpResponse = response.Success == false ?
                    new Domain.Responses.ApiResponse() { Status = HttpStatusCode.BadRequest, Message = response.Message } :
                    new Domain.Responses.ApiResponse() { Status = HttpStatusCode.OK, Message = response.Message };

                return httpResponse.Status == HttpStatusCode.OK ? Ok(httpResponse) : BadRequest(httpResponse);

            } catch
            {
                ApiResponse response = new ApiResponse { Status = HttpStatusCode.BadRequest, Message = "Ocurrió un error al insertar la póliza" };
                return BadRequest(response);
            }
        }

        [HttpGet("getPolicy/{data}")]
        public async Task<IActionResult> GetPolicyByNumberOrPlate(string data)
        {
            try
            {
                Policy response = await _policyServices.GetPolicyByNumberOrPlate(data);
                return response != null ? Ok(response) : Ok("No se encontró la póliza consultada");
            }
            catch
            {
                return BadRequest("Ocurrió un error al consultar la información");
            }
        }

        [Authorize]
        [HttpPost("createPolicySimulation")]
        public async Task<IActionResult> CreatePolicySim([FromBody] PolicyModel policyModel)
        {
            try
            {
                GeneralResponse response = await _policyServices.CreatePolicySimulation(_mapper.Map<Policy>(policyModel));
                ApiResponse httpResponse = response.Success == false ?
                    new Domain.Responses.ApiResponse() { Status = HttpStatusCode.BadRequest, Message = response.Message } :
                    new Domain.Responses.ApiResponse() { Status = HttpStatusCode.OK, Message = response.Message };

                return httpResponse.Status == HttpStatusCode.OK ? Ok(httpResponse) : BadRequest(httpResponse);

            }
            catch
            {
                ApiResponse response = new ApiResponse { Status = HttpStatusCode.BadRequest, Message = "Ocurrió un error al insertar la póliza" };
                return BadRequest(response);
            }
        }

        [HttpGet("getPolicySimulation/{data}")]
        public async Task<IActionResult> GetPolicyByNumberOrPlateSim(string data)
        {
            try
            {
                Policy response = await _policyServices.GetPolicyByNumberOrPlateSimulation(data);
                return response != null ? Ok(response) : Ok("No se encontró la póliza consultada");
            }
            catch
            {
                return BadRequest("Ocurrió un error al consultar la información");
            }
        }
    }
}
