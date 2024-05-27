namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;

public class PastOrPastSchedulingDateTimeException(DateTime schedulingInTheDateTime, DateTime today)
    : Exception($"The date time {schedulingInTheDateTime} must after {today}.")
{
}
