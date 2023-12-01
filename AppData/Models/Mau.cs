using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Mau
    {
        public Mau()
        {
            SanPhamChiTiets = new HashSet<SanPhamChiTiet>();
        }

        public int IdMau { get; set; }
        public string? TenMau { get; set; }

        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
