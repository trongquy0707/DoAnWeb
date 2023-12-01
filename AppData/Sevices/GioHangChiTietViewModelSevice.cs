using AppData.IServices;
using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Sevices
{
   
    public class GioHangChiTietViewModelSevice
    {
        private readonly iSanPhamChiTietSerVices _iSPCT;
        private readonly iGioHangSerVice _iGioHangSerVice;
        private readonly iGioHangChiTietSerVice _iGioHangChiTietSerVice; 
        public GioHangChiTietViewModelSevice() 
        {
            _iSPCT = new SanPhamChiTietServices();
            _iGioHangSerVice = new GioHangSerVice();
            _iGioHangChiTietSerVice = new GioHangChiTietSerVice();
        }
        public List<GiohangChiTietViewModel> GioHanghoanthien()
        {
            var ghct = from A in _iGioHangChiTietSerVice.DanhSachGioHangCT()
                       join B in _iGioHangSerVice.DanhSachGioHang() on A.IdGioHang equals B.IdGioHang
                       join C in _iSPCT.DanhSachSanPhamCT() on A.IdSanPhamChiTiet equals C.IdSanPhamChiTiet

                       select new GiohangChiTietViewModel
                       {
                           IdGioHangChiTiet = A.IdGioHangChiTiet,
                           SanPhamChiTiet = C.TenSanPham,
                           Anh = C.Anh,
                           SoLuong = C.SoLuong,
                           GiaSp = C.GiaSp,

                       };
            return ghct.ToList();
        }

    }
}
