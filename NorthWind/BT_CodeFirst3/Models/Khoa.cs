namespace BT_CodeFirst3.Models;

public class Khoa
{
    public string MaKH { get; set; }
    public string TenKH { get; set; }
    public int SLSV { get; set; }
    public ICollection<SinhVien> SinhViens { get; set; }
}