
using Microsoft.EntityFrameworkCore;
using QLSV.Models;

namespace QLSV.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Khoa> Khoas { get; set; }

        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<DangKyMonHoc> DangKyMonHocs { get; set; }
        public DbSet<HocKy> HocKys { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=.\SQLEXPRESS;Database=QLSV;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Khoa>()
                .ToTable("Khoa")
                .HasKey(k => k.MaKhoa);

            modelBuilder.Entity<SinhVien>()
                .ToTable("SinhVien")
                .HasKey(sv => sv.MSSV);

            modelBuilder.Entity<MonHoc>()
                .ToTable("MonHoc")
                .HasKey(mh => mh.MaMonHoc);

            modelBuilder.Entity<DangKyMonHoc>()
                .ToTable("DangKyMonHoc")
                .HasKey(dk => new { dk.MSSV, dk.MaMonHoc });
            modelBuilder.Entity<HocKy>()
    .ToTable("HocKy")
    .HasKey(hk => hk.MaHocKy);
        }
    }
}
