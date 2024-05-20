using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patient.Register;

public interface ISelfRegisterPatientService
{
    void SelfRegister([Required] SelfRegisterPatientDTO dto);
}
