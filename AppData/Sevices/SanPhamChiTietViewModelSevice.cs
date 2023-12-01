using AppData.IServices;
using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
    public class SanPhamChiTietViewModelSevice
    {
        private readonly iSanPhamChiTietSerVices _iSPCT;
        private readonly IDanhMucSanPhamservice _iDMSP;
        private readonly IBangMausServices _bangMausServices;
        private readonly IBangSizeService bangSizeService;

        public SanPhamChiTietViewModelSevice()
        {
            _iSPCT = new SanPhamChiTietServices();
            _iDMSP = new DanhMucSanPhamservice();
            _bangMausServices = new BangMauSerVice();    
            bangSizeService     = new BangSizeService();
        }

        public List<SanPhamChiTietViewModel> SanPhamChiTietHoanThien() 
        {
            //landa 
            var spct = from A in _iSPCT.DanhSachSanPhamCT()
                       join B in _iDMSP.DanhSachDanhMucSP() on A.IdDanhMucSanPham equals B.IdDanhMucSanPham
                       join C in bangSizeService.DanhSachbangSize() on A.IdSize equals C.IdSize
                       join D in _bangMausServices.DanhSachbangMau() on A.IdMau equals D.IdMau
                     select  new SanPhamChiTietViewModel
                       {
                           IdSanPhamChiTiet = A.IdSanPhamChiTiet,
                           DanhMucSanPham = B.TenDanhMuc,
                           Size = C.TenSize,
                           Mau = D.TenMau,
                           SoLuong = A.SoLuong,
                           Anh = A.Anh,
                           GiaSp = A.GiaSp,
                           TenSanPham = A.TenSanPham,
                           TrangThai = A.TrangThai,
                       };
            return spct.ToList();
        }

        public SanPhamChiTietViewModel getbyID(int id)
        {
          
            var spct = from A in _iSPCT.DanhSachSanPhamCT()
                       join B in _iDMSP.DanhSachDanhMucSP() on A.IdDanhMucSanPham equals B.IdDanhMucSanPham
                       join C in bangSizeService.DanhSachbangSize() on A.IdSize equals C.IdSize
                       join D in _bangMausServices.DanhSachbangMau() on A.IdMau equals D.IdMau
                       select new SanPhamChiTietViewModel
                       {
                           IdSanPhamChiTiet = A.IdSanPhamChiTiet,
                           DanhMucSanPham = B.TenDanhMuc,
                           Size = C.TenSize,
                           Mau = D.TenMau,
                           SoLuong = A.SoLuong,
                           Anh = A.Anh,
                           GiaSp = A.GiaSp,
                           TenSanPham = A.TenSanPham,
                           TrangThai = A.TrangThai,
                       };
            return spct.FirstOrDefault(c => c.IdSanPhamChiTiet == id);
        }
    }
}
