using AutoMapper;
using DataLayer.Domain;
using WebServer.Models;

namespace WebServer.Profiles
{
    public class PersonProfile : Profile
    {
        public void UserProfile()
        {
            CreateMap<person, PersonMap>()
                .ForMember(
                    dest => dest.url,
                    opt => opt.MapFrom(src => $"http://localhost:5001/api/person/{src.nconst}")
                ).ForMember(
                    dest => dest.primaryname,
                    opt => opt.MapFrom(src => $"{src.primaryname}")
                ).ForMember(
                    dest => dest.birthyear,
                    opt => opt.MapFrom(src => $"{src.birthyear}")
                ).ForMember(
                    dest => dest.deathyear,
                    opt => opt.MapFrom(src => $"{src.deathyear}")
                ).ForMember(
                    dest => dest.primaryprofession,
                    opt => opt.MapFrom(src => $"{src.primaryprofession}")
                ).ForMember(
                    dest => dest.name_rating,
                    opt => opt.MapFrom(src => $"{src.name_rating}")
                ).ForMember(
                    dest => dest.partof,
                    opt => opt.MapFrom(src => $"{src.partof}")
                ).ForMember(
                    dest => dest.user_bookmarks,
                    opt => opt.MapFrom(src => $"{src.user_bookmarks}")
                );
        }
    }
}
