using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public class SystemUser
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
    public Patient? Patient { get; set; }

    [JsonIgnore]
    public Doctor? Doctor { get; set; }

    public static SystemUser CreateInstance(RegisterSystemUserDTO dto)
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

}
