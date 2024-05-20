using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patient.Update;

public interface IUpdatePatientService
{
    void Update([Required, StringLength(9)] string ssn, [Required] UpdatePatientDTO dto);
}
