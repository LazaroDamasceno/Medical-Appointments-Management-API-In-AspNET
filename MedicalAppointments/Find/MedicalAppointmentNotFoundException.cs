namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Find;

public class MedicalAppointmentNotFoundException : Exception
{
    public MedicalAppointmentNotFoundException(string ssn, string doctorLicenseNumber, DateTime scheduledDateTime) : base(
        $"""
            Medical appointment whose patient's ssn is {ssn}, doctor's license number is {doctorLicenseNumber} and scheduled date is {scheduledDateTime} time was not found.
        """)
    { }

    public MedicalAppointmentNotFoundException(string doctorLicenseNumber, DateTime scheduledDateTime) : base(
        $"""
            Medical appointment whose doctor's license number is {doctorLicenseNumber} and scheduled date is {scheduledDateTime} time was not found.
        """)
    { }
}
