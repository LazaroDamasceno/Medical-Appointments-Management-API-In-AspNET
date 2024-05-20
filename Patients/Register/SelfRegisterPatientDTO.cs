using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Register;

public record SelfRegisterPatientDTO(
    [Required] string Address,
    [Required] RegisterSystemUserDTO SystemUserDTO
)
{ }
