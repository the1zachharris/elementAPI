using Microsoft.EntityFrameworkCore;

namespace elementAPI.models
{
    public class elementContext : DbContext
    {
        public elementContext(DbContextOptions<elementContext> options)
            : base(options) { }

        public DbSet<Element> Elements { get; set; }
    }
}
