using Microsoft.EntityFrameworkCore;
using REST_Practise.Data;
using System;

namespace SOAPPractise.Model.Repositories
{
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        private readonly ERPContext dbContext;

        public SQLDepartmentRepository(ERPContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await dbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(Guid id)
        {
            return await dbContext.Departments.FindAsync(id);
        }

        public async Task<Department> CreateAsync(Department department)
        {
            dbContext.Departments.Add(department);
            await dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            dbContext.Entry(department).State = EntityState.Modified; // Mark the department as modified
            await dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteAsync(Guid id)
        {
            var department = await dbContext.Departments.FindAsync(id); // Find the department by ID

            if (department != null)
            {
                dbContext.Departments.Remove(department); // Mark the department for deletion
                await dbContext.SaveChangesAsync(); // Delete the department from the database
            }

            return department; // Return the deleted department or null if not found
        }
    }
}
