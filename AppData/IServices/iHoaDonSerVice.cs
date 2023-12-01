using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface iHoaDonSerVice
    {
        public List<HoaaDon> DanhSachHoaDon();
        public List<HoaaDon> DanhSachHoaDon(int idKhach);
        public string taohoadon( HoaaDon hoaaDon);
        public string updateHoaDon(int id , HoaaDon hoaaDon);
    }
}
