using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patient.Update;

public record UpdatePatientDTO(
    [Required] string Address, 
    [Required] UpdateSystemUserDTO Dto
)
{ }
