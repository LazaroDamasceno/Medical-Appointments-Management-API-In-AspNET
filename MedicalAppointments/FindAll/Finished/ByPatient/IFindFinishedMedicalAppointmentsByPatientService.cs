using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByPatient;

public interface IFindFinishedMedicalAppointmentsByPatientService
{
    List<MedicalAppointment> Find([Required, StringLength(9)] string ssn, [Required] BetweenDateTimesDTO dateTimesDTO);
}
