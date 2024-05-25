namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Find;

public interface IFindMedicalAppointmentService
{
    MedicalAppointment Find(string ssn, string doctorLicenseNumber, DateTime scheduledDateTime);
    MedicalAppointment FindByDoctor(string doctorLicenseNumber, DateTime scheduledDateTime);
    MedicalAppointment FindByPatient(string doctorLicenseNumber, DateTime scheduledDateTime);
}
