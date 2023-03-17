using Employee_HW_EF.Mapper;
using Employee_HW_EF.Repository.Implementation;
using Employee_HW_EF.Repository.Interface;

namespace Employee_HW_EF;
public static class DependencyInjection
{
    public static IServiceCollection addRepositoryLayer(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddAutoMapper(typeof(EmployeeMapping));
        return services;
    }
}
