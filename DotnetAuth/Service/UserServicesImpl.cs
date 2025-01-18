using DotnetAuth.Domain.Contracts;

namespace DotnetAuth.Service;

public class UserServicesImpl : IUserServices
{
    public Task<UserResponse> RegisterAsync(UserRegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CurrentUserResponse> GetCurrentUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> UpdateAsync(Guid id, UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<RevokeRefreshTokenResponse> RevokeRefreshToken(RefreshTokenRequest refreshTokenRemoveRequest)
    {
        throw new NotImplementedException();
    }

    public Task<CurrentUserResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> LoginAsync(UserLoginRequest request)
    {
        throw new NotImplementedException();
    }
}