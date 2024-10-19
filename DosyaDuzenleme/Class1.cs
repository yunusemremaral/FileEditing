using System.Formats.Asn1;
using System.Globalization;

namespace DosyaDuzenleme
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            // Dosya yolu ve dosya ismi
            string tsvFilePath = @"C:\a\title.basics - Copy.tsv"; // Orijinal dosya yolu
            string outputFilePath = @"C:\a\filtered_movies.tsv";  // Yeni dosya yolu

            // Dosyayı satır satır okuyun
            var lines = File.ReadAllLines(tsvFilePath);

            // Başlık satırını (ilk satır) alın
            var header = lines[0];

            // Geriye kalan satırları filtreleyin, sadece 'movie' içerenleri alıyoruz
            var filteredMovies = lines.Where(line => line.Split('\t')[1] == "movie").ToList();

            // Yeni dosyaya başlığı ekleyin ve ardından filtrelenmiş satırları yazın
            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(header); // İlk satır başlık satırı
                foreach (var movie in filteredMovies)
                {
                    writer.WriteLine(movie);
                }
            }

            Console.WriteLine("Filtrelenmiş movie satırları başarıyla kaydedildi.");
        }
    }
}
