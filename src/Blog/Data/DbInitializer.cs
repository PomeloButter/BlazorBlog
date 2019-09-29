using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Blog.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlogContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Posts.Any()) return; // DB has been seeded

            var posts = new[]
            {
                new Post(){Id = "1",Title = "精彩的文章标题1",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="1",CreationTime = DateTime.Parse("2017-09-02")},
                new Post(){Id = "2",Title = "精彩的文章标题2",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="2",CreationTime = DateTime.Parse("2017-09-02")},
                new Post(){Id = "3",Title = "精彩的文章标题3",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="2",CreationTime = DateTime.Parse("2017-09-02")},
                new Post(){Id = "4",Title = "精彩的文章标题4",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="3",CreationTime = DateTime.Parse("2018-09-02")},
                new Post(){Id = "5",Title = "精彩的文章标题5",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="3",CreationTime = DateTime.Parse("2018-09-02")},
                new Post(){Id = "6",Title = "精彩的文章标题6",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="4",CreationTime = DateTime.Parse("2016-09-02")},
                new Post(){Id = "7",Title = "精彩的文章标题7",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="4",CreationTime =DateTime.Parse("2016-09-02")},
                new Post(){Id = "8",Title = "精彩的文章标题8",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="4",CreationTime = DateTime.Parse("2019-09-02")},
                new Post(){Id = "9",Title = "精彩的文章标题9",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="3",CreationTime = DateTime.Parse("2019-09-02")},
                new Post(){Id = "10",Title = "精彩的文章标题10",Html = "文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容文章的内容",CategoryId="1",CreationTime = DateTime.Parse("2019-09-02")},
            };
            foreach (var s in posts) context.Posts.Add(s);

            context.SaveChanges();

            var tags = new[]
            {
                new Tag(){Id = "1",TagName = ".NET core",DisplayName = ".NET core"},
                new Tag(){Id = "2",TagName = "Go",DisplayName = "Go"},
                new Tag(){Id = "3",TagName = "Python",DisplayName = "Python"},
                new Tag(){Id = "4",TagName = "Java",DisplayName = "Java"},
                new Tag(){Id = "5",TagName = "Rust",DisplayName = "Rust"},
                
            };
            foreach (var c in tags) context.Tags.Add(c);

            context.SaveChanges();

            var catalogs = new[]
            {
                new Catalog(){Id = "1",CategoryName = "aaa",DisplayName = "aaa"},
                new Catalog(){Id = "2",CategoryName = "bbb",DisplayName = "bbb"},
                new Catalog(){Id = "3",CategoryName = "ccc",DisplayName = "ccc"},
                new Catalog(){Id = "4",CategoryName = "ddd",DisplayName = "ddd"},
                new Catalog(){Id = "5",CategoryName = "eee",DisplayName = "eee"},
            };
            foreach (var e in catalogs) context.Catalogs.Add(e);

            context.SaveChanges();

            var postTags = new[]
            {
                new PostTag(){Id = "1",PostId = "1",TagId = "1"},
                new PostTag(){Id = "2",PostId = "2",TagId = "2"},
                new PostTag(){Id = "3",PostId = "3",TagId = "2"},
                new PostTag(){Id = "4",PostId = "4",TagId = "3"},
                new PostTag(){Id = "5",PostId = "5",TagId = "4"},
                new PostTag(){Id = "6",PostId = "6",TagId = "4"},
                new PostTag(){Id = "7",PostId = "7",TagId = "5"},
                new PostTag(){Id = "8",PostId = "8",TagId = "5"},
                new PostTag(){Id = "9",PostId = "9",TagId = "4"},
                new PostTag(){Id = "10",PostId = "10",TagId = "5"},
              
            };
            foreach (var e in postTags) context.PostTags.Add(e);

            context.SaveChanges();
        }
    }
}