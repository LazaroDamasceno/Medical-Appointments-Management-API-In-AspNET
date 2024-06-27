using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Patients;

public class PatientBuilder
{

    private readonly string _address;
    private readonly SystemUser _systemUser;

    public PatientBuilder(string address, SystemUser systemUser)
    {
        _address = address;
        _systemUser = systemUser;
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
