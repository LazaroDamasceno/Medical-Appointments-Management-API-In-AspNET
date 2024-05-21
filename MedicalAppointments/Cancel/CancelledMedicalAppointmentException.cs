namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;

public class CancelledMedicalAppointmentException
    : Exception
{
    public CancelledMedicalAppointmentException(string ssn, string doctorLicenseNumber, DateTime dateTime) 
        : base($"""
                    Medical appointment whose patient's ssn is {ssn}, doctor's license number is {doctorLicenseNumber} and scheduled date time is {dateTime} is already cancelled.
                """)
    { }

    public CancelledMedicalAppointmentException(string ssn, string doctorLicenseNumber, string dateTime)
    : base($"""
                Medical appointment whose patient's ssn is {ssn}, doctor's license number is {doctorLicenseNumber} and scheduled date time is {dateTime} is already finished.
            """)
    { }
}
