using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangSizeController : ControllerBase
    {
        // GET: api/<BangSizeController>
        public readonly CoolMate_1Context db;
        public readonly IBangSizeService _iBangSizeService;

        public BangSizeController()
        {
            db = new CoolMate_1Context();
            _iBangSizeService = new BangSizeService();
        }
        [HttpGet("[action]")]
        public IEnumerable<Size> GetListSize()
        {
            return _iBangSizeService.DanhSachbangSize();
        }
        // POST api/<BangSizeController>
        [HttpPost("[action]")]
        public string ThemSize(Size size)
        {
            return _iBangSizeService.ThemMoiBangSize(size);
        }
        
        [HttpPost("[action]")]
        public string SuaSize(Size size)
        {
            return _iBangSizeService.SuaBangSize(size.IdSize,size );
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _iBangSizeService.XoaBangSize(id);
        }
    }
}
