using Azure;
using EmploeeManagement.Models;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var response = await httpClient.PostAsJsonAsync("api/employees", newEmployee);

            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var response = await httpClient.PutAsJsonAsync("api/employees", updatedEmployee);

            return await response.Content.ReadFromJsonAsync<Employee>();
        }
    }
}
