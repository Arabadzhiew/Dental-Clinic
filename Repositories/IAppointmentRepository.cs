namespace Dental_Clinic.Repositories
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        Appointment Get(ulong id);
        List<Appointment> GetAll();
        void Delete(ulong id);
    }
}
