using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangMauController : ControllerBase
    {
        public readonly CoolMate_1Context db;
        public readonly IBangMausServices _iBangMauService;

        public BangMauController()
        {
            db = new CoolMate_1Context();
            _iBangMauService = new BangMauSerVice();
        }
        [HttpGet("[action]")]
        public IEnumerable<Mau> GetListBangMau()
        {
           return _iBangMauService.DanhSachbangMau();
        }

        
        [HttpPost("[action]")]
        public string ThemMau(Mau mau)
        {
            return _iBangMauService.ThemMoiBangMau(mau);
        }

    
        
        // PUT api/<BangMauController>/5
        [HttpPost("[action]")]
        public string SuaMau(Mau mau)
        {
            return _iBangMauService.SuaBangMau(mau.IdMau , mau);
        }

        // DELETE api/<BangMauController>/5
        [HttpDelete("[action]")]
        public string Delete(int id)
        {
            return _iBangMauService.XoaBangMau( id);
        }
        [HttpGet("[action]")]
        public Mau Getbyid(int id)
        {
            return _iBangMauService.getbyid(id);
        }


    }


}
