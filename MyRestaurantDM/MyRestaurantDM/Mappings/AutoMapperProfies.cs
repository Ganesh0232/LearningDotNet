using AutoMapper;
using MyRestaurantDM.Models.Domain;
using MyRestaurantDM.Models.DTO;

namespace MyRestaurantDM.Mappings
{
    public class AutoMapperProfies :Profile
    {
        public AutoMapperProfies()
        {
            CreateMap<OrdersModel, OrderDto>()
                .ReverseMap();
           
            CreateMap<AddOrderDto,OrdersModel >()
                .ReverseMap();
            CreateMap<UpdateOrderDto, OrdersModel> ()
                .ReverseMap();

            /*
             * If the property Names doesnt match , use the following code

            CreateMap<OrdersModel, OrderDto>()
                .ForMember(x => x.OrderId, opt => opt.MapFrom(x => x.OrderId))
                .ReverseMap();

             */
        }
    }
}
