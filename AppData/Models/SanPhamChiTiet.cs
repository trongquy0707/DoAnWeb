using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class SanPhamChiTiet
    {
        public SanPhamChiTiet()
        {
            GioHangChiTiets = new HashSet<GioHangChiTiet>();
            HoaDonChiTietts = new HashSet<HoaDonChiTiett>();
        }

        public int IdSanPhamChiTiet { get; set; }
        public int? IdDanhMucSanPham { get; set; }
        public int? IdMau { get; set; }
        public int? IdSize { get; set; }
        public int? SoLuong { get; set; }
        public string? Anh { get; set; }
        public int? GiaSp { get; set; }
        public int? TrangThai { get; set; }
        public string? TenSanPham { get; set; }

        public virtual DanhMucSanPham? IdDanhMucSanPhamNavigation { get; set; }
        public virtual Mau? IdMauNavigation { get; set; }
        public virtual Size? IdSizeNavigation { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
        public virtual ICollection<HoaDonChiTiett> HoaDonChiTietts { get; set; }
    }
}
