using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
    public class VoucherController : Controller
    {
        // GET: VoucherController
        HttpClient client;
        public VoucherController()
        {
            client = new HttpClient();
        }
        [Area("Admin")]
        [HttpGet]
        public ActionResult hienthiVoucher()
        {
            string url = "https://localhost:44396/api/Voucher/GetListVoucher";
            var hienthi = client.GetAsync(url).Result;
            var data = hienthi.Content.ReadAsStringAsync().Result;
            List<Voucherr> lstDanhMuc = JsonConvert.DeserializeObject<List<Voucherr>>(data);
            return View(lstDanhMuc);
        }
 
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VoucherController/Create
        [Area("Admin")]
        [HttpGet]
        public ActionResult themmoiVoucher()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]

        public ActionResult themmoiVoucher(Voucherr voucherr)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    string url = "https://localhost:44396/api/Voucher/ThemVoucher";
                    var jsonContent = JsonConvert.SerializeObject(voucherr);
                    StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("hienthiVoucher", "voucher");
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
                    return View(voucherr);
                }
            }
            catch
            {
                return View();
            }
        }
        [Area("Admin")]
        [HttpGet]
        public ActionResult suaVoucher(int id)
        {
            string url = $"https://localhost:44396/api/Voucher/Getbyid?id={id}";
            var hienthi = client.GetAsync(url).Result;
            var data = hienthi.Content.ReadAsStringAsync().Result;
            Voucherr voucherr = JsonConvert.DeserializeObject<Voucherr>(data);
            return View(voucherr);
        }

        [Area("Admin")]
        [HttpPost]
        public ActionResult suaVoucher(Voucherr voucherr)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:44396/api/Voucher/SuaVoucher";
                var obj = JsonConvert.SerializeObject(voucherr);
                StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("hienthiVoucher");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lỗi khi sửa");
                    return RedirectToAction("suaVoucher");
                }
            }
            else
            {
                // Dữ liệu không hợp lệ, hiển thị form với lỗi
                return RedirectToAction("suaVoucher");
            }
        }
        // TAO SẼ SỬA MÀY SAU
        //[Area("Admin")]
        //[HttpGet]
        //public ActionResult xoaVoucher(int id)
        //{
        //    string url = $"https://localhost:44396/api/Voucher/Getbyid?id={id}";
        //    var hienthi = client.GetAsync(url).Result;
        //    var data = hienthi.Content.ReadAsStringAsync().Result;
        //    Voucherr voucherr = JsonConvert.DeserializeObject<Voucherr>(data);
        //    return View(voucherr);
        //}
        //[Area("Admin")]
        //[HttpPost]
        //[ActionName("xoaVoucher")]
        //public ActionResult DeleteConfirm(int id)
        //{

        //    try
        //    {
        //        string url = $"https://localhost:44396/api/Voucher/Delete?id={id}";
        //        HttpResponseMessage httpResponseMessage = client.DeleteAsync(url).Result;
        //        httpResponseMessage.EnsureSuccessStatusCode(); // Đảm bảo phản hồi HTTP thành công
        //        return RedirectToAction("hienthiVoucher");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Ghi log ngoại lệ hoặc xử lý nó theo cách phù hợp
        //        ModelState.AddModelError("", "Lỗi khi xóa voucher: " + ex.Message);
        //        return View("Error"); // Tạo một view lỗi để hiển thị thông báo lỗi
        //    }
        //}



        //  KHÔNG ĐƯỢC XÓA
        [Area("Admin")]
        public ActionResult xoaVoucher(int id)
        {
            string url = $"https://localhost:44396/api/Voucher/Delete?id={id}";
            HttpResponseMessage httpResponseMessage = client.DeleteAsync(url).Result;
            return RedirectToAction("hienthiVoucher");
        }

    }
}
