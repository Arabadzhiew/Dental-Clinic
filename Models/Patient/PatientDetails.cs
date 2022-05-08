
namespace Dental_Clinic.Models
{
    public class PatientDetails
    {

        public PatientDetails() { }
        public PatientDetails(Patient patient) {
           this.Id = patient.Id;
           this.FirstName = patient.FirstName;
           this.LastName = patient.LastName;
           this.Age = patient.Age;
           this.BirthDate = patient.BirthDate;
           this.Dentist = new DentistDetails(patient.Dentist);
        }

        public ulong Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte Age { get; set; }
        public DateOnly BirthDate { get; set; }
        public DentistDetails Dentist { get; set; }
    }
}
