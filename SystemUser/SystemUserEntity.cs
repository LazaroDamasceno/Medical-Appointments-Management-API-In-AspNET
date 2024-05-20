using MedicalAppointmentsManagementAPI.Patient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAppointmentsManagementAPI.SystemUser;

public class SystemUserEntity
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "";

    public DateOnly Birthday;

    public string Ssn { get; set; } = "";

    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Gender { get; set; } = "";

    [JsonIgnore]
    public PatientEntity? Patient { get; set; }

    [JsonIgnore]
    public DoctorEntity? Doctor { get; set; }

    public static SystemUserEntity CreateInstance(RegisterSystemUserDTO dto)
    {
        return new()
        {
            Name = dto.Name,
            Birthday = dto.Birthday,
            Ssn = dto.Ssn,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Gender = dto.Gender,
        };
    }

    public void Update(UpdateSystemUserDTO dto)
    {
        Name = dto.Name;
        Birthday = dto.Birthday;
        Email = dto.Email;
        PhoneNumber = dto.PhoneNumber;
        Gender = dto.Gender;
    }

}
