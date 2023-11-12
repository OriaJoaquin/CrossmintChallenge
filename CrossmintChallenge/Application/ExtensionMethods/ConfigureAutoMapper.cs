using AutoMapper;
using CrossmintChallenge.Core.API.Requests;
using CrossmintChallenge.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossmintChallenge.Application.ExtensionMethods
{
    public static class ConfigureAutoMapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Polyanet, CreatePolyanetRequest>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
