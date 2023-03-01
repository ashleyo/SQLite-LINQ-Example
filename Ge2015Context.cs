using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tuesday;

public partial class Ge2015Context : DbContext
{
    public Ge2015Context()
    {
    }

    public Ge2015Context(DbContextOptions<Ge2015Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Constituency> Constituencies { get; set; }

    public virtual DbSet<County> Counties { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=ge2015.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => new { e.OnsId, e.Firstname, e.Surname });

            entity.ToTable("candidate");

            entity.Property(e => e.OnsId)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("ons_id");
            entity.Property(e => e.Firstname)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("firstname");
            entity.Property(e => e.Surname)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("surname");
            entity.Property(e => e.Change)
                .HasColumnType("FLOAT")
                .HasColumnName("change");
            entity.Property(e => e.FormerMp)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("former_mp");
            entity.Property(e => e.Gender)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("gender");
            entity.Property(e => e.PartyId)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("party_id");
            entity.Property(e => e.Share)
                .HasColumnType("FLOAT")
                .HasColumnName("share");
            entity.Property(e => e.SittingMp)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("sitting_mp");
            entity.Property(e => e.Votes)
                .HasColumnType("INT")
                .HasColumnName("votes");

            entity.HasOne(d => d.Ons).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.OnsId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Party).WithMany(p => p.Candidates).HasForeignKey(d => d.PartyId);
        });

        modelBuilder.Entity<Constituency>(entity =>
        {
            entity.HasKey(e => e.OnsId);

            entity.ToTable("constituency");

            entity.HasIndex(e => e.Name, "IX_constituency_constituency").IsUnique();

            entity.Property(e => e.OnsId)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("ons_id");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("constituency");
            entity.Property(e => e.ConstituencyType)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("constituency_type");
            entity.Property(e => e.CountyName)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("county_name");

            entity.HasOne(d => d.CountyNameNavigation).WithMany(p => p.Constituencies)
                .HasForeignKey(d => d.CountyName)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<County>(entity =>
        {
            entity.HasKey(e => e.CountyName);

            entity.ToTable("county");

            entity.Property(e => e.CountyName)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("county_name");
            entity.Property(e => e.OnsRegionId)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("ons_region_id");

            entity.HasOne(d => d.OnsRegion).WithMany(p => p.Counties)
                .HasForeignKey(d => d.OnsRegionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.ToTable("party");

            entity.Property(e => e.PartyId)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("party_id");
            entity.Property(e => e.PartyName)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("party_name");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.OnsRegionId);

            entity.ToTable("region");

            entity.Property(e => e.OnsRegionId)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("ons_region_id");
            entity.Property(e => e.CountryName)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("country_name");
            entity.Property(e => e.RegionName)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("region_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
