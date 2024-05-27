namespace MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;

public class DoctorNotFoundException(string doctorLicenseNumber)
    : Exception($"Doctor who license number is {doctorLicenseNumber} was not found.")
{
}
