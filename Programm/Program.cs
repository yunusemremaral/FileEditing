using System;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        #region Title.basics.tsv dosyasından 'movie' içeren satırları filtreleme
        /*
        // Dosya yolu ve dosya ismi
        string tsvFilePath = @"C:\a\title.basics.tsv"; // Orijinal dosya yolu
        string outputFilePath = @"C:\a\title.basics_movies.tsv";  // Yeni dosya yolu

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
        */
        #endregion

        #region Dosyadaki satır sayısını öğrenme
        /*
        // Dosya yolu
        string filePath = @"C:\a\filtered_names.tsv"; // Satır sayısını öğrenmek istediğiniz dosya yolu

        // Dosyayı okuyun ve satır sayısını hesaplayın
        var lines = File.ReadAllLines(filePath);

        // Satır sayısını bulun (başlık satırı dahil)
        int totalLines = lines.Length;

        // Başlık satırını çıkartmak isterseniz 1 çıkarın
        int dataLines = totalLines - 1; // Başlık satırı varsa onu çıkarıyoruz

        Console.WriteLine($"Toplam satır sayısı (başlık dahil): {totalLines}");
        Console.WriteLine($"Veri satırlarının sayısı (başlık hariç): {dataLines}");
        */
        #endregion

        #region Aynı tconst değerine sahip satırları filtreleme ve yeni dosyaya yazma
        /*
        // Dosya yolları
        string tsvFilePath = @"C:\a\title.basics_movies.tsv"; // Orijinal dosya yolu
        string outputFilePath = @"C:\a\title.basics_movies_unique.tsv";  // Yeni dosya yolu

        // Dosyayı satır satır okuyun
        var lines = File.ReadAllLines(tsvFilePath).ToList();

        // Başlık satırını alın
        var header = lines[0];
        lines.RemoveAt(0);

        // Benzersiz tconst değerlerini tutmak için bir HashSet kullanın
        HashSet<string> uniqueTconsts = new HashSet<string>();
        List<string> uniqueLines = new List<string> { header }; // Başlık satırını ekleyin

        // Satırları dolaşarak benzersiz tconst değerlerini bulun
        foreach (var line in lines)
        {
            var columns = line.Split('\t');
            var tconst = columns[0];

            // Benzersiz tconst ise satırı ekleyin
            if (uniqueTconsts.Add(tconst))
            {
                uniqueLines.Add(line);
            }
        }

        // Yeni dosyaya benzersiz satırları yazın
        File.WriteAllLines(outputFilePath, uniqueLines);

        Console.WriteLine("Aynı tconst değerine sahip satırlar başarıyla silindi ve yeni dosyaya kaydedildi.");
        */
        #endregion

        #region 2 Dosyayı Kullanarak Eşleşen Satırları 3. Dosyaya Yazdırma
        /*
        string moviesFilePath = @"C:\a\title.basics_movies.tsv";
        string ratingsFilePath = @"C:\a\title.ratings.tsv";
        string outputFilePath = @"C:\a\filtered_movies_with_ratings.tsv";

        // Dosyaları okuyun
        var moviesLines = File.ReadAllLines(moviesFilePath);
        var ratingsLines = File.ReadAllLines(ratingsFilePath);

        // Başlık satırlarını alın
        var moviesHeader = moviesLines[0];
        var ratingsHeader = ratingsLines[0];

        // Başlık satırları dahil yeni başlık oluşturun
        string newHeader = moviesHeader + "\taverageRating\tnumVotes";

        // Movies dosyasındaki tüm tconst değerlerini alın (ilk satır başlık olduğu için atlanır)
        var movieIds = moviesLines.Skip(1).Select(line => line.Split('\t')[0]).ToHashSet();

        // Eşleşen satırları filtreleyin
        var filteredLines = ratingsLines
            .Skip(1)
            .Where(line => movieIds.Contains(line.Split('\t')[0]))
            .Select(line => {
                var ratingData = line.Split('\t');
                var movieData = moviesLines.First(m => m.StartsWith(ratingData[0]));
                return movieData + "\t" + ratingData[1] + "\t" + ratingData[2];
            })
            .ToList();

        // Yeni dosyaya başlığı ve filtrelenmiş verileri yazın
        using (var writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine(newHeader);
            foreach (var line in filteredLines)
            {
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Eşleşen satırlar başarıyla kaydedildi.");
        */
        #endregion

        #region Title.basics_movies.tsv Dosyasındaki titleId Değerlerine Göre Title.akas.tsv Filtreleme
        // Step 1: Load titleId values from title.basics_movies.tsv
        //var titleBasicsFilePath = @"C:\a\title.basics_movies.tsv";
        //var titleIds = new HashSet<string>();

        //using (var reader = new StreamReader(titleBasicsFilePath))
        //{
        //    // Skip header row
        //    reader.ReadLine();

        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(line))
        //        {
        //            var fields = line.Split('\t');
        //            var titleId = fields[0];
        //            titleIds.Add(titleId);
        //        }
        //    }
        //}

        // Step 2: Filter title.akas.tsv by titleIds from title.basics_movies.tsv
        //var titleAkasFilePath = @"C:\a\title.akas.tsv";
        //var outputFilePath = @"C:\a\filtered_title.akas.tsv";

        //using (var reader = new StreamReader(titleAkasFilePath))
        //using (var writer = new StreamWriter(outputFilePath))
        //{
        //    // Write header to output file
        //    var header = reader.ReadLine();
        //    writer.WriteLine(header);

        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(line))
        //        {
        //            var fields = line.Split('\t');
        //            var titleId = fields[0];

        //            // Write line to output file if titleId is in titleIds set
        //            if (titleIds.Contains(titleId))
        //            {
        //                writer.WriteLine(line);
        //            }
        //        }
        //    }
        //}

        //Console.WriteLine("Filtering completed. Output saved to: " + outputFilePath);
        #endregion

        #region  title.basics_movies.tsv Dosyasındaki titleId Değerlerine Göre title.principals.tsv Filtreleme
        //// Adım 1: title.basics_movies.tsv dosyasındaki titleId değerlerini yükleyin
        //var titleBasicsFilePath = @"C:\a\title.basics_movies.tsv";
        //var titleIds = new HashSet<string>();

        //using (var reader = new StreamReader(titleBasicsFilePath))
        //{
        //    // İlk satır başlık satırı olduğu için atlıyoruz
        //    reader.ReadLine();

        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(line))
        //        {
        //            var fields = line.Split('\t');
        //            var titleId = fields[0];
        //            titleIds.Add(titleId);
        //        }
        //    }
        //}

        //// Adım 2: title.principals.tsv dosyasını titleId değerlerine göre filtreleyin
        //var titlePrincipalsFilePath = @"C:\a\title.principals.tsv";
        //var outputFilePath = @"C:\a\filtered_title.principals.tsv";

        //using (var reader = new StreamReader(titlePrincipalsFilePath))
        //using (var writer = new StreamWriter(outputFilePath))
        //{
        //    // Başlık satırını okuma ve yeni dosyaya yazma
        //    var header = reader.ReadLine();
        //    writer.WriteLine(header);

        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(line))
        //        {
        //            var fields = line.Split('\t');
        //            var titleId = fields[0];

        //            // Eğer titleId, title.basics_movies.tsv dosyasındaki titleIds setinde varsa satırı yeni dosyaya yaz
        //            if (titleIds.Contains(titleId))
        //            {
        //                writer.WriteLine(line);
        //            }
        //        }
        //    }
        //}

        //Console.WriteLine("Filtreleme işlemi tamamlandı. Çıktı dosyası: " + outputFilePath);
        #endregion


        using System;
        using System.IO;

