namespace Dental_Clinic.Repositories.Impl
{
    public class PatientRepository : IPatientRepository
    {
        private readonly dentalclinicContext _context;

        public PatientRepository(dentalclinicContext context)
        {
            _context = context;
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public Patient Get(ulong id)
        {
            var patient = _context.Patients.Where(p => p.Id == id).FirstOrDefault();

            return patient;
        }

        public List<Patient> GetAll()
        {
            List<Patient> patients = _context.Patients.ToList();
            return patients;
        }

        public void Delete(ulong id)
        {
            var patient = Get(id);
            if(patient == null)
            {
                return;
            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }

    }
}
