using JheyPassword.Business.ViewModels;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JheyPassword.Components.Shared.NavBar;

public class NavBarBase : BaseComponent
{
    protected string CurrentRoute = string.Empty;

    protected List<NavBarItem> Items = new()
    {
        new(Icons.Material.Filled.Download, "Import/Export", "/import-export"),
        new(Icons.Material.Filled.Key, "Minhas Chaves", "password/list"),
        new(Icons.Material.Filled.GeneratingTokens, "Gerar Senha", "password/generate"),
    };

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    protected void RedirectTo(string redirectTo)
    {
        NavigationManager.NavigateTo(redirectTo);
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        CurrentRoute = e.Location;
        Items.ForEach(x => x.Active = CurrentRoute.Contains(x.RedirecTo));
        StateHasChanged();
    }

    // Limpeza do evento para evitar vazamento de memória
    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }
}



