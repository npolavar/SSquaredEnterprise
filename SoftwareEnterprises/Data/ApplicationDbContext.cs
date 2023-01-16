#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SoftwareEnterprises.Models;

namespace SoftwareEnterprises.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<UserRoles> UserRole { get; set; }


       


    }
}
