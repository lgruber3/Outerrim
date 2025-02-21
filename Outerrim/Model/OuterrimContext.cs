using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Model.Model;

public partial class OuterrimContext : DbContext
{
    public OuterrimContext()
    {
    }

    public OuterrimContext(DbContextOptions<OuterrimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aircraft> Aircrafts { get; set; }

    public virtual DbSet<AircraftCrewJt> AircraftCrewJts { get; set; }

    public virtual DbSet<Compartment> Compartments { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Mercenary> Mercenaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=9906;database=outerrim;user=root;password=htlkrems", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.AircraftId).HasName("PRIMARY");

            entity.ToTable("AIRCRAFTS");

            entity.HasIndex(e => e.SpezificationId, "fk_AIRCRAFTS_AIRCRAFT_SPEZIFICATIONS1_idx");

            entity.Property(e => e.AircraftId).HasColumnName("AIRCRAFT_ID");
            entity.Property(e => e.Altitude).HasColumnName("ALTITUDE");
            entity.Property(e => e.Fuel).HasColumnName("FUEL");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("NAME");
            entity.Property(e => e.Speed).HasColumnName("SPEED");
            entity.Property(e => e.SpezificationId).HasColumnName("SPEZIFICATION_ID");
        });

        modelBuilder.Entity<AircraftCrewJt>(entity =>
        {
            entity.HasKey(e => new { e.AircraftId, e.MercenaryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("AIRCRAFT_CREW_JT");

            entity.HasIndex(e => e.MercenaryId, "IX_AIRCRAFT_CREW_JT_MERCENARY_ID");

            entity.Property(e => e.AircraftId).HasColumnName("AIRCRAFT_ID");
            entity.Property(e => e.MercenaryId).HasColumnName("MERCENARY_ID");
            entity.Property(e => e.JoinedAt).HasColumnName("JOINED_AT");

            entity.HasOne(d => d.Aircraft).WithMany(p => p.AircraftCrewJts).HasForeignKey(d => d.AircraftId);

            entity.HasOne(d => d.Mercenary).WithMany(p => p.AircraftCrewJts).HasForeignKey(d => d.MercenaryId);
        });

        modelBuilder.Entity<Compartment>(entity =>
        {
            entity.HasKey(e => e.CompartmentId).HasName("PRIMARY");

            entity.ToTable("COMPARTMENTS");

            entity.HasIndex(e => e.AircraftId, "IX_COMPARTMENTS_AIRCRAFT_ID");

            entity.Property(e => e.CompartmentId).HasColumnName("COMPARTMENT_ID");
            entity.Property(e => e.AircraftId).HasColumnName("AIRCRAFT_ID");

            entity.HasOne(d => d.Aircraft).WithMany(p => p.Compartments).HasForeignKey(d => d.AircraftId);
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Mercenary>(entity =>
        {
            entity.HasKey(e => e.MercenaryId).HasName("PRIMARY");

            entity.ToTable("MERCENARIES");

            entity.Property(e => e.MercenaryId).HasColumnName("MERCENARY_ID");
            entity.Property(e => e.BodySkills).HasColumnName("BODY_SKILLS");
            entity.Property(e => e.CombatSkill).HasColumnName("COMBAT_SKILL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("LAST_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
