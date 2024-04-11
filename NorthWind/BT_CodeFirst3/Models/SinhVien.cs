namespace BT_CodeFirst3.Models;

public class SinhVien
{
    public string MaSV { get; set; }
    public string HoSV { get; set; }
    public string TenSV { get; set; }
    public string Phai { get; set; }
    public DateTime NGSinh { get; set; }
    public string NoiSinh { get; set; }
    public string MaKH { get; set; }
    public decimal HocBong { get; set; }
    public decimal DiemTB { get; set; }
    public Khoa Khoa { get; set; }
    public ICollection<KetQua> KetQuas { get; set; }
}