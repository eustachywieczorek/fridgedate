using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using AutoMapper;
using FridgeDate.Data.Models;

[assembly: OwinStartup(typeof(FridgeDate.API.Startup))]

namespace FridgeDate.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            UnityConfig.RegisterComponents();
        }
    }
}
