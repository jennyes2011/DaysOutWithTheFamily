using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaysOutWithTheFamily.Models
{
    public class BlogPostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Created { get; set; }
    }
}
