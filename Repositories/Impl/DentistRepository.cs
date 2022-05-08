namespace Dental_Clinic.Repositories.Impl
{
    public class DentistRepository : IDentistRepository
    {
        private readonly dentalclinicContext _context;

        public DentistRepository(dentalclinicContext context)
        {
            _context = context;
        }
        public void Add(Dentist dentist)
        {
            _context.Dentists.Add(dentist);
            _context.SaveChanges();
        }

        public Dentist Get(ulong id)
        {
            var dentist = _context.Dentists.Where(d => d.Id == id).FirstOrDefault();
            return dentist;
        }

        public List<Dentist> GetAll()
        {
            List<Dentist>  dentists = _context.Dentists.ToList();
            return dentists;
        }

        public void Delete(ulong id)
        {
            var dentist = Get(id);
            if (dentist == null)
            {
                return;
            }

            _context.Dentists.Remove(dentist);
            _context.SaveChanges();
        }
    }
}
