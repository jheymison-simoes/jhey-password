using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace JheyPassword.Components.Shared.CustomErrorBoundary;

public class CustomErrorBoundaryBase : ErrorBoundary
{
    [Inject] private ISnackbar Snackbar { get; set; } = default!;
    [Inject] private IDialogService DialogService { get; set; } = default!;
    
    protected override async Task OnErrorAsync(Exception exception)
    {
        var result = await DialogService.ShowMessageBox(
            "Warning", 
            exception.Message, 
            yesText:"OK!"
        );
        StateHasChanged();
    }
}