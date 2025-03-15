using ImdbRandomMovie.Entity;
using Microsoft.EntityFrameworkCore;

public class ImdbContext : DbContext
{
    public ImdbContext(DbContextOptions<ImdbContext> options)
        : base(options)
    {
    }

    // DbSet'ler ve tablo eşlemeleri
    public virtual DbSet<NameBasicsFiltered> NameBasicsFiltereds { get; set; }
    public virtual DbSet<TitleAkasFiltered> TitleAkasFiltereds { get; set; }
    public virtual DbSet<TitleBasicsFiltered> TitleBasicsFiltereds { get; set; }
    public virtual DbSet<TitleCrewFiltered> TitleCrewFiltereds { get; set; }
    public virtual DbSet<TitleRatingsFiltered> TitleRatingsFiltereds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Tablo isimlerini ve şemayı açıkça belirtiyoruz
        modelBuilder.Entity<NameBasicsFiltered>(entity =>
        {
            entity.ToTable("name.basics.filtered", "dbo");
            entity.HasKey(e => e.Nconst); // Primary key tanımı
        });

        modelBuilder.Entity<TitleAkasFiltered>(entity =>
        {
            entity.ToTable("title.akas.filtered", "dbo");
            entity.HasKey(e => new { e.Tconst, e.Ordering }); // Composite key
        });

        modelBuilder.Entity<TitleBasicsFiltered>(entity =>
        {
            entity.ToTable("title.basics.filtered", "dbo");
            entity.HasKey(e => e.Tconst);
        });

        modelBuilder.Entity<TitleCrewFiltered>(entity =>
        {
            entity.ToTable("title.crew.filtered", "dbo");
            entity.HasKey(e => e.Tconst);
        });

        modelBuilder.Entity<TitleRatingsFiltered>(entity =>
        {
            entity.ToTable("title.ratings.filtered", "dbo");
            entity.HasKey(e => e.Tconst);
        });

        // İlişkileri tanımlıyoruz (Örnek: TitleBasicsFiltered ↔ TitleCrewFiltered)
        modelBuilder.Entity<TitleBasicsFiltered>()
            .HasOne(b => b.TitleCrewFiltered)
            .WithOne(c => c.TconstNavigation)
            .HasForeignKey<TitleCrewFiltered>(c => c.Tconst);
    }
}