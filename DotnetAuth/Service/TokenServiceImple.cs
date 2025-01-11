using DotnetAuth.Domain.Entities;

namespace DotnetAuth.Service;

public class TokenServiceImple : ITokenService
{
    public Task<string> GenerateToken(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }
}






//STEP 10