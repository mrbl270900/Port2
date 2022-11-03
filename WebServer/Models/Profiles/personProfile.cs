using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class personProfile : Profile
    {
        public personProfile()
        {
            CreateMap<person, personListModel>()
           .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, ProductModel>();
        }
    }
}
