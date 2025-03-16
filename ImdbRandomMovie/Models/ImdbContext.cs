using ImdbRandomMovie.Entity;
using Microsoft.EntityFrameworkCore;

public class ImdbContext : DbContext
{
    public ImdbContext(DbContextOptions<ImdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NameBasicsFiltered> NameBasicsFiltereds { get; set; }
    public virtual DbSet<TitleAkasFiltered> TitleAkasFiltereds { get; set; }
    public virtual DbSet<TitleBasicsFiltered> TitleBasicsFiltereds { get; set; }
    public virtual DbSet<TitleCrewFiltered> TitleCrewFiltereds { get; set; }
    public virtual DbSet<TitleRatingsFiltered> TitleRatingsFiltereds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Tablo isimlerini açıkça belirtiyoruz
        modelBuilder.Entity<NameBasicsFiltered>().ToTable("name.basics.filtered", "dbo");
        modelBuilder.Entity<TitleAkasFiltered>().ToTable("title.akas.filtered", "dbo");
        modelBuilder.Entity<TitleBasicsFiltered>().ToTable("title.basics.filtered", "dbo");
        modelBuilder.Entity<TitleCrewFiltered>().ToTable("title.crew.filtered", "dbo");
        modelBuilder.Entity<TitleRatingsFiltered>().ToTable("title.ratings.filtered", "dbo");

        // Primary key tanımlamaları
        modelBuilder.Entity<NameBasicsFiltered>().HasKey(e => e.Nconst);
        modelBuilder.Entity<TitleAkasFiltered>().HasKey(e => new { e.Tconst, e.Ordering });
        modelBuilder.Entity<TitleBasicsFiltered>().HasKey(e => e.Tconst);
        modelBuilder.Entity<TitleCrewFiltered>().HasKey(e => e.Tconst);
        modelBuilder.Entity<TitleRatingsFiltered>().HasKey(e => e.Tconst);
    }
}
