
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public record HireDoctorDTO(
    [Required, StringLength(7)] string DoctorLicenseNumber,
    [Required] RegisterSystemUserDTO SystemUserDTO
)
{ }
