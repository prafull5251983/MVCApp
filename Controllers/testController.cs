using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            MyViewModel vw = new MyViewModel();

            IEnumerable<Items> ilst = new List<Items>();
            List<Items> lstitms = new List<Items>();
            Items itm1 = new Items();
            itm1.Id = 1;
            itm1.Name = "Prafull";
            Items itm2 = new Items();
            itm2.Name = "Vipul";
            itm2.Id = 2;
            lstitms.Add(itm1);
            lstitms.Add(itm2);
            ilst = lstitms;

            vw.SelectedItemId = itm1.Id;
            vw.Items = ilst;
            vw.sitms = GetItems();
            return View(vw);

    }

    private IEnumerable<SelectListItem> GetItems()
    {
        return new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Item 1" },
            new SelectListItem { Value = "2", Text = "Item 2" },
            new SelectListItem { Value = "3", Text = "Item 3" }
        };
    }
}
}
