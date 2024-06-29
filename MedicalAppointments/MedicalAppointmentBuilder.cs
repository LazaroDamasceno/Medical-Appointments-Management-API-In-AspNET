using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
using MedicalAppointmentsManagementAPI.Patients;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments;

public class MedicalAppointmentBuilder : IMedicalAppointmentBuilder
{

    private DateTime _scheduledDateTime;
    private Patient _patient;
    private Doctor _doctor;

    public MedicalAppointmentBuilder Create(DateTime scheduledDateTime, Patient patient, Doctor doctor)
    {
        _scheduledDateTime = scheduledDateTime;
        _patient = patient;
        _doctor = doctor;
        return this;
    }

    public MedicalAppointment Build()
    {
        return new MedicalAppointment()
        {
            ScheduledDateTime = _scheduledDateTime,
            Patient = _patient,
            Doctor = _doctor
        };
    }

}
