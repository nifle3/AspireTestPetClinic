namespace PetClinicWebMonolith.Db.Models;

public class Client
{
    public int Id { set; get; }

    public string? FirstName { set; get; }

    public string? LastName { set; get; }

    public string? PhoneNumber { set; get; }

    public string? Email { set; get; }

    public string? Password { set; get; }

    public DateOnly CreatedAt { set; get; }

    public List<Pet>? Pets { set; get; }
}
