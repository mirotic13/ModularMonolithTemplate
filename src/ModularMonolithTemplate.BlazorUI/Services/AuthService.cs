using Microsoft.AspNetCore.Identity.Data;
using ModularMonolithTemplate.BuildingBlocks.Application.Responses;
using ModularMonolithTemplate.BuildingBlocks.Contracts.Auth.Responses;

namespace ModularMonolithTemplate.BlazorUI.Services
{
    public interface IAuthService
    {
        Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request);
    }

    public class AuthService(HttpClient http) : IAuthService
    {
        private readonly HttpClient _http = http;

        public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);

            var result = await response.Content.ReadFromJsonAsync<BaseResponse<LoginResponse>>();
            return result!;
        }
    }
}
