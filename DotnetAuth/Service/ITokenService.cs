using DotnetAuth.Domain.Entities;

namespace DotnetAuth.Service;

public interface ITokenService
{
    Task<string> GenerateToken(ApplicationUser user); //ასინქრონულად აბრუნებს JWT ტოკენს, მომხმარებლის ავტორიზაციისთვის.
    
    string GenerateRefreshToken(); //ეს მეთოდი აგენერირებს Refresh Token-ს
}


//Refresh Token გამოიყენება ახალი JWT ტოკენის გენერაციისთვის, რათა მომხმარებელს არ მოუწიოს ხელახლა ავტორიზაცია.


//STEP 9