using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class HoaDonChiTietViewModel
    {
        public int IdHoaDonChiTiet { get; set; }
        public int? idHoaDon { get; set; }
        public string? SanPhamChiTiet { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
    }
}
