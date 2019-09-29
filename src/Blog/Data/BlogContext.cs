using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> opt)
            : base(opt)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Catalog>(e =>
            {
                e.HasIndex(x => x.Id);
            });

            builder.Entity<Post>(e =>
            {
                e.HasIndex(x => x.Title);
                e.HasIndex(x => x.Id);
             
            });
            builder.Entity<Tag>(e =>
            {
                e.HasIndex(x => x.Id);
            });
            builder.Entity<PostTag>(e =>
            {
                e.HasIndex(x => x.Id);
            });
        }
    }
}