using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;

public interface IUpdatePatientService
{
    void Update([Required] UpdatePatientDTO dto);
}
