using DotnetAuth.Domain.Contracts;

namespace DotnetAuth.Service;

public interface IUserServices
{
    Task<UserResponse> RegisterAsync(UserRegisterRequest request);//(UserRequestAndRespons-დან)
    Task<CurrentUserResponse> GetCurrentUserAsync();//(UserRequestAndRespons-დან)
    Task<UserResponse> GetByIdAsync(Guid id);//(UserRequestAndRespons-დან)
    Task<UserResponse> UpdateAsync(Guid id, UpdateUserRequest request);//(UserRequestAndRespons-დან)
    Task DeleteAsync(Guid id); //მომხმარებლის წაშლა სისტემიდან
    Task<RevokeRefreshTokenResponse> RevokeRefreshToken(RefreshTokenRequest refreshTokenRemoveRequest);//(UserRequestAndRespons-დან)
    Task<CurrentUserResponse> RefreshTokenAsync(RefreshTokenRequest request);//(UserRequestAndRespons-დან)
    Task<UserResponse> LoginAsync(UserLoginRequest request);//(UserRequestAndRespons-დან)
}

//IUserService წარმოადგენს მომხმარებლის მართვის სისტემის მთავარ ინტერფეისს(იღებს UserRequestAndRespons-დან)
// რეგისტრაცია
// ავტორიზაცია და ტოკენების მართვა
// მომხმარებლის დეტალების მიღება და განახლება
// წაშლა და ტოკენების გაუქმება


//Step 11