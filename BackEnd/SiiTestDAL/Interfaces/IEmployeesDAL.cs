using SiiTestModel;
namespace SiiTestDAL.Interfaces
{
    public interface IEmployeesDAL
    {
        Task<ServiceResponse<List<Employees>>> getEmployees();
        Task<ServiceResponse<List<Employees>>> getEmployeesById(string idEmployee);
    }
}