namespace DotnetAuth.Domain.Contracts;

public class UserRegisterRequest //სერვერზე მომხმარებლის რეგისტრაციის API მოთხოვნის (request) დასამუშავებლად.
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
}


public class UserResponse//კლასი UserResponse წარმოადგენს მონაცემთა მოდელს, რომელიც შეიცავს ძირითად ველებს, რაც საჭიროა მომხმარებლის იდენტიფიკაციისა და ავტორიზაციისთვის.
{
    public Guid Id { get; set; }//Guid (გლობალურად უნიკალური იდენტიფიკატორი) წარმოადგენს უნიკალურ იდენტიფიკატორს.კონკრეტული მომხმარებლის ამოსაცნობად.
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public DateTime CreateAt { get; set; } //ინახავს მომხმარებლის შექმნის თარიღსა და დროს.
    public DateTime UpdateAt { get; set; } //მიუთითებს მომხმარებლის ბოლო განახლების თარიღსა და დროს.
    public string? AccessToken { get; set; }// ავტორიზაციისთვის და მოიცავს დროებით ტოკენს, რომელიც იძლევა მომხმარებლის სისტემაში წვდომის საშუალებას.
    public string? RefreshToken { get; set; }//ეს ტოკენი გამოიყენება AccessToken-ის განახლებისთვის, როდესაც ის იწურება.
}


public class UserLoginRequest //ავტორიზაციისთვის
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CurrentUserResponse //ძირითადად გამოიყენება, რათა სერვისმა ავტორიზებულ მომხმარებელს დაუბრუნოს მისი პირადი მონაცემები და წვდომის ტოკენი.
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string AccessToken { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}

public class UpdateUserRequest // წარმოადგენს მონაცემთა მოდელს, რომელიც გამოიყენება მომხმარებლის მონაცემების განახლების მოთხოვნისთვის. 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
}

public class RevokeRefreshTokenResponse //მოდელი, რომელიც გამოიყენება სერვერის მიერ დასაბრუნებელი შეტყობინების ფორმატისთვის.
{
    public string Message { get; set; } //დააბრუნებს პასუხს
}

public class RefreshTokenRequest //ახალი ტოკენის გენერაციისთვის.
{
    public string RefreshToken { get; set; }
}


//step 3