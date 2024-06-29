namespace MedicalAppointmentsManagementAPI.SystemUsers;

public interface ISystemUserBuilder
{
    SystemUserBuilder Create(RegisterSystemUserDTO dto);
    SystemUser Build();
}
