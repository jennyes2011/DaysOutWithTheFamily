using DaysOutWithTheFamily.Models;
using DaysOutWithTheFamily.Models.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DaysOutWithTheFamily.Controllers
{
    public class HomeController : Controller
    {
        private string postFile;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            postFile = Path.Combine(hostingEnvironment.ContentRootPath, "posts.jsn");
        }

        public IActionResult Index()
        {
            var blogPosts = PostManager.Read(postFile);

            blogPosts = (from blog in blogPosts
                         orderby blog.Created descending
                         select blog).ToList();

            return View(blogPosts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Post(BlogPostModel blogPost)
        {
            return View(blogPost);
        }

        public IActionResult Maps()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPostModel blogPostModel)
        {
            PostManager.Create(blogPostModel, postFile);
            return View("index", PostManager.Read(postFile));
        }
    }
}
