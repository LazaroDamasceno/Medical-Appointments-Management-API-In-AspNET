using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public class DoctorBuilder : IDoctorBuilder
{

    private string _licenseNumber;
    private SystemUser _systemUser;

    private DoctorBuilder(string licenseNumber, SystemUser systemUser)
    {
        _licenseNumber = licenseNumber;
        _systemUser = systemUser;
    }

    public DoctorBuilder Create(string licenseNumber, SystemUser systemUser)
    {
        return new(licenseNumber, systemUser);
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
