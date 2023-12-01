using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppData.Models
{
    public partial class CoolMate_1Context : DbContext
    {
        public CoolMate_1Context()
        {
        }

        public CoolMate_1Context(DbContextOptions<CoolMate_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<GioHangChiTiet> GioHangChiTiets { get; set; } = null!;
        public virtual DbSet<HoaDonChiTiett> HoaDonChiTietts { get; set; } = null!;
        public virtual DbSet<HoaaDon> HoaaDons { get; set; } = null!;
        public virtual DbSet<Mau> Maus { get; set; } = null!;
        public virtual DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; } = null!;
        public virtual DbSet<SanPhamm> SanPhamms { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VoucherChiTiet> VoucherChiTiets { get; set; } = null!;
        public virtual DbSet<Voucherr> Voucherrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2V1G2GQ\\SQLEXPRESS;Database=CoolMate_1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.IdChucVu);

                entity.ToTable("ChucVu");

                entity.Property(e => e.IdChucVu).HasColumnName("idChucVu");

                entity.Property(e => e.TenChucVu).HasMaxLength(50);
            });

            modelBuilder.Entity<DanhMucSanPham>(entity =>
            {
                entity.HasKey(e => e.IdDanhMucSanPham);

                entity.ToTable("DanhMucSanPham");

                entity.Property(e => e.IdDanhMucSanPham).HasColumnName("idDanhMucSanPham");

                entity.Property(e => e.TenDanhMuc).HasMaxLength(50);
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.IdGioHang);

                entity.ToTable("GioHang");

                entity.Property(e => e.IdGioHang).HasColumnName("idGioHang");

                entity.Property(e => e.IdKhachHang).HasColumnName("idKhachHang");

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.IdKhachHang)
                    .HasConstraintName("FK_GioHang_User");
            });

            modelBuilder.Entity<GioHangChiTiet>(entity =>
            {
                entity.HasKey(e => e.IdGioHangChiTiet);

                entity.ToTable("GioHangChiTiet");

                entity.Property(e => e.IdGioHangChiTiet).HasColumnName("idGioHangChiTiet");

                entity.Property(e => e.GiaSp).HasColumnName("GiaSP");

                entity.Property(e => e.IdGioHang).HasColumnName("idGioHang");

                entity.Property(e => e.IdSanPhamChiTiet).HasColumnName("idSanPhamChiTiet");

                entity.HasOne(d => d.IdGioHangNavigation)
                    .WithMany(p => p.GioHangChiTiets)
                    .HasForeignKey(d => d.IdGioHang)
                    .HasConstraintName("FK_GioHangChiTiet_GioHang");

                entity.HasOne(d => d.IdSanPhamChiTietNavigation)
                    .WithMany(p => p.GioHangChiTiets)
                    .HasForeignKey(d => d.IdSanPhamChiTiet)
                    .HasConstraintName("FK_GioHangChiTiet_SanPhamChiTiet");
            });

            modelBuilder.Entity<HoaDonChiTiett>(entity =>
            {
                entity.HasKey(e => e.IdHoaDonChiTiet);

                entity.ToTable("HoaDonChiTiett");

                entity.Property(e => e.IdHoaDonChiTiet).HasColumnName("idHoaDonChiTiet");

                entity.Property(e => e.IdHoaDon).HasColumnName("idHoaDon");

                entity.Property(e => e.IdSanPhamChiTiet).HasColumnName("idSanPhamChiTiet");

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.HoaDonChiTietts)
                    .HasForeignKey(d => d.IdHoaDon)
                    .HasConstraintName("FK_HoaDonChiTiett_HoaaDon");

                entity.HasOne(d => d.IdSanPhamChiTietNavigation)
                    .WithMany(p => p.HoaDonChiTietts)
                    .HasForeignKey(d => d.IdSanPhamChiTiet)
                    .HasConstraintName("FK_HoaDonChiTiett_SanPhamChiTiet");
            });

            modelBuilder.Entity<HoaaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoaDon);

                entity.ToTable("HoaaDon");

                entity.Property(e => e.IdHoaDon).HasColumnName("idHoaDon");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdVoucherChiTiet).HasColumnName("idVoucherChiTiet");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenUser).HasMaxLength(50);

                entity.HasOne(d => d.IdVoucherChiTietNavigation)
                    .WithMany(p => p.HoaaDons)
                    .HasForeignKey(d => d.IdVoucherChiTiet)
                    .HasConstraintName("FK_HoaaDon_VoucherChiTiet");
            });

            modelBuilder.Entity<Mau>(entity =>
            {
                entity.HasKey(e => e.IdMau);

                entity.ToTable("Mau");

                entity.Property(e => e.IdMau).HasColumnName("idMau");

                entity.Property(e => e.TenMau).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPhamChiTiet>(entity =>
            {
                entity.HasKey(e => e.IdSanPhamChiTiet);

                entity.ToTable("SanPhamChiTiet");

                entity.Property(e => e.IdSanPhamChiTiet).HasColumnName("idSanPhamChiTiet");

                entity.Property(e => e.Anh).HasMaxLength(50);

                entity.Property(e => e.GiaSp).HasColumnName("GiaSP");

                entity.Property(e => e.IdDanhMucSanPham).HasColumnName("idDanhMucSanPham");

                entity.Property(e => e.IdMau).HasColumnName("idMau");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.HasOne(d => d.IdDanhMucSanPhamNavigation)
                    .WithMany(p => p.SanPhamChiTiets)
                    .HasForeignKey(d => d.IdDanhMucSanPham)
                    .HasConstraintName("FK_SanPhamChiTiet_DanhMucSanPham");

                entity.HasOne(d => d.IdMauNavigation)
                    .WithMany(p => p.SanPhamChiTiets)
                    .HasForeignKey(d => d.IdMau)
                    .HasConstraintName("FK_SanPhamChiTiet_Mau");

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.SanPhamChiTiets)
                    .HasForeignKey(d => d.IdSize)
                    .HasConstraintName("FK_SanPhamChiTiet_Size");
            });

            modelBuilder.Entity<SanPhamm>(entity =>
            {
                entity.HasKey(e => e.IdSanPham);

                entity.ToTable("SanPhamm");

                entity.Property(e => e.IdSanPham).HasColumnName("idSanPham");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.IdSize);

                entity.ToTable("Size");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.Property(e => e.TenSize).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.IdChucVu).HasColumnName("idChucVu");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenUser).HasMaxLength(50);

                entity.HasOne(d => d.IdChucVuNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdChucVu)
                    .HasConstraintName("FK_User_ChucVu");
            });

            modelBuilder.Entity<VoucherChiTiet>(entity =>
            {
                entity.HasKey(e => e.IdVoucherChiTiet);

                entity.ToTable("VoucherChiTiet");

                entity.Property(e => e.IdVoucherChiTiet).HasColumnName("idVoucherChiTiet");

                entity.Property(e => e.IdNguoiDung).HasColumnName("idNguoiDung");

                entity.Property(e => e.IdVoucher).HasColumnName("idVoucher");

                entity.HasOne(d => d.IdNguoiDungNavigation)
                    .WithMany(p => p.VoucherChiTiets)
                    .HasForeignKey(d => d.IdNguoiDung)
                    .HasConstraintName("FK_VoucherChiTiet_User");

                entity.HasOne(d => d.IdVoucherNavigation)
                    .WithMany(p => p.VoucherChiTiets)
                    .HasForeignKey(d => d.IdVoucher)
                    .HasConstraintName("FK_VoucherChiTiet_Voucherr");
            });

            modelBuilder.Entity<Voucherr>(entity =>
            {
                entity.HasKey(e => e.IdVoucher);

                entity.ToTable("Voucherr");

                entity.Property(e => e.IdVoucher).HasColumnName("idVoucher");

                entity.Property(e => e.Max).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Min).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TenVoucher).HasMaxLength(50);

                entity.Property(e => e.ThoiGianBatDau).HasColumnType("date");

                entity.Property(e => e.ThoiGianKetThuc).HasColumnType("date");

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
