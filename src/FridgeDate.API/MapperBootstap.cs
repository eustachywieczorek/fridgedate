using AutoMapper;
using FridgeDate.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.API
{
    public class MapperBootstap
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(
            c => {
                c.CreateMap<FoodItem, Core.Models.FoodItem>().ReverseMap();
                c.CreateMap<BarCode, Core.Models.BarCode>().ReverseMap();
                c.CreateMap<User, Core.Models.User>().ReverseMap();
                c.CreateMap<FoodItemUser, Core.Models.FoodItemUser>().ReverseMap();
            }
            );
            return config.CreateMapper();
        }
    }
}
