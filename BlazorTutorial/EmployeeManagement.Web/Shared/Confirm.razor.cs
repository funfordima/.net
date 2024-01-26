using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Shared
{
    public partial class Confirm : ComponentBase
    {
        public bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confirmation";
        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete?";


        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
            Console.WriteLine(ShowConfirmation);
        }

        public async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}