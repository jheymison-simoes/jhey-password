using JheyPassword.Business.Interfaces.Services;
using JheyPassword.Components.Pages.Password.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JheyPassword.Components.Pages.Password.CreatePassword;

public class CreatePasswordBase : BaseComponent
{
    [Inject] protected ICreatePasswordService CreatePasswordService { get; set; } = default!;

    protected CreatePasswordForm CreatePasswordForm { get; set; } = new ();

    protected async Task OnSubmitAsync()
    {
        await CreatePasswordService.CreateAsync(new()
        {
            Title = CreatePasswordForm.Title,
            Password = CreatePasswordForm.Password,
            UserOrEmail = CreatePasswordForm.UserOrEmail
        });

        SnackbarService.Add("Chave guardada com sucesso!", Severity.Success);

        CreatePasswordForm = new();
    }
}