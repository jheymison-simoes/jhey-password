namespace JheyPassword.Business.Responses;

public class GetAllPasswordResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string UserOrEmail { get; set; }
    public string Password { get; set; }
    public string PasswordHash => new('*', Password.Length);
    public bool ShowPassword { get; set; }
}