using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class VoucherChiTiet
    {
        public VoucherChiTiet()
        {
            HoaaDons = new HashSet<HoaaDon>();
        }

        public int IdVoucherChiTiet { get; set; }
        public int? IdVoucher { get; set; }
        public int? IdNguoiDung { get; set; }

        public virtual User? IdNguoiDungNavigation { get; set; }
        public virtual Voucherr? IdVoucherNavigation { get; set; }
        public virtual ICollection<HoaaDon> HoaaDons { get; set; }
    }
}
