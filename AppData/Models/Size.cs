using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Size
    {
        public Size()
        {
            SanPhamChiTiets = new HashSet<SanPhamChiTiet>();
        }

        public int IdSize { get; set; }
        public string? TenSize { get; set; }

        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
