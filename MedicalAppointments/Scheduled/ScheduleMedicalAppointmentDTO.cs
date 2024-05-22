using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;

public record ScheduleMedicalAppointmentDTO(
    [Required, StringLength(9)] string Ssn,
    [Required, StringLength(7)] string DoctorLicenseNumber,
    [Required] DateTime ScheduledDateTime
) {
}
