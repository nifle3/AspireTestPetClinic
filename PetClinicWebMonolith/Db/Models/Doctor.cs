namespace PetClinicWebMonolith.Db.Models;

public class Doctor
{
    public int Id { set; get; }

    public string? FirstName { set; get; }

    public string? LastName { set; get; }

    public string? Specialization { set; get; }

    public int Age { set; get; }

    public int AgeOfWork { set; get; }

    public string? PhotoUrl { set; get; }

    public List<Service>? Services { set; get; }

    public List<Reception>? Receptions { set; get; }
}
