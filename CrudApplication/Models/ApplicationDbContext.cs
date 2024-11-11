using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

         }

        public DbSet<Student> Students { get; set; }
    }
}