using Microsoft.AspNetCore.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Content("Admin");
        }

        public IActionResult Test()
        {
            return Content("form test function");
        }
    }
}
