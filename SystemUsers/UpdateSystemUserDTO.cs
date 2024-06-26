using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public record UpdateSystemUserDTO(
    [Required]
    string FirstName,

    string MiddleName,

    [Required]
    string LastName,

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
