using EmploeeManagement.Models;
using EmployeeManagement.Api.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeService { get; set; }

        public bool ShowFooter { get; set; } = true;
        public int SelectedEmployeeCount { get; set; } = 0;

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await employeeService.GetEmployees()).ToList();
        }

        public void handleEmployeeSelection(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeeCount++;
            }
            else
            {
                SelectedEmployeeCount--;
            }
        }

        public async Task handleDeleteEmployee(int id)
        {
            await employeeService.DeleteEmployee(id);
            Employees = (await employeeService.GetEmployees()).ToList();
        }
    }
}
