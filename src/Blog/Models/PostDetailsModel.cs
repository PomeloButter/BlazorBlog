using System.Collections.Generic;

namespace Blog.Models
{
    public class PostDetailsModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Html { get; set; }
        public string Markdown { get; set; }
        public string CreationTime { get; set; }
        public CatalogViewModel Category { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public PosPagedModel Previous { get; set; }
        public PosPagedModel Next { get; set; }
    }
    public class PosPagedModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}