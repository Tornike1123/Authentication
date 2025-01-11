using System.Security.Claims;

namespace DotnetAuth.Service;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(){}
    
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string? GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier); //ClaimTypes.NameIdentifier: უნიკალური იდენტიფიკატორი (მომხმარებლის Id).
        return userId;
    }
}

// IHttpContextAccessor არის ASP.NET Core-ის სერვისი, რომელიც საშუალებას გაძლევთ მიიღოთ მიმდინარე HTTP მოთხოვნის კონტექსტი (HttpContext).

//მეთოდი იღებს HTTP კონტექსტში არსებული მომხმარებლის ინფორმაციას.
// მომხმარებლის იდენტიფიკაცია ხდება Claims საშუალებით:
// ClaimTypes.NameIdentifier ჩვეულებრივ გამოიყენება მომხმარებლის უნიკალური Id-ის შესანახად.
// FindFirstValue აბრუნებს კონკრეტული Claim-ის მნიშვნელობას.

// გამოყენების მაგალითი: თუ მომხმარებელი ავტორიზებულია, GetUserId() დააბრუნებს მომხმარებლის უნიკალურ Id-ს,
// რომელიც ჩვეულებრივ შეესაბამება მონაცემთა ბაზაში მომხმარებლის ჩანაწერის პირველადი კლავიშს.

//Step 8