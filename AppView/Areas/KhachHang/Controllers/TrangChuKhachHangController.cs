using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Areas.KhachHang.Controllers
{
    public class TrangChuKhachHangController : Controller
    {
        private readonly HttpClient client;
        CoolMate_1Context _context;

        public TrangChuKhachHangController()
        {
            client = new HttpClient();  
            _context = new CoolMate_1Context();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrangChuKhachHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrangChuKhachHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrangChuKhachHangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrangChuKhachHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrangChuKhachHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrangChuKhachHangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrangChuKhachHangController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
