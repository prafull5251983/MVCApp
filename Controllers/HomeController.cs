using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCApp.Data;
using MVCApp.Models;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MVCApp.Controllers
{
    public class Item1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class Item2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MvcAppContext _mvcAppContext;

        public HomeController(ILogger<HomeController> logger, MvcAppContext mvcAppContext)
        {
            _logger = logger;
            _mvcAppContext = mvcAppContext;
        }

        public IActionResult Index()
        {
            var joins = _mvcAppContext.blogs.Join(_mvcAppContext.posts,
                blog => blog.Id,
                post => post.Blog.Id,
                                (blog, post) => new
                                {
                                    blog.Id,
                                    blog.Name,
                                    PID = post.Id
                                }).Join(_mvcAppContext.PostPrice,
                                pst => pst.Id,
                                ppr => ppr.Post.Id,
                                (pst, ppr) => new
                                {
                                    price = ppr.Price
                                }

                                );


            // test 22

            var grpby = _mvcAppContext.blogs.Join(_mvcAppContext.posts,
                 blog => new { blog.Id, blog.Name },
                 post => new { Id=post.Blog.Id, Name= post.PostName },
                 (blog, post) => new { blog.Id })
                .Join(_mvcAppContext.PostPrice,
                                pst => pst.Id,
                                ppr => ppr.Post.Id,
                                (pst, ppr) => new
                                {
                                    price = ppr.Price
                                }

                                );




            var list1 = new List<Item1>
        {
            new Item1 { Id = 1, Name = "Item1A", Category = "A" },
            new Item1 { Id = 2, Name = "Item1B", Category = "B" }
        };

            var list2 = new List<Item2>
        {
            new Item2 { Id = 1, Name = "Item2A", Category = "A" },
            new Item2 { Id = 2, Name = "Item2B", Category = "B" },
            new Item2 { Id = 3, Name = "Item2C", Category = "A" }
        };

            var result = list1.Join(
                list2,
                item1 => new { item1.Id, item1.Category },
                item2 => new { item2.Id, item2.Category },
                (item1, item2) => new { item1.Name,  item1.Category }
            );


            //var result = _mvcAppContext.blogs.Join(
            //_mvcAppContext.posts,
            //blog => new { blog.Id, blog.Name },
            //post => new { post?.Blog.Id, post?.Blog?.Name },
            //     (a, b) => new { a, b })
            // .Where(x => x.a. == x.b.Condition1 && x.a.Condition2 == x.b.Condition2)
            // .Select(x => new { x.a.Property1, x.b.Property2 });







            //    var query = context.Students
            //.Join(context.Enrollments,
            //      student => student.StudentId,
            //      enrollment => enrollment.StudentId,
            //      (student, enrollment) => new { student, enrollment })
            //.Join(context.Courses,
            //      combined => combined.enrollment.CourseId,
            //      course => course.CourseId,
            //      (combined, course) => new
            //      {
            //          StudentName = combined.student.Name,
            //          CourseName = course.Name,
            //          EnrollmentDate = combined.enrollment.EnrollmentDate
            //      });



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult getid(int iid)
        {
            return Content("id is " + iid);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}