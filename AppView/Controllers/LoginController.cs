using AppData.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace AppView.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient client;

        public LoginController()
        {
            client = new HttpClient();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            try
            {

                string url = $"https://localhost:44396/api/NguoiDung/Login?sodienthoai={user.SoDienThoai}&matkhau={user.MatKhau}";
            
                var obj = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await client.PostAsync(url, content);

                List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.MobilePhone, user.SoDienThoai),
                        new Claim("OtherProperties", "Example Role")
                    };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,

                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var ketqua = await httpResponseMessage.Content.ReadAsStringAsync();
                    if (ketqua == "danh nhap Admin thanh cong")
                    {

                        HttpContext.Session.SetString("UserRole", "Admin");
                        return RedirectToAction("TrangChu", "Home", new { area = "Admin" });
                        
                       
                    }
                    else if (ketqua == "danh nhap khach hang thanh cong")
                    {
                        HttpContext.Session.SetString("UserRole", "KhachHang");
                        return RedirectToAction("IndexKhachHang", "HomeKhachHang", new { area = "KhachHang" });
                       
                    }
                    else
                    {
                       
                        return RedirectToAction("Login", "Login");
                        
                    }
                }
                else
                {
                    // Xử lý lỗi nếu cần
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return RedirectToAction("Login", "Login");
            }
        }

       
        public IActionResult Logout()
        {
            // Xóa toàn bộ session hoặc các key cụ thể tùy vào nhu cầu
            HttpContext.Session.Clear(); // hoặc HttpContext.Session.Remove("UserRole")
            return RedirectToAction("Login", "Login", new { area = "" });
        }

    }
}
