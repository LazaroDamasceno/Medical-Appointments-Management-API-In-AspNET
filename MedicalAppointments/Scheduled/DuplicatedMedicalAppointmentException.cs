namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;

public class DuplicatedMedicalAppointmentException(string ssn, string licenseNumber, DateTime dateTime)
    : Exception($"Medical appointment whose patient's ssn is {ssn}, doctor's license number is {licenseNumber} and scheduled date time is {dateTime} already exist.")
{
}
