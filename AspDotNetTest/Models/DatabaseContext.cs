using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetTest.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoUuTien> DoUuTiens { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<YeuCau> YeuCaus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=DB_AspNetTest_Company;user id=sa;password=1234567;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoUuTien>(entity =>
        {
            entity.HasKey(e => e.Madouutien).HasName("PK__DoUuTien__F830DB5934E135E7");

            entity.ToTable("DoUuTien");

            entity.Property(e => e.Madouutien)
                .ValueGeneratedNever()
                .HasColumnName("madouutien");
            entity.Property(e => e.Tendouutien)
                .HasMaxLength(255)
                .HasColumnName("tendouutien");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__NhanVien__F3DBC5739F1DDBA7");

            entity.ToTable("NhanVien");

            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(255)
                .HasColumnName("hinhanh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(255)
                .HasColumnName("hoten");
            entity.Property(e => e.Kichhoat).HasColumnName("kichhoat");
            entity.Property(e => e.Ngaysinh).HasColumnName("ngaysinh");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Quyen).HasColumnName("quyen");
        });

        modelBuilder.Entity<YeuCau>(entity =>
        {
            entity.HasKey(e => e.Mayeucau).HasName("PK__YeuCau__F3815ED3C265B53C");

            entity.ToTable("YeuCau");

            entity.Property(e => e.Mayeucau).HasColumnName("mayeucau");
            entity.Property(e => e.Madouutien).HasColumnName("madouutien");
            entity.Property(e => e.ManvGui)
                .HasMaxLength(255)
                .HasColumnName("manv_gui");
            entity.Property(e => e.ManvXuly)
                .HasMaxLength(255)
                .HasColumnName("manv_xuly");
            entity.Property(e => e.Ngaygui).HasColumnName("ngaygui");
            entity.Property(e => e.Noidung)
                .HasMaxLength(255)
                .HasColumnName("noidung");
            entity.Property(e => e.Tieude)
                .HasMaxLength(255)
                .HasColumnName("tieude");

            entity.HasOne(d => d.MadouutienNavigation).WithMany(p => p.YeuCaus)
                .HasForeignKey(d => d.Madouutien)
                .HasConstraintName("FK__YeuCau__madouuti__5441852A");

            entity.HasOne(d => d.ManvGuiNavigation).WithMany(p => p.YeuCauManvGuiNavigations)
                .HasForeignKey(d => d.ManvGui)
                .HasConstraintName("FK__YeuCau__manv_gui__5535A963");

            entity.HasOne(d => d.ManvXulyNavigation).WithMany(p => p.YeuCauManvXulyNavigations)
                .HasForeignKey(d => d.ManvXuly)
                .HasConstraintName("FK__YeuCau__manv_xul__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
