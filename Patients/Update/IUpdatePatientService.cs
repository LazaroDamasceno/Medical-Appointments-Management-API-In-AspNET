using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;

public interface IUpdatePatientService
{
    void Update([Required, StringLength(9)] string ssn, [Required] UpdatePatientDTO dto);
}
