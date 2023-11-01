using AutoMapper;
using CarPolicy.Domain.Entities;

namespace CarPolicy.WebApi.Models
{
    public class WebApiModel:Profile
    {
        public WebApiModel()
        {
            CreateMap<Policy, PolicyModel>();
            CreateMap<PolicyModel, Policy>();
        }
    }
}
