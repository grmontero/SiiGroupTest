using SiiTestModel;

namespace SiiTestBLL.Interfaces
{
    public interface IEmployeesBll
    {
        Task<ServiceResponse<List<Employees>>> getEmployees();
        Task<ServiceResponse<List<Employees>>> getEmployeesById(string idEmployee);
        List<Employees> calculateAnualSalary(List<Employees> employees);
    }
}