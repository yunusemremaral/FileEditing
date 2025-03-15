namespace ImdbRandomMovie.Models
{
    public class MovieModel
    {
        public string Tconst { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public int StartYear { get; set; }
        public string RuntimeMinutes { get; set; }
        public double? AverageRating { get; set; }
        public int? NumVotes { get; set; }

    }
}
