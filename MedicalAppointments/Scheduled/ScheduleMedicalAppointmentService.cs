using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;

public class ScheduleMedicalAppointmentService : IScheduleMedicalAppointmentService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;
    private readonly IFindPatientBySsnService _findPatientBySsn;

    public ScheduleMedicalAppointmentService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumber, IFindPatientBySsnService findPatientBySsn)
    {
        _context = context;
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
        _findPatientBySsn = findPatientBySsn;
    }

    public void Schedule([Required] ScheduleMedicalAppointmentDTO dto)
    {
        Patient patient = _findPatientBySsn.Find(dto.Ssn);
        Doctor doctor = _findDoctorByLicenseNumber.Find(dto.DoctorLicenseNumber);
        ValidateData(dto, patient, doctor);
        MedicalAppointment medicalAppointment = MedicalAppointment.CreateInstance(patient, doctor, dto.ScheduledDateTime);
        _context.Add(medicalAppointment);
        _context.SaveChanges();
    }

    private void ValidateData(ScheduleMedicalAppointmentDTO dto, Patient patient, Doctor doctor)
    {
        bool doesMedicalAppointmentExist = _context
            .MedicalAppointments
            .Any(
                e => e.Doctor == doctor 
                && e.Patient == patient 
                && e.ScheduledDateTime == dto.ScheduledDateTime
                && e.CancelledDateTime == null
                && e.FinishingDateTime == null
            );
        if (doesMedicalAppointmentExist) 
        {
            throw new DuplicatedMedicalAppointmentException(dto.Ssn, dto.DoctorLicenseNumber, dto.ScheduledDateTime);
        }

        doesMedicalAppointmentExist = _context
            .MedicalAppointments
            .Any(e => e.ScheduledDateTime == dto.ScheduledDateTime
                 && e.CancelledDateTime == null
                 && e.FinishingDateTime == null
            );
        if (doesMedicalAppointmentExist)
        {
            throw new EqualDateTimesException(dto.ScheduledDateTime);
        }
    }

}
