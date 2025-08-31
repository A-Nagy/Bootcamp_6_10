using Bootcamp_6_10.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_6_10.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        { }

        public DbSet<Categoty> Categoties { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products  { get; set; }

    }
}
