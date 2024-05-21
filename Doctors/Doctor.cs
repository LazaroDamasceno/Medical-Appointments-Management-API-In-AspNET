using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentsManagementAPI.Doctors;

public class Doctor
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string LicenseNumber { get; set; } = "";

    public DateTime HiringDateTime { get; set; } = DateTime.Now;

    public DateTime? TerminationDateTime { get; set; }

    public SystemUser? SystemUser { get; set; }

    [ForeignKey("SystemUser")]
    public Guid? SystemUserId { get; set; }

    public static Doctor CreateInstance(string LicenseNumber, SystemUser systemUser)
    {
        return new()
        {
            LicenseNumber = LicenseNumber,
            SystemUser = systemUser
        };
    }

    public void Terminate()
    {
        TerminationDateTime = DateTime.Now;
    }

}
