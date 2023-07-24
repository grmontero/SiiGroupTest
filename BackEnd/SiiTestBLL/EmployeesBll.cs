using SiiTestBLL.Interfaces;
using SiiTestDAL.Interfaces;
using SiiTestModel;
namespace SiiTestBLL
{
    public class EmployeesBll : IEmployeesBll
    {
        private readonly IEmployeesDAL employeesDal;

        public EmployeesBll(IEmployeesDAL employeesDal)
        {
            this.employeesDal = employeesDal;
        }
        public async Task<ServiceResponse<List<Employees>>> getEmployees()
        {
            ServiceResponse<List<Employees>> response = new ServiceResponse<List<Employees>> ();
            response = await this.employeesDal.getEmployees();
            if (response.data != null)
                response.data = calculateAnualSalary(response.data);
            return response;
        }
        public async Task<ServiceResponse<List<Employees>>> getEmployeesById(string idEmployee)
        {
            ServiceResponse<List<Employees>> response = new ServiceResponse<List<Employees>>();
            response = await this.employeesDal.getEmployeesById(idEmployee);
            if(response.data != null)
            response.data = calculateAnualSalary(response.data );
            return response;
        }
        public List<Employees> calculateAnualSalary(List<Employees> employees)
        {
            employees.ToList().ForEach(c => c.Employee_anual_salary = c.employee_salary * 12);
            return employees;
        }
    }
}