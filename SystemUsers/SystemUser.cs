using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public class SystemUser
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateOnly Birthday { get; set; }

    [Required]
    public string Ssn { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Gender { get; set; }

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
