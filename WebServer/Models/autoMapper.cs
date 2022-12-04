using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models
{
    public class autoMapper
    {
        static void Main(string[] args)

        {

            //Initialize the mapper

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<person, movie_partof>()
                .ForMember(dest => dest.nconst, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<movie_title, user_bookmark_title>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<person, user_bookmark_name>()
                .ForMember(dest => dest.nconst, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<person, name_search>()
                .ForMember(dest => dest.nconst, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<movie_title, movie_akas>()
                .ForMember(dest => dest.titleid, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<movie_title, movie_clicks>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<movie_title, movie_rating>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<movie_title, movie_partof>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<name_search, user>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.userid));
                cfg.CreateMap<OMDB_dataset, movie_title>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<search_history, user>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.userid));
                cfg.CreateMap<title_search, movie_title>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<user_rating, user>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.userid));
                cfg.CreateMap<wi, movie_title>()
                .ForMember(dest => dest.tconst, act => act.MapFrom(src => src.tconst));


            });
        }
    }
};

