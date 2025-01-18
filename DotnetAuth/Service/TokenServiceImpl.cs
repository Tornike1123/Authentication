using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DotnetAuth.Domain.Contracts;
using DotnetAuth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DotnetAuth.Service;

public class TokenServiceImpl : ITokenService
{
    private readonly SymmetricSecurityKey _secretKey; //გასაღები, რომელსაც იყენებს JWT ტოკენის ხელმოწერისთვის.
    private readonly string? _validAudience;//აუდიტორიის სახელწოდება (ვისთვის არის განკუთვნილი ტოკენი).
    private readonly string? _validIssuer;//გამომცემლის სახელი (ვინ გამოსცემს ტოკენს).
    private readonly double _expires;//ტოკენის ვადა (წუთებში).
    private readonly UserManager<ApplicationUser> _userManager;//მომხმარებლის მართვისთვის საჭირო სერვისი.
    private readonly ILogger<TokenServiceImpl> _logger;//ლოგის სისტემასთან ინტეგრაციისთვის.

    public TokenServiceImpl(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
    //IConfiguration configuration: კონფიგურაციისთვის (მაგ., appsettings.json).
    // UserManager<ApplicationUser> userManager: მომხმარებლის მართვისთვის.
        _userManager = userManager; 
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>(); //JWT-ის პარამეტრების (JwtSettings) ამოღება კონფიგურაციიდან.
        if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Key))
        {
            throw new InvalidOperationException("JWTSettings not found in configuration");
        }
        _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));//ინიციალიზაცია ხდება საიდუმლო გასაღებით.
        _validAudience = configuration["Jwt:ValidAudience"]; //ინიციალიზაცია ხდება კონფიგურაციიდან.
        _validIssuer = configuration["Jwt:ValidIssuer"];//ინიციალიზაცია ხდება კონფიგურაციიდან.
        _expires = Convert.ToDouble(configuration["Jwt:Expires"]);//ინიციალიზაცია ხდება კონფიგურაციიდან,ტოკენის ვადის განსაზღვრა.

    }
    
    public async Task<string> GenerateToken(ApplicationUser user)//იღებს ApplicationUser ობიექტს.
    {
        var signingCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256); //ეს ქმნის ტოკენის ხელმოწერისთვის საჭირო კრიპტოგრაფიულ საკრედენციოებს. იყენებს HMAC SHA-256 ალგორითმს.
        var claims = await GetClaimsAsync(user);// მომხმარებლისთვის არსებული Claim-ები. Claim წარმოადგენს მომხმარებლის ატრიბუტს (მაგ., სახელი, ელ.ფოსტა, როლი).
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);//ტოკენის პარამეტრები გენერირდება ცალკე მეთოდით.
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);//გენერირებული ტოკენი გადაიქცევა სტრინგ ფორმატში გამოსაყენებლად.
    }

    private async Task<List<Claim>> GetClaimsAsync(ApplicationUser user)//ეს მეთოდი ქმნის Claim-ების სიას.
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),// მომხმარებლის უნიკალური იდენტიფიკატორი.
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("FirstName", user.FirstName),
            new Claim("LastName", user.LastName),
            new Claim("Gender", user.Gender),
        };
        var roles = await _userManager.GetRolesAsync(user);//აბრუნებს კონკრეტული მომხმარებლის როლების სიას.(მაგ:"admin","user"და ა.შ-როლები)
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));//თითოეული როლისთვის (მაგ., "Admin", "User") გენერირდება ახალი Claim, რომლის ტიპი იქნება ClaimTypes.Role, ხოლო მნიშვნელობა როლის სახელი.
        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    //ეს მეთოდი ქმნის JwtSecurityToken ობიექტს, რომელიც წარმოადგენს JWT ტოკენის ძირითად კონსტრუქციას.
    {
        return new JwtSecurityToken(
            issuer: _validIssuer,
            audience: _validAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_expires),
            signingCredentials: signingCredentials
        );
        //ამ მეთოდის შედეგად ვიღებთ JwtSecurityToken ობიექტს, რომელიც ტოკენის ყველა მახასიათებელს შეიცავს.
        //ეს ობიექტი შეიძლება სტრინგად გარდაიქმნას და გადაეცეს მომხმარებელს.
    }
    
    
    public string GenerateRefreshToken()//ეს მეთოდი ქმნის Refresh Token-ს, რომელიც გამოიყენება მომხმარებლის
                                        //სესიის განახლებისთვის, როდესაც ძირითადი JWT ტოკენს ვადა გაუვა.
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        
        var refreshToken = Convert.ToBase64String(randomNumber);
        return refreshToken;
    }
}


//STEP 10