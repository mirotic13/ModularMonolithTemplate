using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace ModularMonolithTemplate.BlazorUI.Components.Layout;

public class MainLayoutBase : LayoutComponentBase
{
    [Inject] protected NavigationManager Navigation { get; set; } = default!;
    [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

    protected bool IsLoggedIn { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateTask;
        IsLoggedIn = authState.User.Identity?.IsAuthenticated ?? false;
    }

    protected void Login() => Navigation.NavigateTo("/login", forceLoad: true);
    protected void Logout() => Navigation.NavigateTo("/logout", forceLoad: true);
}
