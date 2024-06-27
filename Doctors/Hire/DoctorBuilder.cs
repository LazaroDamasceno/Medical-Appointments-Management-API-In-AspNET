using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public class DoctorBuilder
{

    private string _licenseNumber;
    private SystemUser _systemUser;

    public DoctorBuilder(string licenseNumber, SystemUser systemUser)
    {
        _licenseNumber = licenseNumber;
        _systemUser = systemUser;
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
