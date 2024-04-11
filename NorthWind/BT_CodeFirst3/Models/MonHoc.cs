namespace BT_CodeFirst3.Models;

public class MonHoc
{
    public string MaMH { get; set; }
    public string TenMH { get; set; }
    public byte SoTiet { get; set; }
    public ICollection<KetQua> KetQuas { get; set; }
}