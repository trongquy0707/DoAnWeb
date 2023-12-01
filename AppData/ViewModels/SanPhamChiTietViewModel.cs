using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class SanPhamChiTietViewModel
    {
        public int IdSanPhamChiTiet { get; set; }
        public string? DanhMucSanPham { get; set; }
        public string? Mau { get; set; }
        public string? Size { get; set; }
        public int? SoLuong { get; set; }
        public string? Anh { get; set; }
        public int? GiaSp { get; set; }
        public int? TrangThai { get; set; }
        public string? TenSanPham { get; set; }
    }
}
