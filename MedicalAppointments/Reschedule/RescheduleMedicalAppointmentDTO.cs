using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Reschedule;

public record RescheduleMedicalAppointmentDTO
(
    [Required, StringLength(7)] string DoctorLicenseNumber,
    [Required] DateTime OldScheduledDateTime,
    [Required] DateTime NewScheduledDateTime
) {
}
