using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments;

public class MedicalAppointment
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public required DateTime ScheduledDateTime { get; set; }

    public DateTime? CancelledDateTime { get; set; }

    public DateTime? FinishingDateTime { get; set; }

    public string? MedicalNote { get; set; }

    public Patient? Patient { get; set; }

    public Guid? PatientId { get; set; }

    public Doctor? Doctor { get; set; }

    public Guid? DoctorId { get; set; }

    public void Cancel() => CancelledDateTime = DateTime.Now;

    public void AddMedicalNote(string note) => MedicalNote = note;

    public void Finish() => FinishingDateTime = DateTime.Now;

}
