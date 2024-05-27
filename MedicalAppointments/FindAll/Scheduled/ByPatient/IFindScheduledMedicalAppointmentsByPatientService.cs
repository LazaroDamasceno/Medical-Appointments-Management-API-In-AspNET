using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByPatient;

public interface IFindScheduledMedicalAppointmentsByPatientService
{
    List<MedicalAppointment> Find([Required, StringLength(9)] string ssn, [Required] BetweenDateTimesDTO dateTimesDTO);
}
