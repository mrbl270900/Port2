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

                cfg.CreateMap<person, movie_partof>();
                // .ForMember(dest => dest.nconst, act => act.MapFrom(src => src.nconst)); --> remember to remove ';' from cfg above
                cfg.CreateMap<person, users_bookmark_title>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<person, user_bookmark_name>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<person, name_search>()
                .ForMember(dest => dest.userid, act => act.MapFrom(src => src.nconst));
                cfg.CreateMap<movie_titles, movie_akas>()
                .ForMember(dest => dest.titleid, act => act.MapFrom(src => src.tconst));
                cfg.CreateMap<movie_titles, movie_clicks>();
                cfg.CreateMap<movie_titles, movie_rating>();
                cfg.CreateMap<movie_titles, movie_partof>();
                cfg.CreateMap<name_search, users>();
                cfg.CreateMap<OMDB_dataset, movie_titles>();
                cfg.CreateMap<search_history, users>();
                cfg.CreateMap<title_search, movie_titles>();
                cfg.CreateMap<user_rating, users>();
                cfg.CreateMap<wi, movie_titles>();


            });

            person prs = new person
            {
                nconst = "James",
            };

            //Using automapper
            var mapper = new Mapper(config);
            var usrbkmrk = mapper.Map<user_bookmark_name>(prs);

            Console.WriteLine("Name:" + usrbkmrk.nconst);
            Console.ReadLine();

        }

    }
};

