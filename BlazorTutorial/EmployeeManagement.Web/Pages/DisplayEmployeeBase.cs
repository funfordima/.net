using EmploeeManagement.Models;
using EmployeeManagement.Web.Shared;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> onEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> onDeleteEmployee { get; set; }
        public Confirm DeleteConfirmation { get; set; }

        public async Task handleCheckboxChange(ChangeEventArgs e)
        {
            await onEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        public void handleDelete()
        {
            Console.WriteLine("Delete");
            DeleteConfirmation.Show();
        }

        public async Task ConfirmDelete(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await onDeleteEmployee.InvokeAsync(Employee.EmployeeId);
            }
        }
    }
}
