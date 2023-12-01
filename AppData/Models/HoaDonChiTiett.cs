using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class HoaDonChiTiett
    {
        public int IdHoaDonChiTiet { get; set; }
        public int? IdHoaDon { get; set; }
        public int? IdSanPhamChiTiet { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }

        public virtual HoaaDon? IdHoaDonNavigation { get; set; }
        public virtual SanPhamChiTiet? IdSanPhamChiTietNavigation { get; set; }
    }
}
