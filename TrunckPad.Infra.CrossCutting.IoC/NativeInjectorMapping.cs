using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrunckPad.Application.Interfaces;
using TrunckPad.Application.Services;
using TrunckPad.Domain.Interfaces.Repositorys;
using TrunckPad.Domain.Interfaces.Services;
using TrunckPad.Domain.Services;
using TrunckPad.Infra.Data.Context;
using TrunckPad.Infra.Data.Repository;

namespace TrunckPad.Infra.CrossCutting.IoC
{
    public class NativeInjectorMapping
    {
        public static void RegisterServices(IServiceCollection service)
        {
            
            service.AddScoped<ContextTruckPad>();

            service.AddScoped<IRepositoryTipoCaminhao, RepositoryTipoCaminhao>();
            service.AddScoped<IRepositoryCaminhoneiro, RepositoryCaminhoneiro>();
            service.AddScoped<IRepositoryEndereco, RepositoryEndereco>();
            service.AddScoped<IRepositoryCheckin, RepositoryCheckin>();


            service.AddScoped<IServiceTipoCaminhao, ServiceTipoCaminhao>();
            service.AddScoped<IServiceCaminhoneiro, ServiceCaminhoneiro>();
            service.AddScoped<IServiceGeo, ServiceGeo>();
            service.AddScoped<IServiceEndereco, ServiceEndereco>();
            service.AddScoped<IServiceCheckin, ServiceCheckin>();


            service.AddScoped<IApplicationTipoCaminhao, ApplicationTipoCaminhao>();
            service.AddScoped<IApplicationCaminhoneiro, ApplicationCaminhoneiro>();
            service.AddScoped<IApplicationEndereco, ApplicationEndereco>();
            service.AddScoped<IApplicationCheckin, ApplicationCheckin>();
        }
    }
}
