using EmploeeManagement.Models;
using EmployeeManagement.Api.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public partial class EmployeeDetails : ComponentBase
    {
        public Employee employee { get; set; } = new Employee();
        public string Coordinates { get; set; }
        public string ButtonText { get; set; } = "Hide Footer";
        public string CssClass { get; set; } = null;

        [Inject]
        public IEmployeeService employeeService { get; set; }

        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            employee = await employeeService.GetEmployee(int.Parse(id));
        }

        public void handleButtonClick()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "hidden";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }
    }
}