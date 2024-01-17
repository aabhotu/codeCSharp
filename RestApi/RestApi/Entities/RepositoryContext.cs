using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base (options) 
        { }
        public DbSet<User> users { set; get; }
    }
}
