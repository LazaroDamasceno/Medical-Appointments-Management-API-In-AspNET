using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public class SystemUser
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public required string LastName { get; set; }

    public required DateOnly Birthday { get; set; }

    public required string Ssn { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Gender { get; set; }

    [JsonIgnore]
    public Patient? Patient { get; set; }

    [JsonIgnore]
    public Doctor? Doctor { get; set; }

    public string FullName()
    {
        if (MiddleName == null)
        {
            return $"{FirstName} ${LastName}";
        }
        return $"{FirstName} ${MiddleName} ${LastName}";
    }

    public void Update(UpdateSystemUserDTO dto)
    {
        FirstName = dto.FirstName;
        MiddleName = dto.MiddleName;
        LastName = dto.LastName;
        Birthday = dto.Birthday;
        Email = dto.Email;
        PhoneNumber = dto.PhoneNumber;
        Gender = dto.Gender;
    }

}
