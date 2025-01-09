using Microsoft.AspNetCore.Components;
using Plugin.Maui.Biometric;

namespace JheyPassword.Components.Pages.Home;

public class HomeBase : BaseComponent
{
    [Inject] private IBiometric Biometric { get; set; } = default!;
    
    protected bool IsAndroid => DeviceInfo.Platform == DevicePlatform.Android;
    protected bool IsAuthenticate;
    
    protected override async Task OnInitializedAsync()
    {
        await AuthAsync();
    }
    
    protected async Task AuthAsync()
    {
        if (!IsAndroid || !Biometric.IsPlatformSupported)
        {
            NavigationManager.NavigateTo("/password/list");
            return;
        }
        
        var result = await Biometric.AuthenticateAsync(new AuthenticationRequest()
        {
            Title = "É necessário autenticar para continuar",
            NegativeText = "Cancel",
        }, CancellationToken.None);
        
        if (result.Status == BiometricResponseStatus.Success)
        {
            IsAuthenticate = true;
            NavigationManager.NavigateTo("/password/list");
        }
        else
        {
            IsAuthenticate = false;
        }
    }
}