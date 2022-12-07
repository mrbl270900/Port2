namespace DataLayer.Domain
{
    public class user_bookmark_name
    {
        public string userid { get; set; }

        public string nconst { get; set; }

        public virtual person persons { get; set; }

        public virtual user user { get; set; }
    }
}
