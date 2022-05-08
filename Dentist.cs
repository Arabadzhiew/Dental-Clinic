using System;
using System.Collections.Generic;

namespace Dental_Clinic
{
    public partial class Dentist
    {
        public Dentist()
        {
            Appointments = new HashSet<Appointment>();
            Patients = new HashSet<Patient>();
        }

        public ulong Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
