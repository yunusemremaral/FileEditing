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

        FilterMovies();    // 1. Adım: Filmleri filtrele
        CountMovies();     // 2. Adım: Filmleri say
        FilterRatings();    // 3. Adım: Rating'leri filtrele
        FilterCrew();      // 4. Adım: Crew verisini filtrele
        FilterNames();     // 5. Adım: İsim verisini filtrele
        FilterAkas();      // 6. Adım: AKAS verisini filtrele

    }

    static void FilterMovies()
    {
        string inputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";

        try
        {
            var lines = File.ReadAllLines(inputFilePath);
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var line in lines)
                {
                    var columns = line.Split('\t');
                    if (columns[1] == "movie")
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Film filtreleme tamamlandı: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata (Film Filtreleme): " + ex.Message);
        }
    }

    static void CountMovies()
    {
        string filePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";

        try
        {
            var lines = File.ReadAllLines(filePath);
            int movieCount = 0;

            foreach (var line in lines)
            {
                var columns = line.Split('\t');
                if (columns[1] == "movie") movieCount++;
            }

            Console.WriteLine("Toplam film sayısı: " + movieCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata (Sayım): " + ex.Message);
        }
    }

    static void FilterRatings()
    {
        string basicsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";

        try
        {
            var movieIds = new HashSet<string>();
            foreach (var line in File.ReadAllLines(basicsFilePath))
            {
                var columns = line.Split('\t');
                if (columns[1] == "movie") movieIds.Add(columns[0]);
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var line in File.ReadAllLines(ratingsFilePath))
                {
                    var columns = line.Split('\t');
                    if (movieIds.Contains(columns[0])) writer.WriteLine(line);
                }
            }
            Console.WriteLine("Rating filtreleme tamamlandı: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata (Rating Filtreleme): " + ex.Message);
        }
    }

    static void FilterCrew()
    {
        string crewFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.crew.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.crew.filtered.txt";

        try
        {
            var validIds = new HashSet<string>();
            using (var sr = new StreamReader(ratingsFilePath))
            {
                sr.ReadLine(); // Header'ı atla
                while (!sr.EndOfStream) validIds.Add(sr.ReadLine().Split('\t')[0]);
            }

            using (var sr = new StreamReader(crewFilePath))
            using (var sw = new StreamWriter(outputFilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (validIds.Contains(line.Split('\t')[0])) sw.WriteLine(line);
                }
            }
            Console.WriteLine("Crew filtreleme tamamlandı: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata (Crew Filtreleme): " + ex.Message);
        }
    }

    static void FilterNames()
    {
        string nameFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\name.basics.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";
        string basicsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.basics.filtered.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\name.basics.filtered.txt";

        try
        {
            var validMovieIds = new HashSet<string>();
            using (var sr = new StreamReader(ratingsFilePath))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) validMovieIds.Add(sr.ReadLine().Split('\t')[0]);
            }

            var validMovieTypes = new HashSet<string>();
            using (var sr = new StreamReader(basicsFilePath))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var parts = sr.ReadLine().Split('\t');
                    if (parts[1] == "movie") validMovieTypes.Add(parts[0]);
                }
            }

            using (var sr = new StreamReader(nameFilePath))
            using (var sw = new StreamWriter(outputFilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var parts = line.Split('\t');
                    foreach (var title in parts[5].Split(','))
                    {
                        if (validMovieIds.Contains(title) && validMovieTypes.Contains(title))
                        {
                            sw.WriteLine(line);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("İsim filtreleme tamamlandı: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata (İsim Filtreleme): " + ex.Message);
        }
    }

    static void FilterAkas()
    {
        string akasFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.akas.txt";
        string ratingsFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.ratings.filtered.txt";
        string outputFilePath = @"C:\Users\imgoz\Desktop\IMDB DATABASE\title.akas.filtered.txt";

        try
        {
            var validMovieIds = new HashSet<string>();
            using (var sr = new StreamReader(ratingsFilePath))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) validMovieIds.Add(sr.ReadLine().Split('\t')[0]);
            }

            using (var sr = new StreamReader(akasFilePath))
            using (var sw = new StreamWriter(outputFilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (validMovieIds.Contains(line.Split('\t')[0])) sw.WriteLine(line);
                }
            }
            Console.WriteLine("AKAS filtreleme tamamlandı: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata (AKAS Filtreleme): " + ex.Message);
        }
    }
}
