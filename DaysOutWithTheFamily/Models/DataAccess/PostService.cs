using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaysOutWithTheFamily.Models.DataAccess
{
    public class PostService
    {
        private iPostRepository repo;

        public PostService(string postFile)
        {
            //The post service uses the JSN repository
            repo = new PostJsnRepository(postFile);
        }

        public PostService(iPostRepository postRepo)
        {
            //The type of JSN repositoty is injected
            repo = postRepo;
        }

        public List<BlogPostModel> GetPostsForMainPage()
        {
            return (from blog in repo.Read()
                    orderby blog.Created descending
                    select blog).ToList();
        }

        public void CreatePost(BlogPostModel post)
        {
            repo.Create(post);
        }
    }
}
