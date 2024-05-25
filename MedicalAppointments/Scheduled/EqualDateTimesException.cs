namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;

public class EqualDateTimesException(DateTime scheduledDateTime) 
    : Exception($"Medical appointment which date time is {scheduledDateTime} is already scheduled.")
{
}
