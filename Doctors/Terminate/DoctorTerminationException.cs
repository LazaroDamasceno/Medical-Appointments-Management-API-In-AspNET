namespace MedicalAppointmentsManagementAPI.Doctors.Terminate;

public class DoctorTerminationException(string licenseNumber) 
    : Exception($"Doctor who license number is {licenseNumber} is already terminated.")
{
}
