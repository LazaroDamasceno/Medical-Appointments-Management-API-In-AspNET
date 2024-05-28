namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.ValidateDateTimes;

public class ValidateDateTimesService : IValidateDateTimesService
{

    public void ValidateDateTimes(BetweenDateTimesDTO dto)
    {
        if (dto.FirstDateTime <  DateTime.MinValue)
        {
            throw new FirstDateBeforeLastDateTimeException(dto.FirstDateTime, dto.LastDateTime);
        }
    }

}
