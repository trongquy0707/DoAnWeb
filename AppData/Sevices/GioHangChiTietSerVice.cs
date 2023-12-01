using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class GioHangChiTietSerVice : iGioHangChiTietSerVice
    {
        CoolMate_1Context db;
        private iGioHangSerVice iGioHangSerVice;
        public GioHangChiTietSerVice()
        {
            db = new CoolMate_1Context();
            iGioHangSerVice = new GioHangSerVice();
        }
        public List<GioHangChiTiet> DanhSachGioHangCT()
        {
            var data = db.GioHangChiTiets.ToList();
            return data;
        }
        
        public GioHangChiTiet getbyid(int id)
        {
            return DanhSachGioHangCT().FirstOrDefault( c => c.IdGioHangChiTiet == id);
        }

        public List<GioHangChiTiet> getbyidGioHang(int id)
        {
           
            var GioHang = iGioHangSerVice.DanhSachGioHang().FirstOrDefault(c => c.IdKhachHang == id);
            return DanhSachGioHangCT().Where(c => c.IdGioHang == GioHang.IdGioHang).ToList();
        }

        public string SuaGioHangCT(int idGioHangCT, GioHangChiTiet gioHangCT)
        {
            var timkiem = db.GioHangChiTiets.FirstOrDefault(c => c.IdGioHangChiTiet == idGioHangCT);
            if (timkiem == null)
            {
                return "Không tìm thấy Voucher!!";
            }
            else
            {
                timkiem.IdSanPhamChiTiet = gioHangCT.IdSanPhamChiTiet;
                timkiem.SoLuong = gioHangCT.SoLuong;
               timkiem.GiaSp = gioHangCT.GiaSp;
                db.GioHangChiTiets.Update(timkiem);
                db.SaveChanges();
                return "Sửa thành công !!";
            }
        }

        public string ThemMoiGioHangCT(GioHangChiTiet gioHangChiTiet)
        {

               db.GioHangChiTiets.Add(gioHangChiTiet);
                db.SaveChanges ();
                return "Thêm thành công"; 
        }

        public string XoaGioHangCT(int idGioHangCT)
        {
            var timkiem = DanhSachGioHangCT().FirstOrDefault(c => c.IdGioHangChiTiet == idGioHangCT);
            if (timkiem == null)
            {
                return "Không tìm thấy Voucher";
            }
            else
            {
                db.GioHangChiTiets.Remove(timkiem);
                db.SaveChanges();
                return "Đã xóa size";
            }
        }

    
    }
}
