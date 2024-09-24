namespace PetClinicWebMonolith.Db.Models;

public class Reception
{
    public int Id { get; set; }

    public int PetId { set; get; }

    public int DoctorId { set; get; }

    public int ServiceId { set; get; }

    public DateTime StartedAt { set; get; }

    public Pet? Pet { set; get; }

    public Doctor? Doctor { set; get; }

    public Service? Service { set; get; }
}
