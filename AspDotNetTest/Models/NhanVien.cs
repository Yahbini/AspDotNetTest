namespace AspDotNetTest.Models;

public partial class NhanVien
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Hoten { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public bool? Kichhoat { get; set; }

    public string? Hinhanh { get; set; }

    public int? Quyen { get; set; }

    public virtual ICollection<YeuCau> YeuCauManvGuiNavigations { get; set; } = new List<YeuCau>();

    public virtual ICollection<YeuCau> YeuCauManvXulyNavigations { get; set; } = new List<YeuCau>();
}
