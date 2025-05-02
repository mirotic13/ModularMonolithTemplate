using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.Data;
using ModularMonolithTemplate.BlazorUI.Services;

namespace ModularMonolithTemplate.BlazorUI.Components.Pages;

public class LoginBase : ComponentBase
{
    [Inject] protected NavigationManager Navigation { get; set; } = default!;
    [Inject] protected IAuthService AuthService { get; set; } = default!;


    protected Validations validations;
    protected string Email { get; set; } = string.Empty;
    protected string Password { get; set; } = string.Empty;
    protected string ErrorMessage { get; set; } = string.Empty;

    protected async Task HandleLogin()
    {
        ErrorMessage = string.Empty;

        if (!await validations.ValidateAll())
            return;

        var response = await AuthService.LoginAsync(new LoginRequest
        {
            Email = Email,
            Password = Password
        });

        if (response.Success)
        {
            Navigation.NavigateTo("/");
        }
        else
        {
            ErrorMessage = "Credenciales inválidas.";
        }
    }
}
