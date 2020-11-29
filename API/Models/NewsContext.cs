using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
/*El contexto de base de datos es la clase principal que coordina 
la funcionalidad de Entity Framework para un modelo de datos*/
namespace Models
{
    public class NewsContext : IdentityDbContext<ApplicationUser>
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {

        }

        public DbSet<ContactEntity> ContactItems { get; set; }
        public DbSet<NewsEntity> NewsItems { get; set; }

        public DbSet<NewsList> NewsLists { get; set; }

    
    }
}