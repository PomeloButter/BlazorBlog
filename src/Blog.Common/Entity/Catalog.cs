using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Common.Entity
{
    public class Catalog
    {
        public Guid Id { get; set; }

        [MaxLength(32)]
        public string Url { get; set; }

        public string Title { get; set; }

        public int Pri { get; set; }
     
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}