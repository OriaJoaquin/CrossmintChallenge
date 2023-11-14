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
                cfg.CreateMap<Polyanet, IAstralObjectRequest>()
                    .ConstructUsing(src => new CreatePolyanetRequest());
                cfg.CreateMap<Cometh, IAstralObjectRequest>()
                    .ConstructUsing(src => new CreateComethRequest(src.Direction));
                cfg.CreateMap<Soloon, IAstralObjectRequest>()
                    .ConstructUsing(src => new CreateSoloonRequest(src.Color));

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
