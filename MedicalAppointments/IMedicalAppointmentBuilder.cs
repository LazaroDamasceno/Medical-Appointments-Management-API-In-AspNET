using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments;

public interface IMedicalAppointmentBuilder
{
    MedicalAppointmentBuilder Create(DateTime scheduledDateTime, Patient patient, Doctor doctor);
    MedicalAppointment Build();
}
