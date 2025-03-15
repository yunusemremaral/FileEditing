using ImdbRandomMovie.Entity;
using Microsoft.EntityFrameworkCore;

public class ImdbContext : DbContext
{
    public ImdbContext(DbContextOptions<ImdbContext> options)
        : base(options)
    {
    }

    // Diğer DbSet'ler burada
    public virtual DbSet<NameBasicsFiltered> NameBasicsFiltereds { get; set; }
    public virtual DbSet<TitleAkasFiltered> TitleAkasFiltereds { get; set; }
    public virtual DbSet<TitleBasicsFiltered> TitleBasicsFiltereds { get; set; }
    public virtual DbSet<TitleCrewFiltered> TitleCrewFiltereds { get; set; }
    public virtual DbSet<TitleRatingsFiltered> TitleRatingsFiltereds { get; set; }

    // OnConfiguring metodunu güncelleyin
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-M61UIT9;Database=ImdbDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

    // OnModelCreating metodunda modellerin yapılandırılmaya devam edeceği şekilde bırakılabilir
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // İlgili model yapılandırmaları
        base.OnModelCreating(modelBuilder);
    }
}
