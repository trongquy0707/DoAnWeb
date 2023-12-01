using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
        public class SanPhamChiTietController : Controller
    {

        private readonly HttpClient client;
        CoolMate_1Context _context;

        
        private IBangMausServices bangMausServices;
        private IBangSizeService bangSizeService;
        private IDanhMucSanPhamservice danhMucSanPhamservice;
        public SanPhamChiTietController()
        {
            _context = new CoolMate_1Context();
            bangMausServices = new BangMauSerVice();
            bangSizeService = new BangSizeService();
            danhMucSanPhamservice = new DanhMucSanPhamservice();

            client = new HttpClient();
        }

        [Area("Admin")]
        [HttpGet]
        public ActionResult hienthiSanPhamCT()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/SanPhamChiTiet/GetFull";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<SanPhamChiTietViewModel> lstDanhMuc = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModel>>(data);
                ViewBag.SPCT = lstDanhMuc;
                return View(lstDanhMuc);
            }
      
        }

        // GET: SanPhamChiTietController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SanPhamChiTietController/Create\
        [Area("Admin")]
        [HttpGet]
        public ActionResult themmoiSanPhamCT()
        {
          
                
                ViewBag.DanhMuc = new SelectList(_context.DanhMucSanPhams.ToList().OrderBy(c => c.TenDanhMuc), "IdDanhMucSanPham", "TenDanhMuc");
                ViewBag.BangMau = new SelectList(_context.Maus.ToList().OrderBy(c => c.TenMau), "IdMau", "TenMau");
                ViewBag.BangSize = new SelectList(_context.Sizes.ToList().OrderBy(c => c.TenSize), "IdSize", "TenSize");
        

                return View();
            
        }

        // POST: SanPhamChiTietController/Create
        [Area("Admin")]
        [HttpPost]
        public ActionResult themmoiSanPhamCT(SanPhamChiTiet sanPhamChiTiet)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    string url = "https://localhost:44396/api/SanPhamChiTiet/ThemSPCT";
                    var jsonContent = JsonConvert.SerializeObject(sanPhamChiTiet);
                    StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("HienthiSanPhamCT", "SanPhamChiTiet");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Lỗi khi thêm mới sản phẩm chi tiết.");
                        return View();
                    }
                }
                else
                {
                    // Dữ liệu không hợp lệ, hiển thị form với lỗi
                    return View(sanPhamChiTiet);
                }

            }
            catch
            {
                return View();
            }
        }
        [Area("Admin")]
        [HttpGet]

        // GET: SanPhamChiTietController/Edit/5
        public ActionResult suaSanPhamCT(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                ViewBag.DanhMuc = new SelectList(_context.DanhMucSanPhams.ToList().OrderBy(c => c.TenDanhMuc), "IdDanhMucSanPham", "TenDanhMuc");
                ViewBag.BangMau = new SelectList(_context.Maus.ToList().OrderBy(c => c.TenMau), "IdMau", "TenMau");
                ViewBag.BangSize = new SelectList(_context.Sizes.ToList().OrderBy(c => c.TenSize), "IdSize", "TenSize");
                string url = $"https://localhost:44396/api/SanPhamChiTiet/Getbyid?id={id}";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                SanPhamChiTiet lstDanhMuc = JsonConvert.DeserializeObject<SanPhamChiTiet>(data);

                return View(lstDanhMuc);
            }
        }

        // POST: SanPhamChiTietController/Edit/5
        [Area("Admin")]
        [HttpPost]
        public ActionResult suaSanPhamCT(SanPhamChiTiet sanPhamChiTiet)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:44396/api/SanPhamChiTiet/suaSPCT";
                var obj = JsonConvert.SerializeObject(sanPhamChiTiet);
                StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("hienthiSanPhamCT","SanPhamChiTiet");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lỗi khi cập nhật sản phẩm chi tiết.");
                    return RedirectToAction("suaSanPhamCT");
                }
            }
            else
            {
                // Dữ liệu không hợp lệ, hiển thị form với lỗi
                return RedirectToAction("suaSanPhamCT");
            }
        }
        [Area("Admin")]

        // GET: SanPhamChiTietController/Delete/5
        public ActionResult XoaSanPhamCT(int id)
        {
            string url = $"https://localhost:44396/api/SanPhamChiTiet/XoaSanPhamCT?id={id}";
            HttpResponseMessage httpResponseMessage = client.DeleteAsync(url).Result;
            return RedirectToAction("hienthiSanPhamCT");
        }

        // POST: SanPhamChiTietController/Delete/5
        // [HttpDelete("[action]")]

        public ActionResult XoaSanPhamCT(SanPhamChiTiet sanPhamChiTiet)
        {
            try
            {
                //string url = "https://localhost:44396/api/SanPhamChiTiet/XoaSanPhamCT";
                //var obj = JsonConvert.SerializeObject(sanPhamChiTiet);
                ////StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                //HttpResponseMessage httpResponseMessage = client.DeleteAsync(url).Result;

                //if (httpResponseMessage.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("hienthiSanPhamCT");
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Lỗi khi cập nhật sản phẩm chi tiết.");
                //    return RedirectToAction("suaSanPhamCT");

                return View();
            }
            catch

            {
                return View();
            }
        }
    }
}
