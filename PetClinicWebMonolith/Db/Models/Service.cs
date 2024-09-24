namespace PetClinicWebMonolith.Db.Models;

public class Service
{
    public int Id { set; get; }

    public string? Name { set; get; }

    public string? Description { set; get; }

    public decimal Price { set; get; }

    public List<Doctor>? Doctors { set; get; }

    public List<Reception>? Receptions { set; get; }
}
