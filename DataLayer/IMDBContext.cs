using DataLayer.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class IMDBContext : DbContext
    {
        public DbSet<movie_titles> movie_titles { get; set; }
        public DbSet<person> persons { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<movie_akas> movie_akas { get; set; }
        public DbSet<movie_episode> movie_episodes { get; set; }
        public DbSet<movie_partof> movie_partof { get; set; }
        public DbSet<movie_rating> movie_rating { get; set; }
        public DbSet<name_search> name_search { get; set; }
        public DbSet<OMDB_dataset> omdb_dataset { get; set; }
        public DbSet<search_history> search_histories { get; set; }
        public DbSet<title_search> title_searches { get; set; }
        public DbSet<user_bookmark_name> user_bookmark_names { get; set; }
        public DbSet<user_rating> user_rating { get; set; }
        public DbSet<users_bookmark_title> users_bookmark_titles { get; set; }
        public DbSet<wi> wis { get; set; }
        public DbSet<Models.BestMatchOut> bestmatchouts { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("host=cit.ruc.dk;db=cit07;uid=cit07;pwd=kyKAXoOcPVvq");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<movie_titles>().ToTable("movie_title");
            modelBuilder.Entity<movie_titles>().HasKey(x => new { x.tcontst });
            modelBuilder.Entity<movie_titles>().Property(x => x.tcontst).HasColumnName("tcontst");
            modelBuilder.Entity<movie_titles>().Property(x => x.title).HasColumnName("title");
            modelBuilder.Entity<movie_titles>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<movie_titles>().Property(x => x.originaltitle).HasColumnName("originaltitle");
            modelBuilder.Entity<movie_titles>().Property(x => x.isadult).HasColumnName("isadult");
            modelBuilder.Entity<movie_titles>().Property(x => x.startyear).HasColumnName("startyear");
            modelBuilder.Entity<movie_titles>().Property(x => x.endyear).HasColumnName("endyear");
            modelBuilder.Entity<movie_titles>().Property(x => x.runtimeminutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<movie_titles>().Property(x => x.genres).HasColumnName("genres");

            modelBuilder.Entity<person>().ToTable("person");
            modelBuilder.Entity<person>().HasKey(x => new { x.nconst });
            modelBuilder.Entity<person>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<person>().Property(x => x.primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<person>().Property(x => x.birthyear).HasColumnName("birthyear");
            modelBuilder.Entity<person>().Property(x => x.deathyear).HasColumnName("deathyear");
            modelBuilder.Entity<person>().Property(x => x.primaryprofession).HasColumnName("primaryprofession");
            modelBuilder.Entity<person>().Property(x => x.name_rating).HasColumnName("name_rating");

            modelBuilder.Entity<users>().ToTable("users");
            modelBuilder.Entity<users>().HasKey(x => new { x.userid });
            modelBuilder.Entity<users>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<users>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<users>().Property(x => x.admin).HasColumnName("admin");

            modelBuilder.Entity<movie_akas>().ToTable("users");
            modelBuilder.Entity<movie_akas>().HasKey(x => new { x.titleid, x.ordering });
            modelBuilder.Entity<movie_akas>().Property(x => x.titleid).HasColumnName("titleid");
            modelBuilder.Entity<movie_akas>().Property(x => x.ordering).HasColumnName("ordering");
            modelBuilder.Entity<movie_akas>().Property(x => x.title).HasColumnName("title");
            modelBuilder.Entity<movie_akas>().Property(x => x.region).HasColumnName("region");
            modelBuilder.Entity<movie_akas>().Property(x => x.language).HasColumnName("language");
            modelBuilder.Entity<movie_akas>().Property(x => x.types).HasColumnName("types");
            modelBuilder.Entity<movie_akas>().Property(x => x.attributes).HasColumnName("attributes");
            modelBuilder.Entity<movie_akas>().Property(x => x.isoriginaltitle).HasColumnName("isoriginaltitle");

            modelBuilder.Entity<movie_episode>().ToTable("movie_episode");
            modelBuilder.Entity<movie_episode>().HasKey(x => new { x.tconst});
            modelBuilder.Entity<movie_episode>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<movie_episode>().Property(x => x.parenttconst).HasColumnName("parenttconst");
            modelBuilder.Entity<movie_episode>().Property(x => x.seseasonnumber).HasColumnName("seseasonnumber");
            modelBuilder.Entity<movie_episode>().Property(x => x.episodenumber).HasColumnName("episodenumber");

            modelBuilder.Entity<movie_partof>().ToTable("movie_episode");
            modelBuilder.Entity<movie_partof>().HasKey(x => new { x.tconst, x.ordering, x.nconst });
            modelBuilder.Entity<movie_partof>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<movie_partof>().Property(x => x.ordering).HasColumnName("ordering");
            modelBuilder.Entity<movie_partof>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<movie_partof>().Property(x => x.category).HasColumnName("category");
            modelBuilder.Entity<movie_partof>().Property(x => x.job).HasColumnName("job");
            modelBuilder.Entity<movie_partof>().Property(x => x.characters).HasColumnName("characters");

            modelBuilder.Entity<movie_rating>().ToTable("movie_rating");
            modelBuilder.Entity<movie_rating>().HasKey(x => new { x.tconst});
            modelBuilder.Entity<movie_rating>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<movie_rating>().Property(x => x.averagerating).HasColumnName("averagerating");
            modelBuilder.Entity<movie_rating>().Property(x => x.numvotes).HasColumnName("numvotes");

            modelBuilder.Entity<name_search>().ToTable("name_search");
            modelBuilder.Entity<name_search>().HasKey(x => new { x.userid, x.nconst });
            modelBuilder.Entity<name_search>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<name_search>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<name_search>().Property(x => x.ts_timestamp).HasColumnName("ts_timestamp");

            modelBuilder.Entity<OMDB_dataset>().ToTable("OMDB_dataset");
            modelBuilder.Entity<OMDB_dataset>().HasKey(x => new { x.tconst});
            modelBuilder.Entity<OMDB_dataset>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<OMDB_dataset>().Property(x => x.poster).HasColumnName("poster");
            modelBuilder.Entity<OMDB_dataset>().Property(x => x.plot).HasColumnName("plot");

            modelBuilder.Entity<search_history>().ToTable("search_history");
            modelBuilder.Entity<search_history>().HasKey(x => new { x.userid, x.searchword, x.sh_timestamp });
            modelBuilder.Entity<search_history>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<search_history>().Property(x => x.searchword).HasColumnName("searchword");
            modelBuilder.Entity<search_history>().Property(x => x.sh_timestamp).HasColumnName("sh_timestamp");

            modelBuilder.Entity<title_search>().ToTable("title_search");
            modelBuilder.Entity<title_search>().HasKey(x => new { x.userid, x.tconst});
            modelBuilder.Entity<title_search>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<title_search>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<title_search>().Property(x => x.ts_timestamp).HasColumnName("ts_timestamp");

            modelBuilder.Entity<user_bookmark_name>().ToTable("user_bookmark_name");
            modelBuilder.Entity<user_bookmark_name>().HasKey(x => new { x.userid, x.nconst });
            modelBuilder.Entity<user_bookmark_name>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<user_bookmark_name>().Property(x => x.nconst).HasColumnName("nconst");

            modelBuilder.Entity<user_rating>().ToTable("user_rating");
            modelBuilder.Entity<user_rating>().HasKey(x => new { x.userid, x.tconst });
            modelBuilder.Entity<user_rating>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<user_rating>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<user_rating>().Property(x => x.rating).HasColumnName("rating");

            modelBuilder.Entity<users_bookmark_title>().ToTable("users_bookmark_title");
            modelBuilder.Entity<users_bookmark_title>().HasKey(x => new { x.userid, x.tconst });
            modelBuilder.Entity<users_bookmark_title>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<users_bookmark_title>().Property(x => x.tconst).HasColumnName("tconst");

            modelBuilder.Entity<wi>().ToTable("wi");
            modelBuilder.Entity<wi>().HasKey(x => new { x.tconst, x.word, x.field });
            modelBuilder.Entity<wi>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<wi>().Property(x => x.word).HasColumnName("word");
            modelBuilder.Entity<wi>().Property(x => x.field).HasColumnName("field");
            modelBuilder.Entity<wi>().Property(x => x.lexeme).HasColumnName("lexeme");
        }
    }
}
