namespace Dental_Clinic.Repositories
{
    public interface IDentistRepository
    {
        void Add(Dentist dentist);
        Dentist Get(ulong id);
        List<Dentist> GetAll();
        void Delete(ulong id);
    }
}
