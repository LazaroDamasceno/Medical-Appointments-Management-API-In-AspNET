using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctor.Hire;

public record HireDoctorDTO(
    [Required, StringLength(7)] string DoctorLicenseNumber,
    [Required] RegisterSystemUserDTO SystemUserDTO
)
{ }
