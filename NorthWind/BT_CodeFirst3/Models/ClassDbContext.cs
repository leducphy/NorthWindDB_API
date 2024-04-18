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
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Khoa
        modelBuilder.Entity<Khoa>().HasData(
            new Khoa { MaKH = "HTTT", TenKH = "Hệ thống thông tin", SLSV = 0 },
            new Khoa { MaKH = "MANG", TenKH = "Mạng và truyền thông", SLSV = 0 },
            new Khoa { MaKH = "CNPM", TenKH = "Công nghệ phần mềm", SLSV = 0 },
            new Khoa { MaKH = "KTMT", TenKH = "Kỹ thuật máy tính", SLSV = 0 },
            new Khoa { MaKH = "KHMT", TenKH = "Khoa học máy tính", SLSV = 0 }
        );


        // Seed MonHoc
        modelBuilder.Entity<MonHoc>().HasData(
            new MonHoc { MaMH = "CSDL", TenMH = "Cơ sở dữ liệu", SoTiet = 45 },
            new MonHoc { MaMH = "TTNT", TenMH = "Trí tuệ nhân tạo", SoTiet = 45 },
            new MonHoc { MaMH = "MMT", TenMH = "Mạng máy tính", SoTiet = 45 },
            new MonHoc { MaMH = "DHMT", TenMH = "Đồ họa máy tính", SoTiet = 60 },
            new MonHoc { MaMH = "CTDL", TenMH = "Cấu trúc dữ liệu", SoTiet = 60 }
        );


        // Seed SinhVien
        modelBuilder.Entity<SinhVien>().HasData(
            new SinhVien
            {
                MaSV = "SV01", HoSV = "Lê Kim", TenSV = "Lan", Phai = "Nữ", NGSinh = new DateTime(1990, 2, 23),
                NoiSinh = "Hà Nội", MaKH = "HTTT", HocBong = 130000, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV02", HoSV = "Trần Minh", TenSV = "Chánh", Phai = "Nam", NGSinh = new DateTime(1992, 12, 24),
                NoiSinh = "Bình Định", MaKH = "MANG", HocBong = 150000, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV03", HoSV = "Lê An", TenSV = "Tuyết", Phai = "Nữ", NGSinh = new DateTime(1991, 2, 21),
                NoiSinh = "Hải Phòng", MaKH = "HTTT", HocBong = 170000, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV04", HoSV = "Trần Anh", TenSV = "Tuấn", Phai = "Nam", NGSinh = new DateTime(1993, 12, 20),
                NoiSinh = "TpHCM", MaKH = "MANG", HocBong = 80000, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV05", HoSV = "Trần Thị", TenSV = "Mai", Phai = "Nữ", NGSinh = new DateTime(1991, 8, 12),
                NoiSinh = "TpHCM", MaKH = "CNPM", HocBong = 0, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV06", HoSV = "Lê Thị Thu", TenSV = "Thủy", Phai = "Nữ", NGSinh = new DateTime(1991, 1, 2),
                NoiSinh = "An Giang", MaKH = "HTTT", HocBong = 0, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV07", HoSV = "Nguyễn Kim", TenSV = "Thư", Phai = "Nữ", NGSinh = new DateTime(1990, 2, 2),
                NoiSinh = "Hà Nội", MaKH = "CNPM", HocBong = 180000, DiemTB = 0
            },
            new SinhVien
            {
                MaSV = "SV08", HoSV = "Lê Văn", TenSV = "Long", Phai = "Nam", NGSinh = new DateTime(1992, 12, 8),
                NoiSinh = "TpHCM", MaKH = "HTTT", HocBong = 190000, DiemTB = 0
            }
        );


        // Seed KetQua
        modelBuilder.Entity<KetQua>().HasData(
            new KetQua { MaSV = "SV01", MaMH = "CSDL", LanThi = 1, Diem = 3, KQ = ""},
            new KetQua { MaSV = "SV01", MaMH = "CSDL", LanThi = 2, Diem = 6 , KQ = ""},
            new KetQua { MaSV = "SV01", MaMH = "TTNT", LanThi = 1, Diem = 5 , KQ = ""},
            new KetQua { MaSV = "SV01", MaMH = "TTNT", LanThi = 2, Diem = 6 , KQ = ""},
            new KetQua { MaSV = "SV01", MaMH = "MMT", LanThi = 1, Diem = 5 , KQ = ""},
            new KetQua { MaSV = "SV02", MaMH = "CSDL", LanThi = 1, Diem = 4 , KQ = ""},
            new KetQua { MaSV = "SV02", MaMH = "CSDL", LanThi = 2, Diem = 7 , KQ = ""},
            new KetQua { MaSV = "SV02", MaMH = "MMT", LanThi = 1, Diem = 10 , KQ = ""},
            new KetQua { MaSV = "SV02", MaMH = "CTDL", LanThi = 1, Diem = 9 , KQ = ""},
            new KetQua { MaSV = "SV03", MaMH = "CSDL", LanThi = 1, Diem = 2 , KQ = ""},
            new KetQua { MaSV = "SV03", MaMH = "CSDL", LanThi = 2, Diem = 5 , KQ = ""},
            new KetQua { MaSV = "SV03", MaMH = "MMT", LanThi = 1, Diem = 2 , KQ = ""},
            new KetQua { MaSV = "SV03", MaMH = "MMT", LanThi = 2, Diem = 4, KQ = "" },
            new KetQua { MaSV = "SV04", MaMH = "CSDL", LanThi = 1, Diem = 4 , KQ = ""},
            new KetQua { MaSV = "SV04", MaMH = "CTDL", LanThi = 1, Diem = 10, KQ = "" },
            new KetQua { MaSV = "SV05", MaMH = "CSDL", LanThi = 1, Diem = 7 , KQ = ""},
            new KetQua { MaSV = "SV05", MaMH = "MMT", LanThi = 1, Diem = 2 , KQ = ""},
            new KetQua { MaSV = "SV05", MaMH = "MMT", LanThi = 2, Diem = 5 , KQ = ""},
            new KetQua { MaSV = "SV06", MaMH = "TTNT", LanThi = 1, Diem = 6 , KQ = ""},
            new KetQua { MaSV = "SV06", MaMH = "DHMT", LanThi = 1, Diem = 10, KQ = "" }
        );
    }
}