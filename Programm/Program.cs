using System;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        //// Dosya yolu ve dosya ismi
        //string tsvFilePath = @"C:\a\title.basics - Copy.tsv"; // Orijinal dosya yolu
        //string outputFilePath = @"C:\a\filtered_movies.tsv";  // Yeni dosya yolu

        //// Dosyayı satır satır okuyun
        //var lines = File.ReadAllLines(tsvFilePath);

        //// Başlık satırını (ilk satır) alın
        //var header = lines[0];

        //// Geriye kalan satırları filtreleyin, sadece 'movie' içerenleri alıyoruz
        //var filteredMovies = lines.Where(line => line.Split('\t')[1] == "movie").ToList();

        //// Yeni dosyaya başlığı ekleyin ve ardından filtrelenmiş satırları yazın
        //using (var writer = new StreamWriter(outputFilePath))
        //{
        //    writer.WriteLine(header); // İlk satır başlık satırı
        //    foreach (var movie in filteredMovies)
        //    {
        //        writer.WriteLine(movie);
        //    }
        //}

        //Console.WriteLine("Filtrelenmiş movie satırları başarıyla kaydedildi.");

        // Dosya yolu
        string filePath = @"C:\a\filtered_movies.tsv"; // Satır sayısını öğrenmek istediğiniz dosya yolu

        // Dosyayı okuyun ve satır sayısını hesaplayın
        var lines = File.ReadAllLines(filePath);

        // Satır sayısını bulun (başlık satırı dahil)
        int totalLines = lines.Length;

        // Başlık satırını çıkartmak isterseniz 1 çıkarın
        int dataLines = totalLines - 1; // Başlık satırı varsa onu çıkarıyoruz

        Console.WriteLine($"Toplam satır sayısı (başlık dahil): {totalLines}");
        Console.WriteLine($"Veri satırlarının sayısı (başlık hariç): {dataLines}");


    }
}
