using MedicalAppointmentsManagementAPI.Patients.Register;
using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Patients;

public class PatientBuilder : IPatientBuilder
{

    private readonly string _address;
    private readonly SystemUser _systemUser;

    private PatientBuilder(string address, SystemUser systemUser)
    {
        _address = address;
        _systemUser = systemUser;
    }

    public PatientBuilder Create(string address, SystemUser systemUser)
    {
        return new(address, systemUser);
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
