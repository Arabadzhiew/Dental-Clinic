using System;
using System.Collections.Generic;

namespace Dental_Clinic
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public ulong Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte Age { get; set; }
        public DateOnly BirthDate { get; set; }
        public ulong DentistId { get; set; }

        public virtual Dentist Dentist { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
