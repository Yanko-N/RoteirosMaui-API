using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoteirosApi.Models;

public partial class RoteirosMauiDbContext : DbContext
{
    public RoteirosMauiDbContext()
    {
    }

    public RoteirosMauiDbContext(DbContextOptions<RoteirosMauiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Spot> Spots { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Utilizador> Utilizadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FVV4E02\\SQLEXPRESS;Database=RoteirosMauiDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Spot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spot__3214EC074014F4C8");

            entity.ToTable("Spot");

            entity.Property(e => e.Adress).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Trip).WithMany(p => p.Spots)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__Spot__TripId__4F7CD00D");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trip__3214EC070CD78D28");

            entity.ToTable("Trip");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Trips)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Trip__UserId__4CA06362");
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Utilizad__3214EC079802EC02");

            entity.ToTable("Utilizador");

            entity.HasIndex(e => e.Email, "UQ__Utilizad__A9D105345C2A1FBE").IsUnique();

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
