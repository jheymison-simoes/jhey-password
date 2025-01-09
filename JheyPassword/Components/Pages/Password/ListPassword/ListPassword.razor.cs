using JheyPassword.Business.Helpers;
using JheyPassword.Business.Interfaces.Services;
using JheyPassword.Business.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JheyPassword.Components.Pages.Password.ListPassword;

public class ListPasswordBase : BaseComponent
{
    [Inject] private IGetAllPasswordsService GetAllPasswordsService { get; set; } = default!;
    [Inject] private IControlErrorService ControlErrorService { get; set; } = default!;
    [Inject] private IDeletePasswordService DeletePasswordService { get; set; } = default!;

    protected string Filter = string.Empty;
    private List<GetAllPasswordResponse> _passwords = [];
    protected List<GetAllPasswordResponse> PasswordsFiltered = [];

    protected override async Task OnInitializedAsync()
    {
        var ocurredException = ControlErrorService.Get(nameof(ListPasswordBase));
        if (ocurredException) return;
        
        try
        {
            _passwords = await GetAllPasswordsService.GetAllAsync();
            PasswordsFiltered = _passwords;
        }
        catch
        {
            ControlErrorService.Add(nameof(ListPasswordBase));
            throw;
        }
    }
    
    protected void CopyPassword(string password)
    {
        CopyHelper.CopyToClipboard(password);
        SnackbarService.Add("Senha copiada!", Severity.Info);
    }
    
    protected void OnFilterChanged(string value)
    {
        // Filter = value;
        PasswordsFiltered = !string.IsNullOrWhiteSpace(value) 
            ? PasswordsFiltered
                .Where(c => 
                    string.IsNullOrEmpty(Filter) || 
                    c.Title.Contains(Filter, StringComparison.OrdinalIgnoreCase) || 
                    c.Title.Contains(Filter, StringComparison.OrdinalIgnoreCase)
                ).ToList()
            : _passwords;
    }

    protected async Task DeleteAsync(Guid id)
    {
        var confirm = await DialogService.ShowMessageBox("Atenção", "Deseja realmente deletar essa senha?", yesText: "Sim", cancelText: "Não");
        if (!confirm.HasValue || !confirm.Value) return;

        await DeletePasswordService.DeleteAsync(id);

        _passwords = _passwords.Where(x => x.Id != id).ToList();
        PasswordsFiltered = _passwords;
        
        SnackbarService.Add("Chave deletada!", Severity.Success);
    }
    
    protected async Task EditAsync(Guid id)
    {
        await DialogService.ShowMessageBox("Desulpe", "Essa funcionalidade ainda não foi implementada.", yesText: "Ok");
    }

}