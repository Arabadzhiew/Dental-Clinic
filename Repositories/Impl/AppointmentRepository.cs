namespace Dental_Clinic.Repositories.Impl
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly dentalclinicContext _context;

        public AppointmentRepository(dentalclinicContext context)
        {
            _context = context;
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public Appointment Get(ulong id)
        {
            var appointment = _context.Appointments.Where(a => a.Id == id).FirstOrDefault();
            return appointment;
        }

        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = _context.Appointments.ToList();
            return appointments;
        }

        public void Delete(ulong id)
        {
            var appointment = Get(id);
            if(appointment == null)
            {
                return;
            }

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

    }
}
