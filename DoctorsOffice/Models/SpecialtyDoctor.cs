namespace DoctorsOffice.Models
{
  public class SpecialtyDoctor
  {       
    public int SpecialtyDoctorId { get; set; }
    public int DoctorId { get; set; }
    public int SpecialtyId { get; set;}
    public virtual Doctor Doctor { get; set; }
    public virtual Specialty Specialty { get; set;}
  }
}