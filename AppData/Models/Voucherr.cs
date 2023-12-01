using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Voucherr
    {
        public Voucherr()
        {
            VoucherChiTiets = new HashSet<VoucherChiTiet>();
        }

        public int IdVoucher { get; set; }
        public string? TenVoucher { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public int TrangThai {  get; set; }

        public virtual ICollection<VoucherChiTiet> VoucherChiTiets { get; set; }
    }
}
