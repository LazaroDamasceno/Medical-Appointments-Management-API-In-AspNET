using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Find;

public class FindMedicalAppointmentService : IFindMedicalAppointmentService
{

    private readonly AppDbContext _context;
    private readonly FindPatientBySsnService _findPatientBySsn;
    private readonly FindDoctorByLicenseNumberService _findDoctorByLicenseNumber;

    public FindMedicalAppointmentService(
        AppDbContext context, 
        FindPatientBySsnService findPatientBySsn, 
        FindDoctorByLicenseNumberService findDoctorByLicenseNumber
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

    public MedicalAppointment Find(string doctorLicenseNumber, DateTime scheduledDateTime)
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

}
