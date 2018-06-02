using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DaysOutWithTheFamily.Models.DataAccess
{

    public class PostJsnRepository : iPostRepository
    {
        private static List<BlogPostModel> posts = new List<BlogPostModel>();
        private string postFile;

        public PostJsnRepository(string postFile)
        {
            this.postFile = postFile;
        }

        public void Create(BlogPostModel blogPost)
        {
            //Get the post ID
            if (posts.Count > 0)
            {
                //ORder the posts by the created date desc
                posts = (from post in posts
                         orderby post.Created
                         select post).ToList();
                //Get the new ID (most recent one plus 1)
                blogPost.ID = posts.Last().ID + 1;
            }
            {
                blogPost.ID = 1;
            }

            blogPost.Created = System.DateTime.Now;

            posts.Add(blogPost);
            save(postFile);
        }

        public void Delete(int id)
        {
            posts.Remove(posts.Find(x => x.ID == id));
            save(postFile);
        }

        public void Update(int id, BlogPostModel blogPost)
        {
            Delete(id);
            Create(blogPost);
            save(postFile);
        }

        public List<BlogPostModel> Read()
        {
            if (!File.Exists(postFile))
            {
                File.Create(postFile).Close();
                File.WriteAllText(postFile, "[]");

            }

            posts = JsonConvert.DeserializeObject<List<BlogPostModel>>(File.ReadAllText(postFile));
            return posts;
        }

        private void save(string postFile)
        {
            File.WriteAllText(postFile, JsonConvert.SerializeObject(posts));
        }

    }
}
