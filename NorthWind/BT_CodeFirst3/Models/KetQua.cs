namespace BT_CodeFirst3.Models;

public class KetQua
{
    public string MaSV { get; set; }
    public string MaMH { get; set; }
    public byte LanThi { get; set; }
    public decimal Diem { get; set; }
    public string KQ { get; set; }
    public SinhVien SinhVien { get; set; }
    public MonHoc MonHoc { get; set; }
}