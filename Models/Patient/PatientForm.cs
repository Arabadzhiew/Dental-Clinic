namespace Dental_Clinic.Models
{
    public class PatientForm
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte Age { get; set; }
        public DateOnly BirthDate { get; set; }
        public ulong DentistId { get; set; }
    }
}
