﻿namespace DataLayer.Domain
{
    public class movie_clicks
    {
        public string tconst { get; set; }
        public int amount { get; set; }

        public virtual movie_title titles { get; set; }

    }
}
