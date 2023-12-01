using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        public readonly CoolMate_1Context db;
        public readonly iVoucherService _iVoucherService;
        // GET: api/<VoucherController>
        public VoucherController()
        {
            db = new CoolMate_1Context();
            _iVoucherService = new VoucherService();
        }
        [HttpGet("[action]")]
        public IEnumerable<Voucherr> GetListVoucher()
        {
            return _iVoucherService.DanhSachVoucher();
        }

        // GET api/<VoucherController>/5
       
        [HttpGet("[action]")]
        public Voucherr Getbyid(int id)
        {
            return _iVoucherService.getbyid(id);
        }

        // POST api/<VoucherController>
        [HttpPost("[action]")]
        public string ThemVoucher(Voucherr voucherr)
        {
            return _iVoucherService.ThemMoiVoucher(voucherr);
        }

        // PUT api/<VoucherController>/5
        [HttpPost("[action]")]
        public string SuaVoucher(Voucherr voucherr)
        {
            return _iVoucherService.SuaVoucher(voucherr.IdVoucher,voucherr);

        }

        // DELETE api/<VoucherController>/5
        [HttpDelete("[action]")]
        public string Delete(int id)
        {
            return _iVoucherService.XoaVoucher(id);
        }
    }
}
