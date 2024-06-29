namespace MedicalAppointmentsManagementAPI.SystemUsers;

public record SystemUserBuilder : ISystemUserBuilder
{

    private string _firstName;
    private string _middleName;
    private string _lastName;
    private DateOnly _birthDay;
    private string _ssn;
    private string _email;
    private string _phoneNumber;
    private string _gender;

    public SystemUserBuilder Create(RegisterSystemUserDTO dto)
    {
        _firstName = dto.FirstName;
        _middleName = dto.MiddleName;
        _lastName = dto.LastName;
        _birthDay = dto.Birthday;
        _ssn = dto.Ssn;
        _email = dto.Email;
        _phoneNumber = dto.PhoneNumber;
        _gender = dto.Gender;
        return this;
    }

    public SystemUser Build()
    {
        return new SystemUser()
        {
            FirstName = _firstName,
            MiddleName = _middleName,
            LastName = _lastName,
            Birthday = _birthDay,
            Ssn = _ssn,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Gender = _gender
        };
    }

}
