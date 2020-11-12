using Microsoft.EntityFrameworkCore;
/*El contexto de base de datos es la clase principal que coordina 
la funcionalidad de Entity Framework para un modelo de datos*/
namespace Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {

        }

        public DbSet<ContactEntity> ContactItems { get; set; }
        public DbSet<NewsEntity> NewsItems { get; set; }
    
    }
}