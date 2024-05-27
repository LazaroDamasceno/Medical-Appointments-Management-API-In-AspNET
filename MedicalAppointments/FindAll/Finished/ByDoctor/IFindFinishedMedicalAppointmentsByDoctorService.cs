using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByDoctor;

public interface IFindFinishedMedicalAppointmentsByDoctorService
{
    List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber, [Required] BetweenDateTimesDTO dateTimesDTO);
}
