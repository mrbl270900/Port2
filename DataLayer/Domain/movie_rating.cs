namespace DataLayer.Domain
{
    public class movie_rating
    {
        public string tconst { get; set; }

        public float averagerating { get; set; }

        public int numvotes { get; set; }

        public virtual movie_title movie_title { get; set; }
    }
}
