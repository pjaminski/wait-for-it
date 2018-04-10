using Microsoft.AspNetCore.Mvc;

namespace WaitForIt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            //todo: handle error view
            return Index();
        }
    }
}
