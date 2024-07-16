using System;
using System.Collections.Generic;

namespace AspDotNetTest.Models;

public partial class DoUuTien
{
    public int Madouutien { get; set; }

    public string? Tendouutien { get; set; }

    public virtual ICollection<YeuCau> YeuCaus { get; set; } = new List<YeuCau>();
}
