using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Doctors;

public class DoctorBuilder
{

    private string _licenseNumber;
    private SystemUser _systemUser;

    public DoctorBuilder LicenseNumber(string licenseNumber)
    {
        _licenseNumber = licenseNumber;
        return this;
    }

    public DoctorBuilder SystemUser(SystemUser systemUser)
    {
        _systemUser = systemUser;
        return this;
    }

    public Doctor Build()
    {
        return new Doctor()
        {
            LicenseNumber = _licenseNumber,
            SystemUser = _systemUser
        };
    }

}
