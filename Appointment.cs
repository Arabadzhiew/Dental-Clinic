using System;
using System.Collections.Generic;

namespace Dental_Clinic
{
    public partial class Appointment
    {
        public ulong Id { get; set; }
        public ulong PatientId { get; set; }
        public ulong DentistId { get; set; }
        public DateTime ScheduledFor { get; set; }
        public string? Description { get; set; }

        public virtual Dentist Dentist { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
