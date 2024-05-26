using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;

public record UpdateDoctorDTO(
    [Required, StringLength(7)] string DoctorLicenseNumber, 
    [Required] UpdateSystemUserDTO SystemUserDTO
) {
}
