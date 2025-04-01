using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers;


public class ssncls
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
}

public class mvcstateController : Controller
{

    public IActionResult Index()
    {
        ViewBag.Names = "Prafull";
        ViewData["name"] = "Vipul";
        TempData["name"] = "Howal";
        TempData["namepeek"] = "Home";

        HttpContext.Session.SetString("ssnname", "Name from Session");
        HttpContext.Session.SetInt32("ssnno", 100);

        var ss = new ssncls
        {
            Name = "clasName",
            Description = "clsdescription",
            Age = 100
        };

        //HttpContext.Session.Set("ssnobject", ss);
        return View();
    }

    public IActionResult Index2()
    {

        //TempData.Keep("name");
        return View();
    }
}
