using JheyPassword.Business.Responses;
using Microsoft.AspNetCore.Components;

namespace JheyPassword.Components.Pages.Password.ListPassword;

public partial class ListPassword : ComponentBase
{
    public List<CreatedPasswordResponse> Elements = new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Teste",
            Password = "Teste",
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Teste",
            Password = "Teste",
        }
    };
}