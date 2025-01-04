using System.ComponentModel.DataAnnotations;

namespace JheyPassword.Components.Pages.Password.Models;

public class CreatePasswordForm
{
    [Required(ErrorMessage = "O titulo é obrigatório")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Password { get; set; }
}