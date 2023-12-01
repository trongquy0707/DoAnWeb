using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AppView.Areas.Admin.Controllers
{
    public class DanhMucSanPhamController : Controller
    {

        HttpClient client;
        public DanhMucSanPhamController()
        {
            client = new HttpClient();
        }
    
        [Area("Admin")]
        [HttpGet]
        public ActionResult hienthiDanhMuc()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/DanhMucSanPham/GetDanhMucSanPham";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<DanhMucSanPham> lstDanhMuc = JsonConvert.DeserializeObject<List<DanhMucSanPham>>(data);
                return View(lstDanhMuc);
            }
        }
        public ActionResult Details(int id)
        {
            return View();
        }

      
        [Area("Admin")]
        [HttpGet]
        public ActionResult themmoiDanhMuc()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                return View();
            }
        }

       
        [Area("Admin")]
        [HttpPost]
      
        public ActionResult themmoiDanhMuc(DanhMucSanPham danhMucSanPham)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    string url = "https://localhost:44396/api/DanhMucSanPham/ThemDanhMuc";
                    var jsonContent = JsonConvert.SerializeObject(danhMucSanPham);
                    StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("hienthiDanhMuc", "DanhMucSanPham");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Lỗi khi thêm mới Danh mục Sản phẩm.");
                        return View();
                    }
                }
                else
                {
                    // Dữ liệu không hợp lệ, hiển thị form với lỗi
                    return View(danhMucSanPham);
                }

            }
            catch
            {
                return View();
            }
        }

        [Area("Admin")]
        [HttpGet]
        public ActionResult suaDanhMuc(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {

                string url = $"https://localhost:44396/api/DanhMucSanPham/idDanhMuc?id={id}";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                DanhMucSanPham lstDanhMuc = JsonConvert.DeserializeObject<DanhMucSanPham>(data);
                return View(lstDanhMuc);
            }
        }

        [Area("Admin")]
        [HttpPost]
        public ActionResult suaDanhMuc(DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:44396/api/DanhMucSanPham/SuaDanhMuc";
                var obj = JsonConvert.SerializeObject(danhMucSanPham);
                StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("hienthiDanhMuc", "DanhMucSanPham");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lỗi khi cập nhật sản phẩm chi tiết.");
                    return RedirectToAction("suaDanhMuc", "DanhMucSanPham");
                }
            }
            else
            {
                // Dữ liệu không hợp lệ, hiển thị form với lỗi
                return RedirectToAction("suaDanhMuc");
            }
        }

    }
}
