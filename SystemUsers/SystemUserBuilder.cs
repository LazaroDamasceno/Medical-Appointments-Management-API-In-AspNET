namespace MedicalAppointmentsManagementAPI.SystemUsers;

public record SystemUserBuilder : ISystemUserBuilder
{

    private readonly string _firstName;
    private readonly string _middleName;
    private readonly string _lastName;
    private readonly DateOnly _birthDay;
    private readonly string _ssn;
    private readonly string _email;
    private readonly string _phoneNumber;
    private readonly string _gender;

    private SystemUserBuilder (RegisterSystemUserDTO dto)
    {
        _firstName = dto.FirstName;
        _middleName = dto.MiddleName;
        _lastName = dto.LastName;
        _birthDay = dto.Birthday;
        _ssn = dto.Ssn;
        _email = dto.Email;
        _phoneNumber = dto.PhoneNumber;
        _gender = dto.Gender;
    }

    public SystemUserBuilder Create(RegisterSystemUserDTO dto)
    {
        return new(dto);
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
