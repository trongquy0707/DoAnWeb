using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class User
    {
        public User()
        {
            GioHangs = new HashSet<GioHang>();
            VoucherChiTiets = new HashSet<VoucherChiTiet>();
        }

        public int IdUser { get; set; }
        public string? TenUser { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? MatKhau { get; set; }
        public int? TrangThai { get; set; }
        public int? IdChucVu { get; set; }

        public virtual ChucVu? IdChucVuNavigation { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
        public virtual ICollection<VoucherChiTiet> VoucherChiTiets { get; set; }
    }
}
