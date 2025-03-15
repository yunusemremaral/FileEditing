namespace ImdbRandomMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }  // Film ID'si
        public string Title { get; set; }  // Film başlığı
        public string Genre { get; set; }  // Film türü
        public int ReleaseYear { get; set; }  // Çıkış yılı

    }
}
