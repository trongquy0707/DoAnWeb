using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Areas.Admin.Controllers
{
  
    public class HomeController : Controller
    {
        public HomeController() {
        }

        [Area("Admin")]
        public ActionResult TrangChu()
        {
            return View("TrangChu");
        }

    }
}
