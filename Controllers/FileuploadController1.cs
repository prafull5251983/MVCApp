using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MVCApp.Controllers
{
    public class FileuploadController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public IActionResult FileUpload()
        {
            var file = Request.Form.Files[0];
            if (file == null)
            {
                string foldername = Path.Combine("files");
                string pathtosave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                if (file.Length > 0)
                {
                    var filename = file.FileName;
                    var fullpath = Path.Combine(pathtosave, filename);
                    //foreach (var stream = new FileStream(fullpath, FileMode.Create))
                    //{
                    //    file.CopyTo(stream);
                    //}
                }
            }

            return View();
        }

    }
}
