using Crlmall.Data.Repositories;
using Crmall.Domain.Interfaces;
using Crmall.Domain.Interfaces.IService;
using Crmall.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Crmall.CrossCutting.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Services
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IServiceCEP, ServiceCEP>();

            //Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
