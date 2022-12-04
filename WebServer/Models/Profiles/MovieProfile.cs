using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() {
            CreateMap<movie_title, movieModel>();
        }
    }
}
