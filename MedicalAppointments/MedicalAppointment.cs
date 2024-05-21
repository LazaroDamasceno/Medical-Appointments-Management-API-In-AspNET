using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments;

public class MedicalAppointment
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime ScheduledDateTime { get; set; }

    public DateTime? CancelledDateTime { get; set; }

    public DateTime? FinishingDateTime { get; set; }

    public string MedicalNotes { get; set; } = "";

    public Patient? Patient { get; set; }

    public Guid? PatientId { get; set; }

    public Doctor? Doctor { get; set; }

    public Guid? DoctorId { get; set; }

    public static MedicalAppointment CreateInstance(Patient patient, Doctor doctor, DateTime scheduledDateTime)
    {
        return new()
        {
            Patient = patient,
            Doctor = doctor,
            ScheduledDateTime = scheduledDateTime
        };
    }

}
