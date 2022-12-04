using AutoMapper;
using DataLayer.Domain;
using WebServer.Models;

namespace WebServer.Models.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<person, personModel>();
        }
    }
}
