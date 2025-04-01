using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class ViewDataBagTempDataController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Prafull";
            ViewData["name"] = "Vipul";
            TempData["name"] = "Howal";
            //TempData.Keep("name");
            return View();
        }
       
    }
}
