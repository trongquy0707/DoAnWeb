using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class BangMauSerVice : IBangMausServices
    {
        CoolMate_1Context db = new CoolMate_1Context();
        public List<Mau> DanhSachbangMau()
        {
            var data = db.Maus.ToList();
            return data;
        }

        public string SuaBangMau(int idMau, Mau mau)
        {
            var danhmuc = DanhSachbangMau().FirstOrDefault(c => c.IdMau == idMau);
            if (danhmuc == null)
            {
                return "Không tìm thấy danh mục!!";
            }
            else
            {
                danhmuc.TenMau = mau.TenMau;
                db.Maus.Update(danhmuc);
                db.SaveChanges();
                return "Sửa thành công!!";
            }
        }

        public string ThemMoiBangMau(Mau mau)
        {

            if (DanhSachbangMau().Any(c => c.TenMau == mau.TenMau))
            {
                return "san Pham da ton tai";
            }
            else if (mau.TenMau == null)
            {
                return "ban chua nhap san pham";
            }
            else
            {
                db.Maus.Add(mau);
                db.SaveChanges();
                return "Them Thanh Cong";
            }
        }

        public string XoaBangMau(int idMau)
        {
            var timxoa = DanhSachbangMau().FirstOrDefault(c => c.IdMau == idMau);
            if (timxoa == null)
            {
                return " khong ton tai ";
            }
            else
            {
                db.Remove(timxoa);
                db.SaveChanges();
                return "Xoa thanh cong";
            }
        }
        public Mau getbyid(int id)
        {
            return DanhSachbangMau().FirstOrDefault(c => c.IdMau == id);
        }
    }
}
