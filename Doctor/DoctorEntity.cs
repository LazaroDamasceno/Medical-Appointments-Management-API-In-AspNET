using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentsManagementAPI.Doctor;

public class DoctorEntity
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string LicenseNumber { get; set; } = "";

    public DateTime HiringDateTime { get; set; } = DateTime.Now;

    public DateTime? TerminationDateTime { get; set; }

    public string Address { get; set; } = ""; 

    public SystemUserEntity? SystemUser { get; set; }

    [ForeignKey("SystemUser")]
    public Guid? SystemUserId { get; set; }

    public DoctorEntity CreateInstance(string LicenseNumber, SystemUserEntity systemUser)
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
