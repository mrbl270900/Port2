using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer
{
    public class IMDBContext : DbContext
    {
        public DbSet<movie_title> movie_titles { get; set; }
        public DbSet<person> persons { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<movie_akas> movie_akas { get; set; }
        public DbSet<movie_episode> movie_episodes { get; set; }
        public DbSet<movie_clicks> movie_clicks { get; set; }
        public DbSet<movie_partof> movie_partof { get; set; }
        public DbSet<movie_rating> movie_rating { get; set; }
        public DbSet<name_search> name_search { get; set; }
        public DbSet<OMDB_dataset> omdb_dataset { get; set; }
        public DbSet<search_history> search_histories { get; set; }
        public DbSet<title_search> title_searches { get; set; }
        public DbSet<user_bookmark_name> user_bookmark_names { get; set; }
        public DbSet<user_rating> user_rating { get; set; }
        public DbSet<user_bookmark_title> users_bookmark_titles { get; set; }
        public DbSet<wi> wis { get; set; }
        public DbSet<BestMatchOut> bestmatchouts { get; set;}
        public DbSet<MovieActorOut> movieactorout { get; set; }
        public DbSet<WordOut> wordout { get; set; }
        public DbSet<LoginOut> loginout { get; set; }
        public DbSet<CoPlayersOut> coPlayersOuts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("host=cit.ruc.dk;db=cit07;uid=cit07;pwd=kyKAXoOcPVvq");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<movie_title>().ToTable("movie_title");
            modelBuilder.Entity<movie_title>().HasKey(x => new { x.tconst });
            modelBuilder.Entity<movie_title>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<movie_title>().Property(x => x.title).HasColumnName("title");
            modelBuilder.Entity<movie_title>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<movie_title>().Property(x => x.originaltitle).HasColumnName("originaltitle");
            modelBuilder.Entity<movie_title>().Property(x => x.isadult).HasColumnName("isadult");
            modelBuilder.Entity<movie_title>().Property(x => x.startyear).HasColumnName("startyear");
            modelBuilder.Entity<movie_title>().Property(x => x.endyear).HasColumnName("endyear");
            modelBuilder.Entity<movie_title>().Property(x => x.runtimeminutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<movie_title>().Property(x => x.genres).HasColumnName("genres");


            modelBuilder.Entity<movie_episode>().HasOne(x => x.titles).WithOne(m => m.movie_Episode).HasForeignKey<movie_episode>(x => x.tconst);
            modelBuilder.Entity<movie_clicks>().HasOne(x => x.titles).WithOne(m => m.movie_Clicks).HasForeignKey<movie_clicks>(x => x.tconst);
            modelBuilder.Entity<OMDB_dataset>().HasOne(x => x.titles).WithOne(m => m.OMDB_Datasets).HasForeignKey<OMDB_dataset>(x => x.tconst);
            modelBuilder.Entity<movie_rating>().HasOne(x => x.movie_title).WithOne(m => m.movie_Ratings).HasForeignKey<movie_rating>(m => m.tconst);
            modelBuilder.Entity<movie_akas>().HasOne(x => x.movie_titles).WithMany(m => m.movie_Akas).HasForeignKey(m => m.titleid);
            modelBuilder.Entity<movie_partof>().HasOne(x => x.Movie_Title).WithMany(m => m.movie_Partofs).HasForeignKey(m => m.tconst);
            modelBuilder.Entity<title_search>().HasOne(x => x.titles).WithMany(m => m.title_search).HasForeignKey(m => m.tconst);
            modelBuilder.Entity<user_bookmark_title>().HasOne(x => x.titles).WithMany(m => m.users_bookmark_title).HasForeignKey(m => m.tconst);
            modelBuilder.Entity<user_rating>().HasOne(x => x.titles).WithMany(m => m.user_Ratings).HasForeignKey(m => m.tconst);
            modelBuilder.Entity<wi>().HasOne(x => x.titles).WithMany(m => m.wis).HasForeignKey(m => m.tconst);




            modelBuilder.Entity<person>().ToTable("person");
            modelBuilder.Entity<person>().HasKey(x => new { x.nconst });
            modelBuilder.Entity<person>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<person>().Property(x => x.primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<person>().Property(x => x.birthyear).HasColumnName("birthyear");
            modelBuilder.Entity<person>().Property(x => x.deathyear).HasColumnName("deathyear");
            modelBuilder.Entity<person>().Property(x => x.primaryprofession).HasColumnName("primaryprofession");
            modelBuilder.Entity<person>().Property(x => x.name_rating).HasColumnName("name_rating");

            modelBuilder.Entity<movie_partof>().HasOne(x => x.Person).WithMany(m => m.partof).HasForeignKey(m => m.nconst);
            modelBuilder.Entity<name_search>().HasOne(x => x.persons).WithMany(m => m.Name_Searches).HasForeignKey(m => m.nconst);
            modelBuilder.Entity<user_bookmark_name>().HasOne(x => x.persons).WithMany(m => m.user_bookmarks).HasForeignKey(m => m.nconst);


            modelBuilder.Entity<user>().ToTable("users");
            modelBuilder.Entity<user>().HasKey(x => new { x.userid });
            modelBuilder.Entity<user>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<user>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<user>().Property(x => x.admin).HasColumnName("admin");

            modelBuilder.Entity<movie_akas>().ToTable("movie_akas");
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
            modelBuilder.Entity<movie_episode>().Property(x => x.seseasonnumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<movie_episode>().Property(x => x.episodenumber).HasColumnName("episodenumber");
            modelBuilder.Entity<movie_episode>().HasOne(x => x.parenttitles).WithMany(m => m.movie_parents).HasForeignKey(x => x.parenttconst);

            modelBuilder.Entity<movie_partof>().ToTable("movie_partof");
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

            modelBuilder.Entity<movie_clicks>().ToTable("movie_clicks");
            modelBuilder.Entity<movie_clicks>().HasKey(x => new { x.tconst });
            modelBuilder.Entity<movie_clicks>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<movie_clicks>().Property(x => x.amount).HasColumnName("amount");

            modelBuilder.Entity<name_search>().ToTable("name_search");
            modelBuilder.Entity<name_search>().HasKey(x => new { x.userid, x.nconst });
            modelBuilder.Entity<name_search>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<name_search>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<name_search>().Property(x => x.ts_timestamp).HasColumnName("ts_timestamp");

            modelBuilder.Entity<OMDB_dataset>().ToTable("omdb_dataset");
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

            modelBuilder.Entity<user_bookmark_title>().ToTable("user_bookmark_title");
            modelBuilder.Entity<user_bookmark_title>().HasKey(x => new { x.userid, x.tconst });
            modelBuilder.Entity<user_bookmark_title>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<user_bookmark_title>().Property(x => x.tconst).HasColumnName("tconst");

            modelBuilder.Entity<wi>().ToTable("wi");
            modelBuilder.Entity<wi>().HasKey(x => new { x.tconst, x.word, x.field });
            modelBuilder.Entity<wi>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<wi>().Property(x => x.word).HasColumnName("word");
            modelBuilder.Entity<wi>().Property(x => x.field).HasColumnName("field");
            modelBuilder.Entity<wi>().Property(x => x.lexeme).HasColumnName("lexeme");

            modelBuilder.Entity<BestMatchOut>().HasNoKey();
            modelBuilder.Entity<BestMatchOut>().Property(x => x.tconst).HasColumnName("tconst");
            modelBuilder.Entity<BestMatchOut>().Property(x => x.weight).HasColumnName("weight");

            modelBuilder.Entity<LoginOut>().HasNoKey();
            modelBuilder.Entity<LoginOut>().Property(x => x.PassOk).HasColumnName("PassOk");

            modelBuilder.Entity<MovieActorOut>().HasNoKey();
            modelBuilder.Entity<MovieActorOut>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<MovieActorOut>().Property(x => x.primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<MovieActorOut>().Property(x => x.name_rating).HasColumnName("name_rating");

            modelBuilder.Entity<WordOut>().HasNoKey();
            modelBuilder.Entity<WordOut>().Property(x => x.weight).HasColumnName("weight");
            modelBuilder.Entity<WordOut>().Property(x => x.word).HasColumnName("word");

            modelBuilder.Entity<CoPlayersOut>().HasNoKey();
            modelBuilder.Entity<CoPlayersOut>().Property(x => x.nconst).HasColumnName("nconst");
            modelBuilder.Entity<CoPlayersOut>().Property(x => x.name).HasColumnName("name");
            modelBuilder.Entity<CoPlayersOut>().Property(x => x.frequency).HasColumnName("frequency");
        }
    }
}
