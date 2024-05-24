using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Transfer;

public record TransferMedicalAppointmentDTO(
    [Required, StringLength(7)] string DoctorLicenseNumber,
    [Required] DateTime OldScheduledDateTime,
    [Required] DateTime NewScheduledDateTime
) {
}
