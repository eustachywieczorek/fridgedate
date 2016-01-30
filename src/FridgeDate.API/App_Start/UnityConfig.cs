using AutoMapper;
using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;
using FridgeDate.Data.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace FridgeDate.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IRepository<FoodItem>, Repository<FoodItem>>();
            container.RegisterInstance<IMapper>(MapperBootstap.CreateMapper());
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}