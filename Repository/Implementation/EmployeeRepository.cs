using AutoMapper;
using Employee_HW_EF.Context;
using Employee_HW_EF.Data.Entity;
using Employee_HW_EF.Dto;
using Employee_HW_EF.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Employee_HW_EF.Repository.Implementation;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeRepository(EmployeeDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto)
    {
        await _context.Employees.AddAsync(_mapper.Map<Employee>(employeeDto));
        await _context.SaveChangesAsync();
        return employeeDto;
    }

    public async Task<bool> DeleteAsync(int Id)
    {
        var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
        _context.Employees.Remove(result);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int Id)
    {
        var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
        return result;
    }

    public async Task<Employee> UpdateAsync(int Id, EmployeeUpdateDto employeeUpdateDto)
    {
        var emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
        if (emp == null)
            return null;

        var result = _mapper.Map<EmployeeUpdateDto, Employee>(employeeUpdateDto,emp);
              _context.Employees.Update(result);
        await _context.SaveChangesAsync();
        return result;


    }
}
