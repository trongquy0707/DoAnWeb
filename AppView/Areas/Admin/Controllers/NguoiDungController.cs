using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDungController
        HttpClient client;
        public NguoiDungController()
        {
            client = new HttpClient();
        }
        [Area("Admin")]
        [HttpGet]
        public ActionResult hienthiNguoiDung()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/NguoiDung/getListUser";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<User> lstDanhMuc = JsonConvert.DeserializeObject<List<User>>(data);
                return View(lstDanhMuc);
            }

        }

        // GET: NguoiDungController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NguoiDungController/Create
        [Area("Admin")]
        [HttpGet]
        public ActionResult ThemmoiUser()
        {
            return View();
        }

        // POST: NguoiDungController/Create
        [Area("Admin")]
        [HttpPost]
        public ActionResult ThemmoiUser(User user)
        {
            string url = "https://localhost:44396/api/NguoiDung/ThemMoiUser";
            var jsonContent = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Lỗi khi thêm mới sản phẩm chi tiết.");
                return View();
            }
        }

        [Area("Admin")]
        [HttpGet]
        [HttpPost]
        public ActionResult KhoaUser(User user)
        {
            string url = $"https://localhost:44396/api/NguoiDung/KhoaUser?id={user.IdUser}";
            var obj = JsonConvert.SerializeObject(user);
            StringContent stringContent = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, stringContent).Result;
            return RedirectToAction("hienthiNguoiDung");
        }


        [Area("Admin")]
        [HttpGet]
        [HttpPost]
        public ActionResult MoUser(User user)
        {
            string url = $"https://localhost:44396/api/NguoiDung/MoUser?id={user.IdUser}";
            var obj = JsonConvert.SerializeObject(user);
            StringContent stringContent = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, stringContent).Result;
            return RedirectToAction("hienthiNguoiDung");
        }



    }
}
