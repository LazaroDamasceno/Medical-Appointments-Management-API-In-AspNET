using MedicalAppointmentsManagementAPI.MedicalAppointments;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAppointmentsManagementAPI.Doctors;

public class Doctor
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string LicenseNumber { get; set; }

    public DateTime HiringDateTime { get; set; } = DateTime.Now;

    public DateTime? TerminationDateTime { get; set; }

    public SystemUser? SystemUser { get; set; }

    [ForeignKey("SystemUser")]
    public Guid? SystemUserId { get; set; }

    [JsonIgnore]
    public List<MedicalAppointment> MedicalAppointments { get; set; } = [];

    public void Terminate() => TerminationDateTime = DateTime.Now;

}
