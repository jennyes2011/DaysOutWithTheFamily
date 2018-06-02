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
        private PostService postService;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            string postFile = Path.Combine(hostingEnvironment.ContentRootPath, "posts.jsn");
            postService = new PostService(postFile);
        }

        public IActionResult Index()
        {
            var blogPosts = postService.GetPostsForMainPage();
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
            postService.CreatePost(blogPostModel);
            return View("index", postService.GetPostsForMainPage());
        }
    }
}
