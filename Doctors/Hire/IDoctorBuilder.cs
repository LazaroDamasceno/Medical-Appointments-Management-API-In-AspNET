using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public interface IDoctorBuilder
{
    DoctorBuilder Create(string licenseNumber, SystemUser systemUser);
    Doctor Build();
}
