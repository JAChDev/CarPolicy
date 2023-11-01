using AutoMapper;
using CarPolicy.Domain.DTOs;
using CarPolicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<PolicyDTO, Policy>();
            CreateMap<Policy, PolicyDTO>();
        }
    }
}
