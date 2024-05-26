using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;

public record UpdatePatientDTO
(
    [Required] string Address,
    [Required] UpdateSystemUserDTO SystemUser
) {
}
