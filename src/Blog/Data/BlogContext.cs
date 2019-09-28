using Blog.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Client.Data
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Catalog>(e => { e.HasIndex(x => x.Pri); });

            builder.Entity<Post>(e =>
            {
                e.HasIndex(x => x.Title);
                e.HasIndex(x => x.IsPage);
                e.HasIndex(x => x.Time);
                e.HasIndex(x => x.Url).IsUnique();
            });

            builder.Entity<PostTag>(e => { e.HasIndex(x => x.Tag); });
        }
    }
}