namespace Dental_Clinic.Models
{
    public class DentistDetails
    {
        public DentistDetails() { }
        public DentistDetails(Dentist dentist)
        {
            this.Id = dentist.Id;
            this.FirstName = dentist.FirstName;
            this.LastName = dentist.LastName;
            this.Description = dentist.Description;
        }


        public ulong Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
