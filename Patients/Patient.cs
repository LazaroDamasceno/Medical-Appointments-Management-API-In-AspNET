using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentsManagementAPI.Patients;

public class Patient
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Address { get; set; } = "";

    public SystemUser? SystemUser { get; set; }

    [ForeignKey("SystemUser")]
    public Guid? SystemUserId { get; set; }

    public static Patient CreateInstance(string address, SystemUser systemUser)
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
