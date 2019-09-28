using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Client.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [MaxLength(256)]
        public string Url { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        public bool IsPage { get; set; }

        [ForeignKey("Catalog")]
        public Guid? CatalogId { get; set; }
    }
}