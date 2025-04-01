using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class attroutingController : Controller
{

    static List<Student> lststudents = new List<Student>()
        {
            new Student() { Id = 1, Name = "Pranaya" },
            new Student() { Id = 2, Name = "Priyanka" },
            new Student() { Id = 3, Name = "Anurag" },
            new Student() { Id = 4, Name = "Sambit" }
        };


    public IActionResult Index()
    {
        return View();
    }

    //[HttpGet]
    public ActionResult students()
    {
        return View(lststudents);
    }


    //[HttpGet]
    public ActionResult students(string? str)
    {
        return View(lststudents);
    }


    [HttpGet]
    public ActionResult courses(int studentID)
    {
        List<string> CourseList = new List<string>();
        if (studentID == 1)
            CourseList = new List<string>() { "ASP.NET", "C#.NET", "SQL Server" };
        else if (studentID == 2)
            CourseList = new List<string>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
        else if (studentID == 3)
            CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
        else
            CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        ViewBag.CourseList = CourseList;
        return View();
    }


    [HttpGet]
    public ActionResult courses(int studentID, string std)
    {
        List<string> CourseList = new List<string>();
        if (studentID == 1)
            CourseList = new List<string>() { "ASP.NET", "C#.NET", "SQL Server" };
        else if (studentID == 2)
            CourseList = new List<string>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
        else if (studentID == 3)
            CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
        else
            CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        ViewBag.CourseList = CourseList;
        return View();
    }

    //[Route("MVCTest/{studentName?}")]
    //[Route("MVCTest")]
    //public ActionResult MVC(string studentName)
    //{
    [Route("MVCTest/{studentName?}")]
    //[HttpGet("MVCTest")]
    public ActionResult MVC(string studentName)
    {
        ViewBag.Message = "Welcome to ASP.NET MVC!";
        return View();
    }


}
