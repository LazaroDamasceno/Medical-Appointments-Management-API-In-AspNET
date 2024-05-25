using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;

public record CancelMedicalAppointmentDTO(
    [Required, StringLength(9)] string Ssn, 
    [Required] DateTime ScheduledDateTime
) { 
}
