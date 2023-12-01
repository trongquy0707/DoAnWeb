using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class GioHang
    {
        public GioHang()
        {
            GioHangChiTiets = new HashSet<GioHangChiTiet>();
        }

        public int IdGioHang { get; set; }
        public int? IdKhachHang { get; set; }

        public virtual User? IdKhachHangNavigation { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
