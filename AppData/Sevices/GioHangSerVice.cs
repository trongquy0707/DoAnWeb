using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class GioHangSerVice : iGioHangSerVice
    {
        CoolMate_1Context db;
        public GioHangSerVice()
        {
            db = new CoolMate_1Context();
        }
        public List<GioHang> DanhSachGioHang()
        {
            var data = db.GioHangs.ToList();
            return data;
        }

        public GioHang getbyidKhachHang(int id)
        {
            return DanhSachGioHang().FirstOrDefault(c => c.IdKhachHang == id);
        }
        public GioHang getbyid(int id)
        {
            return DanhSachGioHang().FirstOrDefault(c => c.IdGioHang == id);
        }

        public string ThemMoiGioHang(GioHang gioHang)
        {
            db.GioHangs.Add(gioHang);
            db.SaveChanges();
            return "Thêm thành công";
        }

       
      
     

        
    }
}
