namespace Dental_Clinic.Models
{
    public class AppointmentForm
    {
        public ulong PatientId { get; set; }
        public ulong DentistId { get; set; }
        public DateTime ScheduledFor { get; set; }
        public string? Description { get; set; }
    }
}
