using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUser;

public record UpdateSystemUserDTO(
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
) { }
