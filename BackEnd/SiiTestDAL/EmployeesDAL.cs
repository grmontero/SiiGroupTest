using Newtonsoft.Json;
using SiiTestDAL.ApiHelper;
using SiiTestDAL.Interfaces;
using SiiTestModel;
namespace SiiTestDAL
{
    public class EmployeesDAL : IEmployeesDAL
    {
        private string UrlApi = "https://dummy.restapiexample.com/api/v1/employees";
        private string UrlApiById = "https://dummy.restapiexample.com/api/v1/employee";

        public EmployeesDAL()
        {
        }

        public async Task<ServiceResponse<List<Employees>>> getEmployees()
        {
            ServiceResponse<List<Employees>> response = new ServiceResponse<List<Employees>>();
            try
            {
                string json = await ConsumeApi.getJson(this.UrlApi);
                if (ConsumeApi.StatusCode == 200)
                    response = JsonConvert.DeserializeObject<ServiceResponse<List<Employees>>>(json) ?? new ServiceResponse<List<Employees>>() { status = "Fail" };
                else
                {
                    response.status = ConsumeApi.StatusCode.ToString();
                    response.message = ConsumeApi.ReasonPhrase.ToString();
                    return response;
                }
                return response;
            }catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = "Fail";
                return response;
            }
        }

        public async Task<ServiceResponse<List<Employees>>> getEmployeesById(string idEmployee)
        {
            ServiceResponse<List<Employees>> response = new ServiceResponse<List<Employees>>();
            ServiceResponse<Employees> res = new ServiceResponse<Employees>();

            try
            {
                string json = await ConsumeApi.getJson(this.UrlApiById + "/" + idEmployee);
                if(ConsumeApi.StatusCode == 200)
                    res = JsonConvert.DeserializeObject<ServiceResponse<Employees>>(json) ?? new ServiceResponse<Employees>() { status = "Fail" };
                else
                {
                    response.status = ConsumeApi.StatusCode.ToString();
                    response.message = ConsumeApi.ReasonPhrase.ToString();
                    return response;
                }
                if (res.data == null)
                {
                    response.status = "Fail";
                    response.message = "No Records found";
                    return response;
                }
                response.status = res.status;
                response.message= res.message;
                response.data = new List<Employees>() { res.data };
                return response;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = "Fail";
                return response;
            }
        }
    }
}