namespace JheyPassword.Business.Responses;

public class CreatedPasswordResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string Title { get; set; }
    public string UserOrEmail { get; set; }
    public string Password { get; set; }
}