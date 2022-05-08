namespace Dental_Clinic.Models
{
    public class AppointmentDetails
    {
        public AppointmentDetails(Appointment appointment)
        {
            this.Id = appointment.Id;
            this.Dentist = appointment.Dentist;
            this.Patient = appointment.Patient;
            this.ScheduledFor = appointment.ScheduledFor;
            this.Description = appointment.Description;
        }

        public ulong Id { get; set; }
        public virtual Dentist Dentist { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public DateTime ScheduledFor { get; set; }
        public string? Description { get; set; }
    }
}
