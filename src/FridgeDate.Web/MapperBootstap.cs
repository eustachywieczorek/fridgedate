using AutoMapper;
using FridgeDate.Web.Models;

namespace FridgeDate.Web
{
    public class MapperBootstap
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(
            c => {
                c.CreateMap<FoodItemViewModel, Core.Models.FoodItem>().ReverseMap();
                //c.CreateMap<BarCode, Core.Models.BarCode>().ReverseMap();
                //c.CreateMap<User, Core.Models.User>().ReverseMap();
                //c.CreateMap<FoodItemUser, Core.Models.FoodItemUser>().ReverseMap();
            }
            );
            return config.CreateMapper();
        }
    }
}
