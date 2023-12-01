using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface iGioHangSerVice
    {
        public List<GioHang> DanhSachGioHang();
        public string ThemMoiGioHang(GioHang gioHang);
        public GioHang getbyidKhachHang(int id);
        public GioHang getbyid(int id);
    }
}
