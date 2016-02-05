using AutoMapper;
using FridgeDate.API.Controllers;
using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;
using FridgeDate.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using System.Data.Entity;
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
            container.RegisterType<IUserStore<User>, UserStore<User>>();
            container.RegisterType<UserManager<User>>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, Data.FridgeDateContext>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}