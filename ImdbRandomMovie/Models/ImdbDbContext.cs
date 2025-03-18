using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ImdbRandomMovie;

public partial class ImdbDbContext : DbContext
{
    public ImdbDbContext()
    {
    }

    public ImdbDbContext(DbContextOptions<ImdbDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NameBasicsFiltered> NameBasicsFiltereds { get; set; }

    public virtual DbSet<TitleBasicsFiltered> TitleBasicsFiltereds { get; set; }

    public virtual DbSet<TitleCrewFiltered> TitleCrewFiltereds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M61UIT9;Database=ImdbDb; Trusted_Connection= true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NameBasicsFiltered>(entity =>
        {
            entity.HasKey(e => e.Nconst);

            entity.ToTable("name.basics.filtered");

            entity.Property(e => e.Nconst)
                .HasMaxLength(20)
                .HasColumnName("nconst");
            entity.Property(e => e.BirthYear)
                .HasMaxLength(20)
                .HasColumnName("birthYear");
            entity.Property(e => e.DeathYear)
                .HasMaxLength(20)
                .HasColumnName("deathYear");
            entity.Property(e => e.KnownForTitles)
                .HasMaxLength(150)
                .HasColumnName("knownForTitles");
            entity.Property(e => e.PrimaryName)
                .HasMaxLength(100)
                .HasColumnName("primaryName");
            entity.Property(e => e.PrimaryProfession)
                .HasMaxLength(150)
                .HasColumnName("primaryProfession");
        });

        modelBuilder.Entity<TitleBasicsFiltered>(entity =>
        {
            entity.HasKey(e => e.Tconst);

            entity.ToTable("title.basics.filtered");

            entity.HasIndex(e => e.Tconst, "IX_TitleBasics_Tconst");

            entity.Property(e => e.Tconst)
                .HasMaxLength(20)
                .HasColumnName("tconst");
            entity.Property(e => e.AverageRating).HasColumnName("averageRating");
            entity.Property(e => e.Genres)
                .HasMaxLength(50)
                .HasColumnName("genres");
            entity.Property(e => e.IsAdult).HasColumnName("isAdult");
            entity.Property(e => e.NumVotes).HasColumnName("numVotes");
            entity.Property(e => e.OriginalTitle)
                .HasMaxLength(250)
                .HasColumnName("originalTitle");
            entity.Property(e => e.PrimaryTitle)
                .HasMaxLength(250)
                .HasColumnName("primaryTitle");
            entity.Property(e => e.RuntimeMinutes)
                .HasMaxLength(50)
                .HasColumnName("runtimeMinutes");
            entity.Property(e => e.StartYear).HasColumnName("startYear");
        });

        modelBuilder.Entity<TitleCrewFiltered>(entity =>
        {
            entity.HasKey(e => e.Tconst);

            entity.ToTable("title.crew.filtered");

            entity.Property(e => e.Tconst)
                .HasMaxLength(20)
                .HasColumnName("tconst");
            entity.Property(e => e.Directors).HasColumnName("directors");
            entity.Property(e => e.Writers).HasColumnName("writers");

            entity.HasOne(d => d.TconstNavigation).WithOne(p => p.TitleCrewFiltered)
                .HasForeignKey<TitleCrewFiltered>(d => d.Tconst)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_title_crew_title_basics");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
