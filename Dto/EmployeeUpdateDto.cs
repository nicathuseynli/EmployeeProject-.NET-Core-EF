namespace Employee_HW_EF.Dto;
public class EmployeeUpdateDto
{
    public string Position { get; set; } = string.Empty;
    public int Salary { get; set; }
    public bool IsManager { get; set; }
}
