namespace PetClinicWebMonolith.Db.Models;

public class Pet
{
    public int Id { set; get; }

    public int ClientId { set; get; }

    public string? PhotoUrl { set; get; }

    public string? Sex { set; get; }

    public string? Name { set; get; }

    public string? Type { set; get; }

    public DateOnly? BirthDay { set; get; }

    public string? Breed { set; get; }

    public int Passport { set; get; }

    public DateTime? Created { set; get; }

    public Client? Client { set; get; }

    public List<Reception>? Receptions { set; get; }
}
