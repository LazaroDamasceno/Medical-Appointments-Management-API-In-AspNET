namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.ValidateDateTimes;

public interface IValidateDateTimesService
{
    void ValidateDateTimes(BetweenDateTimesDTO dto);
}
