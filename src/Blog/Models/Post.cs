using System;

namespace Blog.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Html { get; set; }
        public string Markdown { get; set; }
        public string CategoryId { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}