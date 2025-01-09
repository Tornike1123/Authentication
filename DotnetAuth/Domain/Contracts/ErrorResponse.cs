namespace DotnetAuth.Domain.Contracts;

public class ErrorResponse //API-ს შეცდომების მართვა: როდესაც API აბრუნებს შეცდომას
{
    public string Title { get; set; } //შეცდომის ტიპი (Title)
    
    public string Message { get; set; } //შესაბამისი შეტყობინება (Message)

    public int StatusCode { get; set; } //HTTP სტატუს კოდი (StatusCode)
}