using MedicalAppointmentsManagementAPI.Patient.Register;
using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentsManagementAPI.Patient;

public class PatientEntity
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Address { get; set; } = "";

    public SystemUserEntity? SystemUser { get; set; }

    [ForeignKey("SystemUser")]
    public Guid? SystemUserId { get; set; }

    public static PatientEntity CreateInstance(string address, SystemUserEntity systemUser)
    {
        return new()
        {
            Address = address,
            SystemUser = systemUser
        };
    }

    public void UpdateAddress(string address)
    {
        Address = address;
    }

}
