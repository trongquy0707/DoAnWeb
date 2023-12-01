using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class GiohangChiTietViewModel
    {
        public int IdGioHangChiTiet { get; set; }
        
        public string? SanPhamChiTiet { get; set; }
        public string? Anh { get; set; }
        public int? SoLuong { get; set; }
        public int? GiaSp { get; set; }
    }
}