class Program
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.txt";
            string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";

            try
            {
                Input dosyasını oku
               var lines = File.ReadAllLines(inputFilePath);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var line in lines)
                    {
                        Satırı virgülle ayıralım
                       var columns = line.Split('\t');

                        Eğer titleType 'movie' ise, bu satırı yaz
                        if (columns[1] == "movie")
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                Console.WriteLine("Filtreleme işlemi tamamlandı. Sonuçlar: " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }
    }

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";

        try
        {
            Dosyadaki tüm satırları oku
            var lines = File.ReadAllLines(filePath);

            'movie' olan satırları say
            int movieCount = 0;

            foreach (var line in lines)
            {
                var columns = line.Split('\t');

                Eğer titleType 'movie' ise, sayacı artır
                if (columns[1] == "movie")
                {
                    movieCount++;
                }
            }

            Console.WriteLine("Toplam film sayısı: " + movieCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string basicsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";

        try
        {
            title.basics.filtered.txt dosyasındaki movie ID'lerini oku
            var movieIds = new HashSet<string>();
            var basicsLines = File.ReadAllLines(basicsFilePath);

            foreach (var line in basicsLines)
            {
                var columns = line.Split('\t');
                Eğer titleType movie ise, ID'yi listeye ekle
                if (columns[1] == "movie")
                {
                    movieIds.Add(columns[0]);
                }
            }

            title.ratings.txt dosyasını oku ve sadece filtrelenmiş movie ID'leri ile eşleşenleri al
            var ratingsLines = File.ReadAllLines(ratingsFilePath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var line in ratingsLines)
                {
                    var columns = line.Split('\t');
                    string tconst = columns[0];

                    Eğer tconst, title.basics.filtered.txt'ye ait movie ID'lerinden birine eşitse, yazdır
                    if (movieIds.Contains(tconst))
                    {
                        writer.WriteLine(line);  // Eşleşen satırı çıktı dosyasına yaz
                    }
                }
            }

            Console.WriteLine("Filtreleme tamamlandı. Sonuç: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string crewFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.crew.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.crew.filtered.txt";

        title.ratings.filtered.txt dosyasındaki movie id'lerini oku
        HashSet<string> validIds = new HashSet<string>();
        using (StreamReader sr = new StreamReader(ratingsFilePath))
        {
            sr.ReadLine(); // İlk satırı atla (başlık satırı)
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0)
                {
                    validIds.Add(parts[0]); // tconst (movie ID)
                }
            }
        }

        title.crew.txt dosyasını filtrele
        using (StreamReader sr = new StreamReader(crewFilePath))
        using (StreamWriter sw = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0 && validIds.Contains(parts[0])) // tconst değeri geçerliyse
                {
                    sw.WriteLine(line); // Geçerli satırı yaz
                }
            }
        }

        Console.WriteLine("Filtreleme işlemi tamamlandı.");
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string nameFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\name.basics.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";
        string basicsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\name.basics.filtered.txt";

        title.ratings.filtered.txt dosyasındaki movie id'lerini oku
        HashSet<string> validMovieIds = new HashSet<string>();
        using (StreamReader sr = new StreamReader(ratingsFilePath))
        {
            sr.ReadLine(); // Başlık satırını atla
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0)
                {
                    validMovieIds.Add(parts[0]); // tconst (movie ID)
                }
            }
        }

        title.basics.filtered.txt dosyasındaki movie ID'lerini oku
        HashSet<string> validMovieTypes = new HashSet<string>();
        using (StreamReader sr = new StreamReader(basicsFilePath))
        {
            sr.ReadLine(); // Başlık satırını atla
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0 && parts[1] == "movie") // sadece movie türündeki filmleri al
                {
                    validMovieTypes.Add(parts[0]); // tconst (movie ID)
                }
            }
        }

        name.basics.tsv dosyasını filtrele
        using (StreamReader sr = new StreamReader(nameFilePath))
        using (StreamWriter sw = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0)
                {
                    string[] knownForTitles = parts[5].Split(',');
                    bool isValid = false;

                    Kişinin oynadığı veya yer aldığı film ID'leri ile validMovieIds karşılaştır
                    foreach (var title in knownForTitles)
                    {
                        if (validMovieIds.Contains(title) && validMovieTypes.Contains(title))
                        {
                            isValid = true;
                            break;
                        }
                    }

                    Eğer kişi geçerli bir filmde oynadıysa, satırı kaydet
                    if (isValid)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }

        Console.WriteLine("Filtreleme işlemi tamamlandı.");
    }
}
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Dosya yolları
        string akasFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.akas.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.akas.filtered.txt";

        title.ratings.filtered.txt dosyasındaki movie id'lerini oku
        HashSet<string> validMovieIds = new HashSet<string>();
        using (StreamReader sr = new StreamReader(ratingsFilePath))
        {
            sr.ReadLine(); // Başlık satırını atla
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0)
                {
                    validMovieIds.Add(parts[0]); // tconst (movie ID)
                }
            }
        }

        title.akas.txt dosyasındaki fazlalıkları azalt
        using (StreamReader sr = new StreamReader(akasFilePath))
        using (StreamWriter sw = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('\t');
                if (parts.Length > 0)
                {
                    string movieId = parts[0]; // tconst (movie ID)

                    Sadece validMovieIds içindeki ID'leri al
                    if (validMovieIds.Contains(movieId))
                    {
                        sw.WriteLine(line); // Geçerli film bilgilerini yaz
                    }
                }
            }
        }

        Console.WriteLine("Filtreleme işlemi tamamlandı.");
    }
}



    }
}
