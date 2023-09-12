using Microsoft.EntityFrameworkCore;
using SOAPPractise.Model;

namespace REST_Practise.Data
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions <ERPContext> options) : base(options)
        {

        }

        

        public DbSet<Department> Departments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            // Seed data for Regions
            var departments = new List<Department>
            {
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Engineering"
                   
                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Quality Assuarance"

                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Human Resource"

                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Support"

                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Managed Services"

                },
            };
            modelBuilder.Entity<Department>().HasData(departments);
        }
        }
}
