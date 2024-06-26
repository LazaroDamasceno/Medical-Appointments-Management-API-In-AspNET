using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

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
        var transaction = new TransactionScope();
        Patient patient = _findPatientBySsn.Find(dto.Ssn);
        Doctor doctor = _findDoctorByLicenseNumber.Find(dto.DoctorLicenseNumber);
        ValidateData(dto, patient, doctor);
        MedicalAppointment medicalAppointment = new MedicalAppointmentBuilder()
            .Patient(patient)
            .Doctor(doctor)
            .ScheduledDateTime(dto.ScheduledDateTime)
            .Build();
        _context.Add(medicalAppointment);
        _context.SaveChanges();
        transaction.Complete();
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

        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        DateTime today = new(year, month, day, 0, 0, 0);
        bool isSchedulingDateTimeInThePresentOrPast = today <= dto.ScheduledDateTime;
        if (isSchedulingDateTimeInThePresentOrPast)
        {
            throw new PastOrPastSchedulingDateTimeException(dto.ScheduledDateTime, today);
        }
    }

}
