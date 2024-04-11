namespace BT_CodeFirst3.Models;

using Microsoft.EntityFrameworkCore;

public class ClassDbContext : DbContext
{
    public ClassDbContext()
    {
    }

    public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
    {
    }

    public DbSet<Khoa> Khoas { get; set; }
    public DbSet<SinhVien> SinhViens { get; set; }
    public DbSet<MonHoc> MonHocs { get; set; }
    public DbSet<KetQua> KetQuas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKH);
            entity.Property(e => e.MaKH).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.TenKH).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.SLSV);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSV);
            entity.Property(e => e.MaSV).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.HoSV).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.TenSV).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.Phai).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.NGSinh).HasColumnType("datetime");
            entity.Property(e => e.NoiSinh).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.MaKH).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.HocBong).HasColumnType("money");
            entity.Property(e => e.DiemTB).HasColumnType("numeric(4,2)");
            entity.HasOne(d => d.Khoa)
                .WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaKH)
                .HasConstraintName("FK_SinhVien_Khoa");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMH);
            entity.Property(e => e.MaMH).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.TenMH).HasMaxLength(35).IsUnicode(false);
            entity.Property(e => e.SoTiet);
        });

        modelBuilder.Entity<KetQua>(entity =>
        {
            entity.HasKey(e => new { e.MaSV, e.MaMH, e.LanThi });
            entity.Property(e => e.MaSV).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.MaMH).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.LanThi);
            entity.Property(e => e.Diem).HasColumnType("numeric(4,2)");
            entity.Property(e => e.KQ).HasMaxLength(1).IsUnicode(false);
            entity.HasOne(d => d.SinhVien)
                .WithMany(p => p.KetQuas)
                .HasForeignKey(d => d.MaSV)
                .HasConstraintName("FK_KetQua_SinhVien");
            entity.HasOne(d => d.MonHoc)
                .WithMany(p => p.KetQuas)
                .HasForeignKey(d => d.MaMH)
                .HasConstraintName("FK_KetQua_MonHoc");
        });
    }
}