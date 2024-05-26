using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public record UpdateSystemUserDTO(
    [Required]
    [StringLength(9)]
    string Ssn,

    [Required]
    string Name,

    [Required]
    DateOnly Birthday,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    [StringLength(10)]
    string PhoneNumber,

    [Required]
    [StringLength(1)]
    string Gender
)
{
}
