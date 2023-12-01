using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        // GET: api/<GioHangController>
        public readonly CoolMate_1Context db;
        public readonly iGioHangSerVice _iGioHangSerVice;
        public GioHangController()
        {
            db = new CoolMate_1Context();
            _iGioHangSerVice = new GioHangSerVice();
        }
       
        [HttpGet("[action]")]
        public IEnumerable<GioHang> GetGioHang()
        {
            return _iGioHangSerVice.DanhSachGioHang();
        }

        // GET api/<GioHangController>/5
        [HttpGet("[action]")]
        public GioHang Getbyid(int id)
        {
            return _iGioHangSerVice.getbyid(id);
        }

        // POST api/<GioHangController>
        [HttpPost]
        public string ThemGioHang(GioHang gioHang )
        {
            
                return _iGioHangSerVice.ThemMoiGioHang(gioHang);
            
        }


     
    }
}
