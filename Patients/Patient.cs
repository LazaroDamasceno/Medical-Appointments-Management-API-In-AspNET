using MedicalAppointmentsManagementAPI.MedicalAppointments;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAppointmentsManagementAPI.Patients;

public class Patient
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Address { get; set; }

    public SystemUser? SystemUser { get; set; }

    [ForeignKey("SystemUser")]
    public Guid SystemUserId { get; set; }

    [JsonIgnore]
    public List<MedicalAppointment> MedicalAppointments { get; set; } = [];

    public void Update(string address) => Address = address;

}
