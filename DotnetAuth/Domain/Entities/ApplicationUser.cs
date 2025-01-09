using Microsoft.AspNetCore.Identity;

namespace DotnetAuth.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string Gender { get; set; }

    public string? RefreshToken { get; set; } //Refresh Token-ის შესანახი ველი.
    
    public DateTime? RefreshTokenExpiry { get; set; } //Refresh Token-ის ვადის გასვლის თარიღი.

    public DateTime CreateAt { get; set; } //მომხმარებლის შექმნის დროის შესანახი ველი.
    
    public DateTime UpdateAt { get; set; } //მომხმარებლის ბოლო განახლების დროის შესანახი ველი.
}

// public class ApplicationUser : IdentityUser
// ApplicationUser არის კლასი, რომელიც მემკვიდრეობს IdentityUser-ს.
// IdentityUser წარმოადგენს ASP.NET Core Identity-ის მიერ დეფინირებულ კლასს, რომელიც შეიცავს საბაზისო მონაცემებს მომხმარებლის შესახებ