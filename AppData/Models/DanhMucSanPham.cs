using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class DanhMucSanPham
    {
        public DanhMucSanPham()
        {
            SanPhamChiTiets = new HashSet<SanPhamChiTiet>();
        }

        public int IdDanhMucSanPham { get; set; }
        public string? TenDanhMuc { get; set; }

        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
