using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class WEB_TIENG_ANHContext : DbContext
    {
        public WEB_TIENG_ANHContext()
        {
        }

        public WEB_TIENG_ANHContext(DbContextOptions<WEB_TIENG_ANHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DmBaiHoc> DmBaiHoc { get; set; }
        public virtual DbSet<DmBaiTap> DmBaiTap { get; set; }
        public virtual DbSet<DmBaiTapCauHoi> DmBaiTapCauHoi { get; set; }
        public virtual DbSet<DmBaiTapDapAn> DmBaiTapDapAn { get; set; }
        public virtual DbSet<DmKhoaHoc> DmKhoaHoc { get; set; }
        public virtual DbSet<DmKyNang> DmKyNang { get; set; }
        public virtual DbSet<HtNguoiDung> HtNguoiDung { get; set; }
        public virtual DbSet<HtNguoiDungKhoaHoc> HtNguoiDungKhoaHoc { get; set; }
        public virtual DbSet<HtNhomQuyen> HtNhomQuyen { get; set; }
        public virtual DbSet<HtPhanMuc> HtPhanMuc { get; set; }
        public virtual DbSet<HtQuyen> HtQuyen { get; set; }
        public virtual DbSet<HtQuyenNhomQuyen> HtQuyenNhomQuyen { get; set; }
        public virtual DbSet<LoTrinhHoc> LoTrinhHoc { get; set; }
        public virtual DbSet<LoaiTinTuc> LoaiTinTuc { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TUCAL5PH;Database=WEB_TIENG_ANH;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DmBaiHoc>(entity =>
            {
                entity.ToTable("DM_BAI_HOC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.FileLink)
                    .HasColumnName("FILE_LINK")
                    .HasMaxLength(200);

                entity.Property(e => e.FilePath)
                    .HasColumnName("FILE_PATH")
                    .HasMaxLength(200);

                entity.Property(e => e.IdLoTrinhHoc)
                    .HasColumnName("ID_LO_TRINH_HOC")
                    .HasMaxLength(50);

                entity.Property(e => e.IdPhanMuc)
                    .HasColumnName("ID_PHAN_MUC")
                    .HasMaxLength(50);

                entity.Property(e => e.ImgLink)
                    .HasColumnName("IMG_LINK")
                    .HasMaxLength(200);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasColumnName("NOI_DUNG");

                entity.Property(e => e.TenBaiHoc)
                    .HasColumnName("TEN_BAI_HOC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DmBaiTap>(entity =>
            {
                entity.ToTable("DM_BAI_TAP");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.IdBaiHoc)
                    .HasColumnName("ID_BAI_HOC")
                    .HasMaxLength(50);

                entity.Property(e => e.IdPhanMuc)
                    .HasColumnName("ID_PHAN_MUC")
                    .HasMaxLength(50);

                entity.Property(e => e.TenBaiTap)
                    .HasColumnName("TEN_BAI_TAP")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdPhanMucNavigation)
                    .WithMany(p => p.DmBaiTap)
                    .HasForeignKey(d => d.IdPhanMuc)
                    .HasConstraintName("FK_DM_BAI_TAP_DM_BAI_HOC");
            });

            modelBuilder.Entity<DmBaiTapCauHoi>(entity =>
            {
                entity.ToTable("DM_BAI_TAP_CAU_HOI");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.IdBaiTap)
                    .HasColumnName("ID_BAI_TAP")
                    .HasMaxLength(50);

                entity.Property(e => e.NoiDung).HasColumnName("NOI_DUNG");

                entity.HasOne(d => d.IdBaiTapNavigation)
                    .WithMany(p => p.DmBaiTapCauHoi)
                    .HasForeignKey(d => d.IdBaiTap)
                    .HasConstraintName("FK_DM_BAI_TAP_CAU_HOI_DM_BAI_TAP");
            });

            modelBuilder.Entity<DmBaiTapDapAn>(entity =>
            {
                entity.ToTable("DM_BAI_TAP_DAP_AN");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.IdBaiTap)
                    .HasColumnName("ID_BAI_TAP")
                    .HasMaxLength(50);

                entity.Property(e => e.KetQua).HasColumnName("KET_QUA");

                entity.Property(e => e.NoiDung)
                    .HasColumnName("NOI_DUNG")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdBaiTapNavigation)
                    .WithMany(p => p.DmBaiTapDapAn)
                    .HasForeignKey(d => d.IdBaiTap)
                    .HasConstraintName("FK_DM_BAI_TAP_DAP_AN_DM_BAI_TAP");
            });

            modelBuilder.Entity<DmKhoaHoc>(entity =>
            {
                entity.ToTable("DM_KHOA_HOC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.Gia).HasColumnName("GIA");

                entity.Property(e => e.GiamGia).HasColumnName("GIAM_GIA");

                entity.Property(e => e.IdPhanMuc)
                    .HasColumnName("ID_PHAN_MUC")
                    .HasMaxLength(50);

                entity.Property(e => e.ImgLink)
                    .HasColumnName("IMG_LINK")
                    .HasMaxLength(50);

                entity.Property(e => e.MaQuyen)
                    .HasColumnName("MA_QUYEN")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(255);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasMaxLength(50);

                entity.Property(e => e.TenGiaoVien)
                    .HasColumnName("TEN_GIAO_VIEN")
                    .HasMaxLength(50);

                entity.Property(e => e.TenKhoaHoc)
                    .HasColumnName("TEN_KHOA_HOC")
                    .HasMaxLength(50);

                entity.Property(e => e.TinhTrang).HasColumnName("TINH_TRANG");
            });

            modelBuilder.Entity<DmKyNang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DM_KY_NANG");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.ImgLink)
                    .HasColumnName("IMG_LINK")
                    .HasMaxLength(255);

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(250);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoiDung)
                    .HasColumnName("NOI_DUNG")
                    .HasMaxLength(250);

                entity.Property(e => e.TenKyNang)
                    .HasColumnName("TEN_KY_NANG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HtNguoiDung>(entity =>
            {
                entity.ToTable("HT_NGUOI_DUNG");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.GioiTinh).HasColumnName("GIOI_TINH");

                entity.Property(e => e.HoVaTen)
                    .HasColumnName("HO_VA_TEN")
                    .HasMaxLength(250);

                entity.Property(e => e.IdNhomQuyen)
                    .HasColumnName("ID_NHOM_QUYEN")
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .HasColumnName("MAT_KHAU")
                    .HasMaxLength(50);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasMaxLength(50);

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("TEN_DANG_NHAP")
                    .HasMaxLength(50);

                entity.Property(e => e.TinhTrang).HasColumnName("TINH_TRANG");

                entity.HasOne(d => d.IdNhomQuyenNavigation)
                    .WithMany(p => p.HtNguoiDung)
                    .HasForeignKey(d => d.IdNhomQuyen)
                    .HasConstraintName("FK_HT_NGUOI_DUNG_HT_NHOM_QUYEN");
            });

            modelBuilder.Entity<HtNguoiDungKhoaHoc>(entity =>
            {
                entity.ToTable("HT_NGUOI_DUNG_KHOA_HOC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.IdKhoaHoc)
                    .HasColumnName("ID_KHOA_HOC")
                    .HasMaxLength(50);

                entity.Property(e => e.IdNguoiDung)
                    .HasColumnName("ID_NGUOI_DUNG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HtNhomQuyen>(entity =>
            {
                entity.ToTable("HT_NHOM_QUYEN");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(50);

                entity.Property(e => e.Ten)
                    .HasColumnName("TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HtPhanMuc>(entity =>
            {
                entity.ToTable("HT_PHAN_MUC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.LoaiPhanMuc).HasColumnName("LOAI_PHAN_MUC");

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(500);

                entity.Property(e => e.TenPhanMuc)
                    .HasColumnName("TEN_PHAN_MUC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HtQuyen>(entity =>
            {
                entity.ToTable("HT_QUYEN");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Ma)
                    .HasColumnName("MA")
                    .HasMaxLength(50);

                entity.Property(e => e.MaCha)
                    .HasColumnName("MA_CHA")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(50);

                entity.Property(e => e.TenQuyen)
                    .HasColumnName("TEN_QUYEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HtQuyenNhomQuyen>(entity =>
            {
                entity.ToTable("HT_QUYEN_NHOM_QUYEN");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.HtNhomQuyenId)
                    .HasColumnName("HT_NHOM_QUYEN_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.HtQuyenId)
                    .HasColumnName("HT_QUYEN_ID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LoTrinhHoc>(entity =>
            {
                entity.ToTable("LO_TRINH_HOC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.IdKhoaHoc)
                    .HasColumnName("ID_KHOA_HOC")
                    .HasMaxLength(50);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasMaxLength(50);

                entity.Property(e => e.NoiDung).HasColumnName("NOI_DUNG");

                entity.Property(e => e.TenLoTrinh)
                    .HasColumnName("TEN_LO_TRINH")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdKhoaHocNavigation)
                    .WithMany(p => p.LoTrinhHoc)
                    .HasForeignKey(d => d.IdKhoaHoc)
                    .HasConstraintName("FK_LO_TRINH_HOC_DM_KHOA_HOC");
            });

            modelBuilder.Entity<LoaiTinTuc>(entity =>
            {
                entity.ToTable("LOAI_TIN_TUC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(255);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasMaxLength(50);

                entity.Property(e => e.TieuDe)
                    .HasColumnName("TIEU_DE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.ToTable("TIN_TUC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.ImgLink)
                    .HasColumnName("IMG_LINK")
                    .HasMaxLength(200);

                entity.Property(e => e.LoaiTinTuc)
                    .HasColumnName("LOAI_TIN_TUC")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTa)
                    .HasColumnName("MO_TA")
                    .HasMaxLength(255);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("NGAY_CAP_NHAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("NGAY_TAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.NguoiCapNhat)
                    .HasColumnName("NGUOI_CAP_NHAT")
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiTao)
                    .HasColumnName("NGUOI_TAO")
                    .HasMaxLength(50);

                entity.Property(e => e.NoiDung)
                    .HasColumnName("NOI_DUNG")
                    .HasMaxLength(500);

                entity.Property(e => e.TieuDe)
                    .HasColumnName("TIEU_DE")
                    .HasMaxLength(50);

                entity.HasOne(d => d.LoaiTinTucNavigation)
                    .WithMany(p => p.TinTuc)
                    .HasForeignKey(d => d.LoaiTinTuc)
                    .HasConstraintName("FK_TIN_TUC_LOAI_TIN_TUC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
