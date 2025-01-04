namespace JheyPassword.Business.ViewModels;

public record CreatePasswordViewModel
{
    public string Title { get; set; }
    public string UserOrEmail { get; set; }
    public string Password { get; set; }
}