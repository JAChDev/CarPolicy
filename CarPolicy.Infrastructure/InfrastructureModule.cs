using Autofac;
using CarPolicy.Domain.Interfaces;
using CarPolicy.Infrastructure.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Infrastructure
{
    public class InfrastructureModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DBRepository>().As<IDBRepository>();
        }
    }
}
