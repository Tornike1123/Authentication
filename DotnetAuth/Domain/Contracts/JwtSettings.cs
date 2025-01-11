namespace DotnetAuth.Domain.Contracts;

public class JwtSettings //ეს კლასი შეიცავს JWT(JSON Web Token)-ის კონფიგურაციის პარამეტრებს, რომლებიც საჭიროა ავტორიზაციისა და უსაფრთხოების დასამყარებლად.
{
    public string? Key { get; set; }
    
    public string ValidIssuer { get; set; } //ტოკენი გენერირებულია მაგ:"https://yourdomain.com"
    
    public string ValidAudience { get; set; } // რომ ტოკენი სწორადაა მიმართული შესაბამისი აუდიტორიისკენ მაგ:"https://yourapi.com"

    public double Expires { get; set; } // Expires აღნიშნავს ტოკენის ვადის გასვლის ხანგრძლივობას, ჩვეულებრივ წამებში. 36000second = 1hour
}


//step 3