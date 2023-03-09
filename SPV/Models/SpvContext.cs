using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SPV.Models;

public partial class SpvContext : DbContext
{
    public SpvContext()
    {
    }

    public SpvContext(DbContextOptions<SpvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alergen> Alergens { get; set; }

    public virtual DbSet<Hrana> Hranas { get; set; }

    public virtual DbSet<HranaVsebujeAlergen> HranaVsebujeAlergens { get; set; }

    public virtual DbSet<Restevracija> Restevracijas { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<TipHrane> TipHranes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=20.117.117.129;Database=spv;Uid=test;Pwd={5>Q]E=Ja(9Fd%)-;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alergen>(entity =>
        {
            entity.HasKey(e => e.IdAlergen).HasName("PRIMARY");

            entity.ToTable("alergen");

            entity.Property(e => e.IdAlergen).HasColumnName("idAlergen");
            entity.Property(e => e.Snov).HasMaxLength(100);
            entity.Property(e => e.StAlergena)
                .HasMaxLength(45)
                .HasColumnName("St_alergena");
        });

        modelBuilder.Entity<Hrana>(entity =>
        {
            entity.HasKey(e => e.IdHrane).HasName("PRIMARY");

            entity.ToTable("hrana");

            entity.HasIndex(e => e.FkRestevravije, "fk_Hrana_Restevracija1_idx");

            entity.HasIndex(e => e.FkTipHrane, "fk_Hrana_Tip_hrane1_idx");

            entity.Property(e => e.IdHrane).HasColumnName("Id_hrane");
            entity.Property(e => e.Cena).HasPrecision(10);
            entity.Property(e => e.FkRestevravije).HasColumnName("fk_restevravije");
            entity.Property(e => e.FkTipHrane).HasColumnName("fk_Tip_hrane");
            entity.Property(e => e.ImeHrane)
                .HasMaxLength(100)
                .HasColumnName("Ime_hrane");
            entity.Property(e => e.SlikaHrane)
                .HasMaxLength(500)
                .HasColumnName("Slika_hrane");

            entity.HasOne(d => d.FkRestevravijeNavigation).WithMany(p => p.Hranas)
                .HasForeignKey(d => d.FkRestevravije)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hrana_Restevracija1");

            entity.HasOne(d => d.FkTipHraneNavigation).WithMany(p => p.Hranas)
                .HasForeignKey(d => d.FkTipHrane)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hrana_Tip_hrane1");
        });

        modelBuilder.Entity<HranaVsebujeAlergen>(entity =>
        {
            entity.HasKey(e => e.IdHranaVsebujeAlergen).HasName("PRIMARY");

            entity.ToTable("hrana_vsebuje_alergen");

            entity.HasIndex(e => e.FkAlergen, "fk_Hrana_vsebuje_Alergen_Alergen1_idx");

            entity.HasIndex(e => e.FkHrane, "fk_Hrana_vsebuje_Alergen_Hrana1_idx");

            entity.Property(e => e.IdHranaVsebujeAlergen).HasColumnName("idHrana_vsebuje_Alergen");
            entity.Property(e => e.FkAlergen).HasColumnName("fk_Alergen");
            entity.Property(e => e.FkHrane).HasColumnName("fk_hrane");

            entity.HasOne(d => d.FkAlergenNavigation).WithMany(p => p.HranaVsebujeAlergens)
                .HasForeignKey(d => d.FkAlergen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hrana_vsebuje_Alergen_Alergen1");

            entity.HasOne(d => d.FkHraneNavigation).WithMany(p => p.HranaVsebujeAlergens)
                .HasForeignKey(d => d.FkHrane)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Hrana_vsebuje_Alergen_Hrana1");
        });

        modelBuilder.Entity<Restevracija>(entity =>
        {
            entity.HasKey(e => e.IdRestevravije).HasName("PRIMARY");

            entity.ToTable("restevracija");

            entity.Property(e => e.IdRestevravije).HasColumnName("id_restevravije");
            entity.Property(e => e.ImeRestevracije)
                .HasMaxLength(45)
                .HasColumnName("Ime_restevracije");
            entity.Property(e => e.OdprtoDo)
                .HasColumnType("time")
                .HasColumnName("Odprto_do");
            entity.Property(e => e.OdprtoOd)
                .HasColumnType("time")
                .HasColumnName("Odprto_od");
            entity.Property(e => e.XKordinata).HasColumnName("X_kordinata");
            entity.Property(e => e.YKordinata).HasColumnName("Y_kordinata");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.IdSession).HasName("PRIMARY");

            entity.ToTable("session");

            entity.HasIndex(e => e.FkUporabnika, "fk_Session_User1_idx");

            entity.Property(e => e.IdSession).HasColumnName("idSession");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.FkUporabnika).HasColumnName("fk_uporabnika");

            entity.HasOne(d => d.FkUporabnikaNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.FkUporabnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Session_User1");
        });

        modelBuilder.Entity<TipHrane>(entity =>
        {
            entity.HasKey(e => e.IdTipHrane).HasName("PRIMARY");

            entity.ToTable("tip_hrane");

            entity.Property(e => e.IdTipHrane).HasColumnName("id_Tip_hrane");
            entity.Property(e => e.ImeTipa)
                .HasMaxLength(70)
                .HasColumnName("Ime_tipa");
            entity.Property(e => e.SlikaTipa)
                .HasMaxLength(500)
                .HasColumnName("slika_tipa");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUporabnika).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.IdUporabnika).HasColumnName("Id_uporabnika");
            entity.Property(e => e.EmailUporabnika)
                .HasMaxLength(45)
                .HasColumnName("Email_uporabnika");
            entity.Property(e => e.ImeUporabnika)
                .HasMaxLength(45)
                .HasColumnName("Ime_uporabnika");
            entity.Property(e => e.NastanekUporabnika)
                .HasColumnType("datetime")
                .HasColumnName("Nastanek_uporabnika");
            entity.Property(e => e.PriimekUporabnika)
                .HasMaxLength(45)
                .HasColumnName("Priimek_uporabnika");
            entity.Property(e => e.SaltUporabnika)
                .HasMaxLength(45)
                .HasColumnName("Salt_uporabnika");
            entity.Property(e => e.UporabniskoGeslo)
                .HasMaxLength(45)
                .HasColumnName("Uporabnisko_geslo");
            entity.Property(e => e.UporabniskoIme)
                .HasMaxLength(45)
                .HasColumnName("Uporabnisko_ime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
