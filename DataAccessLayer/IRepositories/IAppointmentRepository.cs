// using DataAccessLayer.Entities;
//
// namespace DataAccessLayer.IRepositories;
//
// public interface IAppointmentRepository
// {
//     Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
//     Task<Appointment> GetByIdAsync(Guid id);
//     Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(Guid patientId);
//     Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(Guid doctorId);
//     Task<IEnumerable<Appointment>> GetAppointmentsByPlaceAsync(Guid placeId);
//     Task CreateAsync(Appointment appointment);
//     Task UpdateAsync(Appointment appointment);
//     Task DeleteAsync(Guid id);
// }