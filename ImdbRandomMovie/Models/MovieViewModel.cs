namespace ImdbRandomMovie.Models
{
    public class MovieViewModel
    {
        public string Tconst { get; set; }
        public string PrimaryTitle { get; set; }
        public int? StartYear { get; set; }
        public string Genres { get; set; }
        public double? AverageRating { get; set; } // TitleRatings'den gelecek
        public string Directors { get; set; } // TitleCrew'den gelecek

    }
}
