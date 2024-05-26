using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;

public record UpdatePatientDTO
(
    [Required, StringLength(9)] string Ssn,
    [Required] string Address,
    [Required] UpdateSystemUserDTO SystemUser
) {
}
