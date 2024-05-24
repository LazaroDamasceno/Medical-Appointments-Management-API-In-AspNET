namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Find;

public interface IFindMedicalAppointmentService
{
    MedicalAppointment Find(string ssn, string doctorLicenseNumber, DateTime scheduledDateTime);
    MedicalAppointment Find(string doctorLicenseNumber, DateTime scheduledDateTime);
}
