using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Register;

public interface ISelfRegisterPatientService
{
    void SelfRegister([Required] SelfRegisterPatientDTO dto);
}
