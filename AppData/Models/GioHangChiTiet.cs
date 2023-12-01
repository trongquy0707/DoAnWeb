using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class GioHangChiTiet
    {
        public int IdGioHangChiTiet { get; set; }
        public int? IdGioHang { get; set; }
        public int? IdSanPhamChiTiet { get; set; }
        public int? SoLuong { get; set; }
        public int? GiaSp { get; set; }
        public virtual GioHang? IdGioHangNavigation { get; set; }
        public virtual SanPhamChiTiet? IdSanPhamChiTietNavigation { get; set; }
    }
}
