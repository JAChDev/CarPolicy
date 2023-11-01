using Autofac;
using CarPolicy.Domain.Interfaces;
using CarPolicy.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain
{
    public class DomainModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PolicyServices>().As<IPolicyServices>();
        }
    }
}
