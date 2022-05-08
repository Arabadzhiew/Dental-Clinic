namespace Dental_Clinic.Repositories
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
        Patient Get(ulong id);
        List<Patient> GetAll();
        void Delete(ulong id);
    }
}
