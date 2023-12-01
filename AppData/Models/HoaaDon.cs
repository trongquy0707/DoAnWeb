using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class HoaaDon
    {
        public HoaaDon()
        {
            HoaDonChiTietts = new HashSet<HoaDonChiTiett>();
        }

        public int IdHoaDon { get; set; }
        public int? IdUser { get; set; }
        public int? IdVoucherChiTiet { get; set; }
        public string? MaHoaDon { get; set; }
        public string? TenUser { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public int? SoLuong { get; set; }
        public int? TongTien { get; set; }
        public int? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual VoucherChiTiet? IdVoucherChiTietNavigation { get; set; }
        public virtual User? idUsertNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiett> HoaDonChiTietts { get; set; }
       
    }
}
