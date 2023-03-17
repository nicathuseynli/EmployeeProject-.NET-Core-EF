using AutoMapper;
using Employee_HW_EF.Data.Entity;
using Employee_HW_EF.Dto;

namespace Employee_HW_EF.Mapper;
public class EmployeeMapping : Profile
{
    public EmployeeMapping()
    {    
        //get
        CreateMap<Employee, EmployeeDto>();
        //create
        CreateMap<Employee, EmployeeDto>().ReverseMap();

        CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
    }
}
