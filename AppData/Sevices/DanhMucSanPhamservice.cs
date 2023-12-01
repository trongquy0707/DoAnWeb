using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class DanhMucSanPhamservice : IDanhMucSanPhamservice
    {
        CoolMate_1Context db = new CoolMate_1Context();
        public List<DanhMucSanPham> DanhSachDanhMucSP()
        {
            var data = db.DanhMucSanPhams.ToList();
            return data;
        }

        public string SuaDanhMuc(int idDanhMucSP, DanhMucSanPham danhMucSanPham)
        {
            var danhmuc = DanhSachDanhMucSP().FirstOrDefault(c => c.IdDanhMucSanPham == danhMucSanPham.IdDanhMucSanPham);
            if (danhmuc == null)
            {
                return "Không tìm thấy danh mục!!";
            }
            else
            {
                danhmuc.TenDanhMuc = danhMucSanPham.TenDanhMuc;
                db.Update(danhmuc);
                db.SaveChanges();
                return "Sửa thành công!!";
            }
        }

        public string ThemMoiDanhMuc(DanhMucSanPham danhMucSanPham)
        {
            if(DanhSachDanhMucSP().Any(c => c.TenDanhMuc == danhMucSanPham.TenDanhMuc) )
            {
                return "san Pham da ton tai";
            }
            else if(danhMucSanPham.TenDanhMuc == null)
            {
                return "ban chua nhap san pham";
            }
            else
            {
                db.DanhMucSanPhams.Add(danhMucSanPham);
                db.SaveChanges();
                return "Them Thanh Cong";
            }
        }

        public string XoaDanhMuc(int idDanhMucSP)
        {
           var timxoa = DanhSachDanhMucSP().FirstOrDefault(c => c.IdDanhMucSanPham == idDanhMucSP);
            if(timxoa == null)
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

        public DanhMucSanPham idDanhMuc(int id)
        {
            return DanhSachDanhMucSP().FirstOrDefault(c => c.IdDanhMucSanPham == id);
        }
    }
}
