using JheyPassword.Business.Interfaces.Services;
using JheyPassword.Business.Responses;
using JheyPassword.Components.Pages.Password.Models;
using Microsoft.AspNetCore.Components;

namespace JheyPassword.Components.Pages.Password.CreatePassword;

public class CreatePasswordBase : ComponentBase
{
    [Inject] protected ICreatePasswordService CreatePasswordService { get; set; } = default!;
    
    protected CreatePasswordForm CreatePasswordForm { get; set; } = new ();

    protected async Task OnSubmitAsync()
    {
        var response = await CreatePasswordService.CreateAsync(new()
        {
            Title = CreatePasswordForm.Title,
            Password = CreatePasswordForm.Password
        });
        
        // if (response is BaseResponse<CreatedPasswordResponse> baseResponse)
        // {
        //     var teste = baseResponse.Error;
        // }

    }
}