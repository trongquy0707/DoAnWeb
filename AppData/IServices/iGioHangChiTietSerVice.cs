using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface iGioHangChiTietSerVice
    {
        public List<GioHangChiTiet> DanhSachGioHangCT();
        public string ThemMoiGioHangCT(GioHangChiTiet gioHangChiTiet);
        public string SuaGioHangCT(int idGioHangCT, GioHangChiTiet gioHangCT);
        public List<GioHangChiTiet> getbyidGioHang(int id);
        public string XoaGioHangCT(int idGioHangCT);
        public GioHangChiTiet getbyid(int id);

    }
}
