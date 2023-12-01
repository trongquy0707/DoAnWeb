using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamChiTietController : ControllerBase
    {
        public readonly CoolMate_1Context db;
        public readonly SanPhamChiTietViewModelSevice sevice;
        public readonly iGioHangChiTietSerVice iGioHangChiTietSerVice;
        public readonly iGioHangSerVice _iGioHangSerVice;
        public readonly iSanPhamChiTietSerVices _iSanPhamChiTietSerVices;
        // GET: api/<SanPhamChiTietController>
        public SanPhamChiTietController()
        {

            db = new CoolMate_1Context();
            sevice = new SanPhamChiTietViewModelSevice();
            _iSanPhamChiTietSerVices = new SanPhamChiTietServices();
            _iGioHangSerVice = new GioHangSerVice();
            iGioHangChiTietSerVice = new GioHangChiTietSerVice();
        }
        [HttpGet]
        public IEnumerable<SanPhamChiTiet> GetListSPCT()
        {
            return _iSanPhamChiTietSerVices.DanhSachSanPhamCT();
        }
        [HttpGet("[action]")]
        public List<SanPhamChiTietViewModel> GetFull()
        {
            return sevice.SanPhamChiTietHoanThien();
        }

        // GET api/<SanPhamChiTietController>/5
        [HttpGet("[action]")]
        public SanPhamChiTiet Getbyid(int id)
        {
            return _iSanPhamChiTietSerVices.getbyid(id);
        }

        // POST api/<SanPhamChiTietController>
        [HttpPost("[action]")]
        public string ThemSPCT(SanPhamChiTiet sanPhamChiTiet)
        {
            return _iSanPhamChiTietSerVices.ThemMoiSanPhamCT(sanPhamChiTiet);
        }

        // PUT api/<SanPhamChiTietController>/5
        [HttpPost("[action]")]
        public string suaSPCT(SanPhamChiTiet sanPhamChiTiet)
        {
            return _iSanPhamChiTietSerVices.SuaSanPhamCT(sanPhamChiTiet.IdSanPhamChiTiet, sanPhamChiTiet);
        }

        // DELETE api/<SanPhamChiTietController>/5
        [HttpDelete("[action]")]
        public string XoaSanPhamCT(int id)
        {
            return _iSanPhamChiTietSerVices.XoaSanPhamCT(id);
        }

        [HttpGet("[action]")]
        public List<SanPhamChiTietViewModel> GetFullDoHangNgay()
        {
            return sevice.SanPhamChiTietHoanThien().Where(c => c.DanhMucSanPham.Contains("Mặc Hàng Ngày")).ToList();
        }
        [HttpGet("[action]")]
        public List<SanPhamChiTietViewModel> GetFullDoThuDong()
        {
            return sevice.SanPhamChiTietHoanThien().Where(c => c.DanhMucSanPham.Contains("Đồ Mùa Đông")).ToList();
        }
        [HttpGet("[action]")]
        public List<SanPhamChiTietViewModel> GetFullDoTheThao()
        {
            return sevice.SanPhamChiTietHoanThien().Where(c => c.DanhMucSanPham.Contains("Đồ Thể Thao")).ToList();
        }

        [HttpGet("[action]")]
        public List<SanPhamChiTietViewModel> GetFullDoLot()
        {
            return sevice.SanPhamChiTietHoanThien().Where(c => c.DanhMucSanPham.Contains("Đồ Lót")).ToList();
        }

        [HttpGet("[action]")]
        public SanPhamChiTietViewModel GetbyidSPCT(int id)
        {
            return sevice.getbyID(id);
        }


        [HttpPost("[action]")]
        public string ThemGioHangCT(int idSP, int idKhachHang)
        {
            var giohang = _iGioHangSerVice.getbyidKhachHang(idKhachHang);
            if (giohang != null)
            {
                var sanpham = iGioHangChiTietSerVice.getbyidGioHang(giohang.IdGioHang).FirstOrDefault(c => c.IdSanPhamChiTiet == idSP);
                if (sanpham == null)
                {
                    GioHangChiTiet gioHangChiTiet = new GioHangChiTiet()
                    {
                        IdSanPhamChiTiet = idSP,
                        IdGioHang = giohang.IdGioHang,
                        SoLuong = 1,
                        GiaSp = sevice.SanPhamChiTietHoanThien().FirstOrDefault(c => c.IdSanPhamChiTiet == idSP).GiaSp
                    };
                    return iGioHangChiTietSerVice.ThemMoiGioHangCT(gioHangChiTiet);
                }
                else
                {
                    sanpham.SoLuong ++;
                    return iGioHangChiTietSerVice.SuaGioHangCT(sanpham.IdGioHangChiTiet, sanpham);
                }
            }
            else
            {
                GioHang gioHang = new GioHang()
                {
                    IdKhachHang = idKhachHang
                };
                _iGioHangSerVice.ThemMoiGioHang(gioHang);

                GioHangChiTiet gioHangChiTiet = new GioHangChiTiet()
                {
                    IdSanPhamChiTiet = idSP,
                    IdGioHang = gioHang.IdGioHang,
                    SoLuong = 1,
                    GiaSp = sevice.SanPhamChiTietHoanThien().FirstOrDefault(c => c.IdSanPhamChiTiet == idSP).GiaSp
                };
                return iGioHangChiTietSerVice.ThemMoiGioHangCT(gioHangChiTiet);
            }
        }
    }


}
