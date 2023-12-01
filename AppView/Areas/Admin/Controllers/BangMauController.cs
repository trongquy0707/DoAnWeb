using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
    public class BangMauController : Controller
    {
        
        // GET: BangMauController
        private readonly HttpClient httpClient;
        public BangMauController()
        {
            httpClient = new HttpClient();
        }
        [Area("Admin")]
        [HttpGet]
        public ActionResult hienthiBangMau() 
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/BangMau/GetListBangMau";
                var hienthi = httpClient.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<Mau> lstDanhMuc = JsonConvert.DeserializeObject<List<Mau>>(data);
                return View(lstDanhMuc);
            }
           
        }

        // GET: BangMauController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BangMauController/Create
        [Area("Admin")]
        [HttpGet]
        public ActionResult themmoiMau()
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

        // POST: BangMauController/Create
        [Area("Admin")]
        [HttpPost]

        public ActionResult themmoiMau(Mau mau)
        {
            try
            {
               
                    if (ModelState.IsValid)
                    {

                        string url = "https://localhost:44396/api/BangMau/ThemMau";
                        var jsonContent = JsonConvert.SerializeObject(mau);
                        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, content).Result;

                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToAction("hienthiBangMau", "BangMau");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Lỗi khi thêm mới sản phẩm chi tiết.");
                            return View("themmoiMau");
                        }
                    }
                    else
                    {
                        // Dữ liệu không hợp lệ, hiển thị form với lỗi
                        return View(mau);
                    }
                

               
            }
            catch
            {
                return View() ;
            }
        }

        [Area("Admin")]
        [HttpGet]
        public ActionResult suaBangMau(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = $"https://localhost:44396/api/BangMau/Getbyid?id={id}";
                var hienthi = httpClient.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                Mau lstDanhMuc = JsonConvert.DeserializeObject<Mau>(data);
                return View(lstDanhMuc);
            }
        }

        [Area("Admin")]
        [HttpPost]
        public ActionResult suaBangMau(Mau mau)
        {
           

                if (ModelState.IsValid)
                {
                    string url = "https://localhost:44396/api/BangMau/SuaMau";
                    var obj = JsonConvert.SerializeObject(mau);
                    StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                    HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, content).Result;

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("hienthiBangMau");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Lỗi khi cập nhật sản phẩm chi tiết.");
                        return RedirectToAction("suaBangMau");
                    }
                }
                else
                {
                    // Dữ liệu không hợp lệ, hiển thị form với lỗi
                    return RedirectToAction("suaBangMau");
                }
            
        }

   

   
       
    }
}
