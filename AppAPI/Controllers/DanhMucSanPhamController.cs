using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucSanPhamController : ControllerBase
    {
        private readonly CoolMate_1Context db;
        private readonly IDanhMucSanPhamservice _iDanhMucSanPham;
        // GET: api/<DanhMucSanPhamController>
        public DanhMucSanPhamController()
        {
            db =  new CoolMate_1Context();
            _iDanhMucSanPham = new DanhMucSanPhamservice();
        }
        [HttpGet("[action]")]
        public IEnumerable<DanhMucSanPham> GetDanhMucSanPham()
        {
            return _iDanhMucSanPham.DanhSachDanhMucSP();
        }

        // GET api/<DanhMucSanPhamController>/5
        [HttpPost("[action]")]
        public string SuaDanhMuc(DanhMucSanPham danhMucSanPham)
        {
            return _iDanhMucSanPham.SuaDanhMuc(danhMucSanPham.IdDanhMucSanPham, danhMucSanPham);
        }
        [HttpGet("[action]")]
        public DanhMucSanPham idDanhMuc(int id)
        {
            return _iDanhMucSanPham.idDanhMuc(id);
        }

        // POST api/<DanhMucSanPhamController>
        [HttpPost("[action]")]
        public string ThemDanhMuc(DanhMucSanPham danhMucSanPham)
        {
            return _iDanhMucSanPham.ThemMoiDanhMuc(danhMucSanPham);
        }

        // DELETE api/<DanhMucSanPhamController>/5
        [HttpDelete("[action]")]
        public string XoaDanhMuc(int id)
        {
            return _iDanhMucSanPham.XoaDanhMuc(id);
        }
    }
}
