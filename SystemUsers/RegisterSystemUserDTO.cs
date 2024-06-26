using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public record RegisterSystemUserDTO(
    [Required]
    string FirstName,

    string MiddleName,

    [Required]
    string LastName,

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
