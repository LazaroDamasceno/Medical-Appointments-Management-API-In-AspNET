using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Patients.Register;

public interface IPatientBuilder
{
    PatientBuilder Create(string address, SystemUser systemUser);
    Patient Build();
}
