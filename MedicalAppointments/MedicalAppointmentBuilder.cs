using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments;

public class MedicalAppointmentBuilder
{

    private DateTime _scheduledDateTime;
    private Patient _patient;
    private Doctor _doctor;

    public MedicalAppointmentBuilder ScheduledDateTime(DateTime scheduledDateTime)
    {
        _scheduledDateTime = scheduledDateTime;
        return this;
    }

    public MedicalAppointmentBuilder Patient(Patient patient)
    {
        _patient = patient;
        return this;
    }

    public MedicalAppointmentBuilder Doctor(Doctor doctor)
    {
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
