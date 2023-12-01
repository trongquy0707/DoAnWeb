using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class HoaDonSerVice : iHoaDonSerVice
    {
        CoolMate_1Context db;
        private INguoiDungServiec nguoiDungServiec;
        public HoaDonSerVice()
        {
            db = new CoolMate_1Context();
            nguoiDungServiec = new NguoiDungServiec();
        }

        public List<HoaaDon> DanhSachHoaDon()
        {
            var data = db.HoaaDons.ToList();
            return data;
        }

        public List<HoaaDon> DanhSachHoaDon(int idKhach)
        {
            var data = db.HoaaDons.Where(c => c.IdUser == idKhach).ToList();
            return data;
        }

        public string taohoadon(HoaaDon hoaaDon)
        {
            var idUser = nguoiDungServiec.ListUser().FirstOrDefault(c => c.IdUser == hoaaDon.IdUser);
            HoaaDon hoadon = new HoaaDon();
            hoadon.IdUser = db.Users.FirstOrDefault(c => c.IdUser == hoaaDon.IdUser).IdUser;
            hoadon.TenUser = db.Users.FirstOrDefault(c => c.TenUser == hoaaDon.TenUser).TenUser;
            hoadon.SoDienThoai = db.Users.FirstOrDefault(c => c.SoDienThoai == hoaaDon.SoDienThoai).SoDienThoai;
            hoadon.DiaChi = db.Users.FirstOrDefault(c => c.DiaChi == hoaaDon.DiaChi).DiaChi;
            hoaaDon.SoLuong = 0;
            hoaaDon.TongTien = 0;
            hoaaDon.TrangThai = 1;
            hoaaDon.NgayTao = DateTime.Now;
            db.SaveChanges();
            return "them thanh cong";
        }

        public string updateHoaDon(int id, HoaaDon hoaaDon)
        {
            var idHoadon  = DanhSachHoaDon().FirstOrDefault(c => c.IdHoaDon == hoaaDon.IdHoaDon);

            idHoadon.IdUser = db.Users.FirstOrDefault(c => c.IdUser == hoaaDon.IdUser).IdUser;
            idHoadon.TenUser = db.Users.FirstOrDefault(c => c.TenUser == hoaaDon.TenUser).TenUser;
            idHoadon.SoDienThoai = db.Users.FirstOrDefault(c => c.SoDienThoai == hoaaDon.SoDienThoai).SoDienThoai;
            idHoadon.DiaChi = db.Users.FirstOrDefault(c => c.DiaChi == hoaaDon.DiaChi).DiaChi;
            idHoadon.SoLuong = hoaaDon.SoLuong;
            idHoadon.TongTien = hoaaDon.TongTien;
            idHoadon.TrangThai = 1;
            hoaaDon.NgayTao = DateTime.Now;
            db.HoaaDons.Update(idHoadon);
            return "Sua thanh cong";
        }
    }
}
