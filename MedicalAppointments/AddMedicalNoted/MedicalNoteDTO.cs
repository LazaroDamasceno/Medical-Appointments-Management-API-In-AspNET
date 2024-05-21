using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;

public record MedicalNoteDTO(
    [Required, StringLength(7)] string DoctorLicenseNumber, 
    [Required] DateTime ScheduledDateTime,
    [Required] string Note
) {
}
