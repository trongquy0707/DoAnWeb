using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        // GET: api/<GioHangChiTietController>
        public readonly CoolMate_1Context db;
        public readonly iGioHangChiTietSerVice _iGioHangChiTietSerVice;
        public GioHangChiTietController()
        {
            db = new CoolMate_1Context();
            _iGioHangChiTietSerVice = new GioHangChiTietSerVice();
        }
        [HttpGet("[action]")]
        public IEnumerable<GioHangChiTiet> GetGioHangCT()
        {
            return _iGioHangChiTietSerVice.DanhSachGioHangCT();
        }

        [HttpGet("[action]")]
        public List<GioHangChiTiet> GioHangUser(int id)
        {
            return _iGioHangChiTietSerVice.getbyidGioHang(id);
        }

        // GET api/<GioHangChiTietController>/5
        [HttpGet("[action]")]
        public GioHangChiTiet Getbyid(int id)
        {
            return _iGioHangChiTietSerVice.getbyid(id);
        }

        // POST api/<GioHangChiTietController>


        [HttpPost("[action]")]
        public string SuaGioHangCT(GioHangChiTiet gioHangChiTiet)
        {
            return _iGioHangChiTietSerVice.SuaGioHangCT(gioHangChiTiet.IdGioHangChiTiet, gioHangChiTiet);
        }
        [HttpDelete("[action]")]
        public string Delete(int id)
        {
            return _iGioHangChiTietSerVice.XoaGioHangCT(id);
        }
    }
}
