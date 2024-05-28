namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;

public class FirstDateBeforeLastDateTimeException(DateTime firstDateTime, DateTime lastDateTime)
    : Exception($"First date time {firstDateTime} must equal or after {lastDateTime}")
{ }