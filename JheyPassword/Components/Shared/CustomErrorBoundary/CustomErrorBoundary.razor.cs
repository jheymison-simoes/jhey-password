using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace JheyPassword.Components.Shared.CustomErrorBoundary;

public class CustomErrorBoundaryBase : ErrorBoundary
{
    [Inject] private ISnackbar Snackbar { get; set; } = default!;
    [Inject] private IDialogService DialogService { get; set; } = default!;
    [Inject] private ILogger<CustomErrorBoundaryBase> Logger { get; set; } = default!;
    
    protected override async Task OnErrorAsync(Exception exception)
    {
        await DialogService.ShowMessageBox(
            "Pedimos desculpa houve um erro inesperado!",
            exception.Message,
            yesText: "CONTINUAR!"
        );

        //try
        //{
        //    Logger.LogError(exception, "Houve um erro inesperado");

        //    //await DialogService.ShowMessageBox(
        //    //    "Pedimos desculpa houve um erro inesperado!",
        //    //    exception.Message,
        //    //    yesText: "CONTINUAR!"
        //    //);

        //    //Recover();

        //    throw new Exception(exception.Message);
        //}
        //catch
        //{
        //    Snackbar.Add("Ops! Houve um erro inesperado tente novamente em alguns minutos", Severity.Error);

        //    //await DialogService.ShowMessageBox(
        //    //    "Pedimos desculpa houve um erro inesperado!",
        //    //    exception.Message,
        //    //    yesText: "CONTINUAR!"
        //    //);
        //} finally
        //{
        //    Recover();
        //}
    }
}