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

    public virtual DbSet<AircraftSpezification> AircraftSpezifications { get; set; }

    public virtual DbSet<Compartment> Compartments { get; set; }

    public virtual DbSet<CrimeSyndicate> CrimeSyndicates { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<EnerySystem> EnerySystems { get; set; }

    public virtual DbSet<EnvironmentalSystem> EnvironmentalSystems { get; set; }

    public virtual DbSet<Machinery> Machineries { get; set; }

    public virtual DbSet<Mercenary> Mercenaries { get; set; }

    public virtual DbSet<MercenaryReputation> MercenaryReputations { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

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

            entity.HasOne(d => d.Spezification).WithMany(p => p.Aircraft)
                .HasForeignKey(d => d.SpezificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_AIRCRAFTS_AIRCRAFT_SPEZIFICATIONS1");
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

        modelBuilder.Entity<AircraftSpezification>(entity =>
        {
            entity.HasKey(e => e.SpezificationId).HasName("PRIMARY");

            entity
                .ToTable("AIRCRAFT_SPEZIFICATIONS")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.SpezificationCode, "SPEZIFICATION_CODE_UNIQUE").IsUnique();

            entity.Property(e => e.SpezificationId)
                .ValueGeneratedNever()
                .HasColumnName("SPEZIFICATION_ID");
            entity.Property(e => e.FuelTankCapacity).HasColumnName("FUEL_TANK_CAPACITY");
            entity.Property(e => e.MaxAltitude).HasColumnName("MAX_ALTITUDE");
            entity.Property(e => e.MaxSpeed).HasColumnName("MAX_SPEED");
            entity.Property(e => e.MinSpeed).HasColumnName("MIN_SPEED");
            entity.Property(e => e.SpezificationCode)
                .HasMaxLength(45)
                .HasColumnName("SPEZIFICATION_CODE");
            entity.Property(e => e.Structure).HasColumnName("STRUCTURE");
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

        modelBuilder.Entity<CrimeSyndicate>(entity =>
        {
            entity.HasKey(e => e.SyndicateId).HasName("PRIMARY");

            entity
                .ToTable("CRIME_SYNDICATES")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.SyndicateId).HasColumnName("SYNDICATE_ID");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<EnerySystem>(entity =>
        {
            entity.HasKey(e => e.MachineryId).HasName("PRIMARY");

            entity
                .ToTable("ENERY_SYSTEMS")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.MachineryId)
                .ValueGeneratedNever()
                .HasColumnName("MACHINERY_ID");

            entity.HasOne(d => d.Machinery).WithOne(p => p.EnerySystem)
                .HasForeignKey<EnerySystem>(d => d.MachineryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ENERY_SYSTEMS_MACHINERIES1");
        });

        modelBuilder.Entity<EnvironmentalSystem>(entity =>
        {
            entity.HasKey(e => e.MachineryId).HasName("PRIMARY");

            entity
                .ToTable("ENVIRONMENTAL_SYSTEMS")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.MachineryId)
                .ValueGeneratedNever()
                .HasColumnName("MACHINERY_ID");

            entity.HasOne(d => d.Machinery).WithOne(p => p.EnvironmentalSystem)
                .HasForeignKey<EnvironmentalSystem>(d => d.MachineryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ENVIRONMENTAL_SYSTEMS_MACHINERIES1");
        });

        modelBuilder.Entity<Machinery>(entity =>
        {
            entity.HasKey(e => e.MachineryId).HasName("PRIMARY");

            entity
                .ToTable("MACHINERIES")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Label, "LABEL_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CompartmentId, "fk_MACHINERIES_COMPARTMENTS1_idx");

            entity.Property(e => e.MachineryId).HasColumnName("MACHINERY_ID");
            entity.Property(e => e.CompartmentId).HasColumnName("COMPARTMENT_ID");
            entity.Property(e => e.Function)
                .HasColumnType("text")
                .HasColumnName("FUNCTION");
            entity.Property(e => e.Label)
                .HasMaxLength(45)
                .HasColumnName("LABEL");

            entity.HasOne(d => d.Compartment).WithMany(p => p.Machineries)
                .HasForeignKey(d => d.CompartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MACHINERIES_COMPARTMENTS1");
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

        modelBuilder.Entity<MercenaryReputation>(entity =>
        {
            entity.HasKey(e => new { e.SyndicateId, e.MercenaryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("MERCENARY_REPUTATIONS")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.SyndicateId, "fk_CRIME_SYNDICATES_has_MERCENARIES_CRIME_SYNDICATES_idx");

            entity.HasIndex(e => e.MercenaryId, "fk_CRIME_SYNDICATES_has_MERCENARIES_MERCENARIES1_idx");

            entity.Property(e => e.SyndicateId).HasColumnName("SYNDICATE_ID");
            entity.Property(e => e.MercenaryId).HasColumnName("MERCENARY_ID");
            entity.Property(e => e.ReputationChange)
                .HasMaxLength(45)
                .HasColumnName("REPUTATION_CHANGE");

            entity.HasOne(d => d.Mercenary).WithMany(p => p.MercenaryReputations)
                .HasForeignKey(d => d.MercenaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CRIME_SYNDICATES_has_MERCENARIES_MERCENARIES1");

            entity.HasOne(d => d.Syndicate).WithMany(p => p.MercenaryReputations)
                .HasForeignKey(d => d.SyndicateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CRIME_SYNDICATES_has_MERCENARIES_CRIME_SYNDICATES");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.MachineryId).HasName("PRIMARY");

            entity
                .ToTable("WEAPONS")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.MachineryId)
                .ValueGeneratedNever()
                .HasColumnName("MACHINERY_ID");

            entity.HasOne(d => d.Machinery).WithOne(p => p.Weapon)
                .HasForeignKey<Weapon>(d => d.MachineryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_WEAPONS_MACHINERIES1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
