using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{


    public class SanPhamChiTietServices : iSanPhamChiTietSerVices
    {
        CoolMate_1Context db;
        private readonly IDanhMucSanPhamservice danhMucSanPhamservice;
        public SanPhamChiTietServices()
        {

            db = new CoolMate_1Context();
            danhMucSanPhamservice = new DanhMucSanPhamservice();
        }
        public List<SanPhamChiTiet> DanhSachSanPhamCT()
        {
            var data = db.SanPhamChiTiets.ToList();
            return data;
        }

        public string SuaSanPhamCT(int id , SanPhamChiTiet sanphamCT)
        {

            var timkiem = db.SanPhamChiTiets.FirstOrDefault(c => c.IdSanPhamChiTiet == sanphamCT.IdSanPhamChiTiet);
            if (timkiem == null)
            {
                return "Không tìm thấy San pham!!";
            }
            else
            {
                timkiem.IdDanhMucSanPham = sanphamCT.IdDanhMucSanPham;
                timkiem.IdMau = sanphamCT.IdMau;
                timkiem.IdSize = sanphamCT.IdSize;
                timkiem.SoLuong = sanphamCT.SoLuong;
                timkiem.Anh = sanphamCT.Anh;
                timkiem.GiaSp = sanphamCT.GiaSp;
                timkiem.TenSanPham = sanphamCT.TenSanPham;
                timkiem.TrangThai = sanphamCT.TrangThai;
                db.Update(timkiem);
                db.SaveChanges();
                return "Sửa thành công San pham!!";
            }
        }

        public string ThemMoiSanPhamCT(SanPhamChiTiet sanphamCT)
        {
            try
            {
                var danhmuc = danhMucSanPhamservice.DanhSachDanhMucSP().FirstOrDefault(c => c.IdDanhMucSanPham == sanphamCT.IdSanPhamChiTiet);
                if (string.IsNullOrEmpty(sanphamCT.TenSanPham))
                {
                    return "bạn chưa nhập tên sản phẩm!!";
                }
                else
                {
                    SanPhamChiTiet sanPhamChiTiet = new SanPhamChiTiet();
                    sanPhamChiTiet.IdDanhMucSanPham = danhMucSanPhamservice.DanhSachDanhMucSP().FirstOrDefault(c => c.IdDanhMucSanPham == sanphamCT.IdDanhMucSanPham).IdDanhMucSanPham;
                    sanPhamChiTiet.IdMau = db.Maus.FirstOrDefault(c => c.IdMau == sanphamCT.IdMau).IdMau;
                    sanPhamChiTiet.IdSize = db.Sizes.FirstOrDefault(c => c.IdSize == sanphamCT.IdSize).IdSize;
                    sanPhamChiTiet.SoLuong = sanphamCT.SoLuong;
                    sanPhamChiTiet.Anh = sanphamCT.Anh;
                    sanPhamChiTiet.GiaSp = sanphamCT.GiaSp;
                    sanPhamChiTiet.TenSanPham = sanphamCT.TenSanPham;
                    sanPhamChiTiet.TrangThai = 1;
                    db.SanPhamChiTiets.Add(sanPhamChiTiet);
                    db.SaveChanges();
                    return "them thanh cong";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string XoaSanPhamCT(int idSanPhamCT)
        {
            var timxoa = DanhSachSanPhamCT().FirstOrDefault(c => c.IdSanPhamChiTiet == idSanPhamCT);
            if (timxoa == null)
            {
                return "Không tìm thấy sản phẩm !!";
            }
            else
            {
                db.Remove(timxoa);
                db.SaveChanges();
                return "Xoa thanh cong";
            }
        }

        public SanPhamChiTiet getbyid(int id)
        {
            return DanhSachSanPhamCT().FirstOrDefault(c => c.IdSanPhamChiTiet == id);
        }
    }
}
