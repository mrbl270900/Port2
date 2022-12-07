namespace DataLayer.Domain
{
    public class search_history
    {
        public string userid { get; set; }

        public string searchword { get; set; }

        public DateTime sh_timestamp { get; set; }

        public virtual user users { get; set; }

    }
}
