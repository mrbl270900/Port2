namespace DataLayer.Domain
{
    public class name_search
    {
        public string userid { get; set; }

        public string nconst { get; set; }

        public DateTime ts_timestamp { get; set; }

        public virtual user users { get; set; }

        public virtual person persons { get; set; }

    }
}
