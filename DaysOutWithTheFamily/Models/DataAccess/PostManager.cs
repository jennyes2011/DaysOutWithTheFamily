using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DaysOutWithTheFamily.Models.DataAccess
{
    public class PostManager
    {
        private static List<BlogPostModel> posts = new List<BlogPostModel>();

        public static void Create(BlogPostModel blogPost, string postFile)
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

        public static void Delete(int id, string postFile)
        {
            posts.Remove(posts.Find(x => x.ID == id));
            save(postFile);
        }

        public static void Update(int id, BlogPostModel newPost, string postFile)
        {
            Delete(id, postFile);
            Create(newPost, postFile);
            save(postFile);
        }

        public static List<BlogPostModel> Read(string postFile)
        {
            if (!File.Exists(postFile))
            {
                File.Create(postFile).Close();
                File.WriteAllText(postFile, "[]");

            }

            posts = JsonConvert.DeserializeObject<List<BlogPostModel>>(File.ReadAllText(postFile));
            return posts; 
        }

        private static void save(string postFile)
        {
            File.WriteAllText(postFile, JsonConvert.SerializeObject(posts));
        }
    }
}
