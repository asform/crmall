using Microsoft.Extensions.DependencyInjection;
using System;
using Crmall.Data.AutoMapper;
using AutoMapper;

namespace Crmall.CrossCutting.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
