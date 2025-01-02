namespace MVC.Models.Entities;

public record class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}