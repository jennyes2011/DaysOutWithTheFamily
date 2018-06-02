using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaysOutWithTheFamily.Models.DataAccess
{
    public interface iPostRepository
    {
        void Create(BlogPostModel blogPost);
        void Delete(int id);
        void Update(int id, BlogPostModel blogPost);
        List<BlogPostModel> Read();
    }
}
