using Microsoft.EntityFrameworkCore;

namespace Poc.WebApi
{
    public class Db : DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        public Db(DbContextOptions options) : base(options) {}
    }
}