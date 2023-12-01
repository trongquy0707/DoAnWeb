using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase

    {
        private readonly INguoiDungServiec _INguoiDungService; 
        // GET: api/<NguoiDungController>
        public NguoiDungController()
        {
            _INguoiDungService = new NguoiDungServiec();
        }
        [HttpGet("[action]")]
        public IEnumerable<User> getListUser()
        {
            return _INguoiDungService.ListUser();
        }

        // GET api/<NguoiDungController>/5
        [HttpGet("[action]")]
        public User getbyid(int id)
        {

            return _INguoiDungService.getbyid(id);
        }

        [HttpPost("[action]")]
        public string Login(string sodienthoai , string matkhau)
        {
            var timkiem = _INguoiDungService.ListUser().FirstOrDefault(c => c.SoDienThoai == sodienthoai);
            if (timkiem != null)
            {
                if (timkiem.MatKhau == timkiem.MatKhau)
                {
                    if (timkiem.IdChucVu == 1)
                    {
                        return "danh nhap Admin thanh cong";
                    }
                    else
                    {
                       
                        return "danh nhap khach hang thanh cong";
                    }
                }
                else
                {
                    return "sai mat khau";
                }
            }
            else
            {
                return " tai khoan khog ton tai";
            }
        }

        [HttpPost("[action]")]
        public string ThemMoiUser(User user)
        {
            return _INguoiDungService.ThemMoiNguoiDung(user);
            
        }
        [HttpPost("[action]")]
        public string KhoaUser(int id)
        {
            return _INguoiDungService.SuaNguoiDung(id);
        }
        [HttpPost("[action]")]
        public string MoUser(int id)
        {
            return _INguoiDungService.mokhoa(id);
        }
    }
}
