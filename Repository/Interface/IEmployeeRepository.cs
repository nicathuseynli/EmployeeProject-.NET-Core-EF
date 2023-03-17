using Employee_HW_EF.Data.Entity;
using Employee_HW_EF.Dto;

namespace Employee_HW_EF.Repository.Interface;
public interface IEmployeeRepository
{
    public Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
    public Task<Employee> UpdateAsync(int Id,EmployeeUpdateDto employeeUpdateDto);
    public Task<List<Employee>> GetAllAsync();
    public Task<Employee> GetByIdAsync(int Id);
    public Task<bool> DeleteAsync(int Id);
}
