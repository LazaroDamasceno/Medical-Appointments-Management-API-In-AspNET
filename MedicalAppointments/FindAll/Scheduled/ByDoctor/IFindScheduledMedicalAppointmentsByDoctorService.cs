using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByDoctor;

public interface IFindScheduledMedicalAppointmentsByDoctorService
{
    List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber, [Required] BetweenDateTimesDTO dateTimesDTO);
}
