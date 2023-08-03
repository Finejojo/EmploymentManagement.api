using EmploymentManagement.api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmploymentManagement.api.sub_folders.Context_folder
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<FoodClass> FoodClasses { get; set; }
        //public DbSet<Food> Foods { get; set; }
    }
}
