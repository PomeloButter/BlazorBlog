using System.Collections.Generic;

namespace Blog.Models
{
    public class PostViewModel
    {
        public int Year { get; set; }

        public IList<PostModel> Posts { get; set; }
    }

    public class PostModel
    {
        public  string Id { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }

        public int Year { get; set; }
        public string CreationTime { get; set; }
    }
}