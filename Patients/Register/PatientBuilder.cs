using MedicalAppointmentsManagementAPI.Patients.Register;
using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Patients;

public class PatientBuilder : IPatientBuilder
{

    private string _address;
    private SystemUser _systemUser;

    public PatientBuilder Create(string address, SystemUser systemUser)
    {
        _address = address;
        _systemUser = systemUser;
        return this;
    }

    public Patient Build()
    {
        return new Patient()
        {
            Address = _address,
            SystemUser = _systemUser
        };
    }

}
