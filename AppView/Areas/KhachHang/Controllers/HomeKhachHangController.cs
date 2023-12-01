using AppData.IServices;
using AppData.Models;
using AppData.Sevices;
using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AppView.Areas.KhachHang.Controllers
{
    public class HomeKhachHangController : Controller
    {
        // GET: HomeController
        HttpClient client;
        public readonly INguoiDungServiec nguoiDungServiec;
        public HomeKhachHangController()
        {
            client = new HttpClient();
            nguoiDungServiec = new NguoiDungServiec();
        }

        [Area("KhachHang")]
        [HttpGet]
        public ActionResult IndexKhachHang()
        {
            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
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

        [Area("KhachHang")]
        [HttpGet]
        public ActionResult DoTheThao()
        {


            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {

                string url = "https://localhost:44396/api/SanPhamChiTiet/GetFullDoTheThao";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<SanPhamChiTietViewModel> lstDanhMuc = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModel>>(data);
                ViewBag.SPCT = lstDanhMuc;
                return View(lstDanhMuc);
            }
        }
        [Area("KhachHang")]
        [HttpGet]
        public ActionResult DoThuDong()
        {

            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/SanPhamChiTiet/GetFullDoThuDong";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<SanPhamChiTietViewModel> lstDanhMuc = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModel>>(data);
                ViewBag.SPCT = lstDanhMuc;
                return View(lstDanhMuc);
            }
        }

        [Area("KhachHang")]
        [HttpGet]
        public ActionResult DoLot()
        {

            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/SanPhamChiTiet/GetFullDoLot";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<SanPhamChiTietViewModel> lstDanhMuc = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModel>>(data);
                ViewBag.SPCT = lstDanhMuc;
                return View(lstDanhMuc);
            }
        }

        [Area("KhachHang")]
        [HttpGet]
        public ActionResult DoHangNgay()
        {

            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = "https://localhost:44396/api/SanPhamChiTiet/GetFullDoHangNgay";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<SanPhamChiTietViewModel> lstDanhMuc = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModel>>(data);
                ViewBag.SPCT = lstDanhMuc;
                return View(lstDanhMuc);
            }
        }


        [Area("KhachHang")]
        [HttpGet]
        public ActionResult ChiTietSanPham(int id)
        {

            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                string url = $"https://localhost:44396/api/SanPhamChiTiet/GetbyidSPCT?id={id}";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                SanPhamChiTietViewModel lstDanhMuc = JsonConvert.DeserializeObject<SanPhamChiTietViewModel>(data);

                return View(lstDanhMuc);
            }
        }

        [Area("KhachHang")]
        [HttpGet]
        public ActionResult ThemGioHang(SanPhamChiTietViewModel sanpham)
        {

            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            var user = HttpContext.User;
            var phone = user.FindFirstValue(ClaimTypes.MobilePhone);

            var idnguoidung = nguoiDungServiec.ListUser().FirstOrDefault(c => c.SoDienThoai == phone).IdUser;
            if (phone != null)
            {
                var userEntity = nguoiDungServiec.ListUser().FirstOrDefault(c => c.SoDienThoai == phone);
                if (userEntity != null)
                {

                    string url = $"https://localhost:44396/api/SanPhamChiTiet/ThemGioHangCT?idSP={sanpham.IdSanPhamChiTiet}&idKhachHang={idnguoidung}";

                    var obj = JsonConvert.SerializeObject(sanpham);
                    StringContent stringContent = new StringContent(obj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GioHangCT");
                    }
                    else
                    {
                        return RedirectToAction("ChiTietSanPham", new { id = sanpham.IdSanPhamChiTiet });
                    }
                }
                else
                {
                    return RedirectToAction("ChiTietSanPham", new { id = sanpham.IdSanPhamChiTiet });
                }
            }
            else
            {
                return RedirectToAction("ChiTietSanPham", new { id = sanpham.IdSanPhamChiTiet });
            }


        }
        public int idKhachHang()
        {

            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            var user = HttpContext.User;
            var phone = user.FindFirstValue(ClaimTypes.MobilePhone);

            var idnguoidung = nguoiDungServiec.ListUser().FirstOrDefault(c => c.SoDienThoai == phone).IdUser;
            return idnguoidung;
        }


        [Area("KhachHang")]
        [HttpGet]
        public ActionResult GioHangCT( int id)
        {

            if (HttpContext.Session.GetString("UserRole") != "KhachHang")
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
            else
            {
                id = idKhachHang();
                string url = $"https://localhost:44396/api/GioHangChiTiet/GioHangUser?id={id}";
                var hienthi = client.GetAsync(url).Result;
                var data = hienthi.Content.ReadAsStringAsync().Result;
                List<GioHangChiTiet> lstDanhMuc = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(data);
                ViewBag.SPCT = lstDanhMuc;
                return View(lstDanhMuc);
            }
        }


    }
}
