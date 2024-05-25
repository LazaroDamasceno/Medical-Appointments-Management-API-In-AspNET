using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using System.Numerics;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Find;

public class FindMedicalAppointmentService : IFindMedicalAppointmentService
{

    private readonly AppDbContext _context;
    private readonly IFindPatientBySsnService _findPatientBySsn;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;

    public FindMedicalAppointmentService(
            AppDbContext context, 
            IFindPatientBySsnService findPatientBySsn, 
            IFindDoctorByLicenseNumberService findDoctorByLicenseNumber
    ) {
        _context = context;
        _findPatientBySsn = findPatientBySsn;
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
    }

    public MedicalAppointment Find(string ssn, string doctorLicenseNumber, DateTime scheduledDateTime)
    {
        Patient patient = _findPatientBySsn.Find(ssn);
        Doctor doctor = _findDoctorByLicenseNumber.Find(doctorLicenseNumber);
        MedicalAppointment? medicalAppointment = _context
            .MedicalAppointments
            .First(
                e => e.Patient == patient
                && e.Doctor == doctor
                && e.ScheduledDateTime == scheduledDateTime
                && e.FinishingDateTime == null
                && e.CancelledDateTime == null
            );
        if (medicalAppointment == null)
        {
            throw new MedicalAppointmentNotFoundException(ssn, doctorLicenseNumber, scheduledDateTime);
        }
        return medicalAppointment;
    }

    public MedicalAppointment FindByDoctor(string doctorLicenseNumber, DateTime scheduledDateTime)
    {
        Doctor doctor = _findDoctorByLicenseNumber.Find(doctorLicenseNumber);
        MedicalAppointment? medicalAppointment = _context
            .MedicalAppointments
            .First(e => e.Doctor == doctor && e.ScheduledDateTime == scheduledDateTime);
        if (medicalAppointment == null)
        {
            throw new MedicalAppointmentNotFoundException(doctorLicenseNumber, scheduledDateTime);
        }
        return medicalAppointment;
    }

    public MedicalAppointment FindByPatient(string ssn, DateTime scheduledDateTime)
    {
        Patient patient = _findPatientBySsn.Find(ssn);
        MedicalAppointment? medicalAppointment = _context
        .MedicalAppointments
            .First(e => e.Patient == patient && e.ScheduledDateTime == scheduledDateTime);
        if (medicalAppointment == null)
        {
            throw new MedicalAppointmentNotFoundException(doctorLicenseNumber, scheduledDateTime);
        }
        return medicalAppointment;
    }

}
