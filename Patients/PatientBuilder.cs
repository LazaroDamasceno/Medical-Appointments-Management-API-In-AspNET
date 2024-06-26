using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Patients;

public class PatientBuilder
{

    private string _address;
    private SystemUser _systemUser;

    public PatientBuilder Address(string address)
    {
        _address = address;
        return this;
    }

    public PatientBuilder SystemUser(SystemUser systemUser)
    {
        _systemUser = systemUser;
        return this;
    }

    public Patient Builder()
    {
        return new Patient()
        {
            Address = _address,
            SystemUser = _systemUser
        };
    }

}
