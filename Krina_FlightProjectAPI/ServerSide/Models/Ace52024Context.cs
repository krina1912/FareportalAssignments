using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServerSide.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<KrinaAdmin> KrinaAdmins { get; set; }

    public virtual DbSet<KrinaAirport> KrinaAirports { get; set; }

    public virtual DbSet<KrinaBooking> KrinaBookings { get; set; }

    public virtual DbSet<KrinaCustomer> KrinaCustomers { get; set; }

    public virtual DbSet<KrinaFlight> KrinaFlights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KrinaAdmin>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__KrinaAdm__C6970A10E3149B6A");

            entity.ToTable("KrinaAdmin");

            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Pwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pwd");
        });

        modelBuilder.Entity<KrinaAirport>(entity =>
        {
            entity.HasKey(e => e.Airportcode).HasName("PK__KrinaAir__B0AB7A358CBC3D5E");

            entity.ToTable("KrinaAirport");

            entity.Property(e => e.Airportcode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Airportname)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("country");
        });

        modelBuilder.Entity<KrinaBooking>(entity =>
        {
            entity.HasKey(e => e.Bid).HasName("PK__KrinaBoo__C6D111C94ADF137C");

            entity.ToTable("KrinaBooking");

            entity.Property(e => e.Bookdate)
                .HasColumnType("datetime")
                .HasColumnName("bookdate");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Flightid).HasColumnName("flightid");
            entity.Property(e => e.NofPasseng).HasColumnName("nofPasseng");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.KrinaBookings)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__KrinaBookin__cid__369C13AA");

            entity.HasOne(d => d.Flight).WithMany(p => p.KrinaBookings)
                .HasForeignKey(d => d.Flightid)
                .HasConstraintName("FK__KrinaBook__fligh__379037E3");
        });

        modelBuilder.Entity<KrinaCustomer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__KrinaCus__C1FFD8618E9D4BA4");

            entity.ToTable("KrinaCustomer");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Pwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pwd");
        });

        modelBuilder.Entity<KrinaFlight>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PK__KrinaFli__C1D1314A7B747AD4");

            entity.ToTable("KrinaFlight");

            entity.Property(e => e.ArrivalId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DepartTime).HasColumnType("datetime");
            entity.Property(e => e.Flightname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flightname");

            entity.HasOne(d => d.Arrival).WithMany(p => p.KrinaFlightArrivals)
                .HasForeignKey(d => d.ArrivalId)
                .HasConstraintName("FK__KrinaFlig__Arriv__33BFA6FF");

            entity.HasOne(d => d.Depart).WithMany(p => p.KrinaFlightDeparts)
                .HasForeignKey(d => d.DepartId)
                .HasConstraintName("FK__KrinaFlig__Depar__32CB82C6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
