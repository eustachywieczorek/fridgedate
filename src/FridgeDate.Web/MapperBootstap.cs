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
                c.CreateMap<FoodItemViewModel, Core.Models.FoodItem>();
                c.CreateMap<Core.Models.FoodItem, FoodItemViewModel>()
                    .ForMember(dest => dest.BarCodeId, p => p.MapFrom(src => src.BarCode.Identifier));
            }
            );
            return config.CreateMapper();
        }
    }
}
