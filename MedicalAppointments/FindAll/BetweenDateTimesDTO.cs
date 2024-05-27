using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;

public record BetweenDateTimesDTO(
    [Required] DateTime FirstDateTime,
    [Required] DateTime LastDateTime
) {
}
