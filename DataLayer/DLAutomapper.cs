using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models
{
    public class DLautoMapper
    {
        static void Main(string[] args)

        {

            //Initialize the mapper

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<person, movie_partof>();
                // .ForMember(dest => dest.nconst, act => act.MapFrom(src => src.nconst)); --> remember to remove ';' from cfg above
                cfg.CreateMap<person, user_bookmark_title>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<person, user_bookmark_name>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<person, name_search>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<movie_title, movie_akas>()
                .ForMember(dest => dest.titleid, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<movie_title, movie_clicks>();
                cfg.CreateMap<movie_title, movie_rating>();
                cfg.CreateMap<movie_title, movie_partof>();
                cfg.CreateMap<name_search, user>();
                cfg.CreateMap<OMDB_dataset, movie_title>();
                cfg.CreateMap<search_history, user>();
                cfg.CreateMap<title_search, movie_title>();
                cfg.CreateMap<user_rating, user>();
                cfg.CreateMap<wi, movie_title>();


            });
        }
    }
};
