using Microsoft.AspNetCore.Mvc;
using WaitForIt.Services;

namespace WaitForIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateCounterService _dateCounterService;

        public HomeController(IDateCounterService dateCounterService)
        {
            _dateCounterService = dateCounterService;
        }

        public IActionResult Index()
        {
            var model = _dateCounterService.GetCurrentMessage();
            return View(model);
        }

        public IActionResult Error()
        {
            //todo: handle error view
            return Index();
        }
    }
}
