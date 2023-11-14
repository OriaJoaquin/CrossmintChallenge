using AutoMapper;
using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Entities.API.Requests;
using CrossmintChallenge.Core.Interfaces.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                cfg.CreateMap<Cometh, CreateComethRequest>();
                cfg.CreateMap<Soloon, CreateSoloonRequest>();
                cfg.CreateMap<Polyanet, IAstralObjectRequest>().As<CreatePolyanetRequest>();
                cfg.CreateMap<Cometh, IAstralObjectRequest>().As<CreateComethRequest>();
                cfg.CreateMap<Soloon, IAstralObjectRequest>().As<CreateSoloonRequest>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
