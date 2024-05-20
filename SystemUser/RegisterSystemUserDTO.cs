using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUser;

public record RegisterSystemUserDTO(
    [Required]
    string Name,

    [Required]
    DateOnly Birthday,

    [Required]
    [StringLength(9)]
    string Ssn,

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
