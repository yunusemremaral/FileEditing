namespace ImdbRandomMovie.Models
{
    public class MovieFilterViewModel
    {
        public List<MovieRatingModel> Movies { get; set; }
        public string Genre { get; set; }
        public int MinRating { get; set; }
        public int MinVotes { get; set; }

    }
}
