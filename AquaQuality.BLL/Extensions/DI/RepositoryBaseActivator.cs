using System;
using AquaQuality.BLL.Services;
using AquaQuality.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using AquaQuality.DAL.Interfaces;
namespace AquaQuality.BLL.Extensions.DI
{
    public static class RepositoryBaseActivator
    {
        public static IServiceCollection ActivateGenericRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           
            return services;
        }
    }
}
