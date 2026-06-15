using Microsoft.EntityFrameworkCore;

namespace WebApiSample.Models.DatabaseContext
{
    public class MDataBaseContext:DbContext
    {
        public MDataBaseContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }

    }
}
