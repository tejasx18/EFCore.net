using Microsoft.EntityFrameworkCore;

namespace EFCore.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        
        }


        // LINQ  --> conversion DBset --> SQL  -> exec
        // Entity <Employee>
        public DbSet<Employee> Employees { get; set; }
    }
}
