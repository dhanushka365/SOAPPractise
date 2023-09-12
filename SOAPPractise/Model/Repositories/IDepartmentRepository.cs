namespace SOAPPractise.Model.Repositories
{
    public interface IDepartmentRepository
    {

        Task<List<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(Guid id);

        Task<Department> UpdateAsync(Department department);

        Task<Department> CreateAsync(Department department);

        Task<Department> DeleteAsync(Guid id);
    }
}
