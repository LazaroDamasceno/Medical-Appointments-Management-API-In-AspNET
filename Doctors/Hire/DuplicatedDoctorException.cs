namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public class DuplicatedDoctorException(string doctorLicenseNumber)
    : Exception($"Doctor whose license number is {doctorLicenseNumber} is already hired.")
{
}
