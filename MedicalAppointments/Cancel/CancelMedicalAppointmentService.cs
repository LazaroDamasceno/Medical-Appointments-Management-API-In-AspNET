using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;

public class CancelMedicalAppointmentService : ICancelMedicalAppointmentService
{

    private readonly AppDbContext _context;
    private readonly IFindMedicalAppointmentService _findMedicalAppointment;

    public CancelMedicalAppointmentService(AppDbContext context, IFindMedicalAppointmentService findMedicalAppointment)
    {
        _context = context;
        _findMedicalAppointment = findMedicalAppointment;
    }

    public void Cancel([Required, StringLength(9)] string ssn, [Required, StringLength(7)] string doctorLicenseNumber, [Required] DateTime scheduledDateTime)
    {
        MedicalAppointment medicalAppointment = _findMedicalAppointment.Find(ssn, doctorLicenseNumber, scheduledDateTime);
        ValidateData(medicalAppointment, ssn, doctorLicenseNumber, scheduledDateTime);
        medicalAppointment.Cancel();
        _context.Update(medicalAppointment);
        _context.SaveChanges();
    }

    private static void ValidateData(MedicalAppointment medicalAppointment, string ssn, string doctorLicenseNumber, DateTime dateTime)
    {
        if (medicalAppointment.CancelledDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(ssn, doctorLicenseNumber, dateTime);
        }
        if (medicalAppointment.FinishingDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(ssn, doctorLicenseNumber, dateTime.ToString());
        }
    }

    public void Cancel([Required] MedicalAppointment medicalAppointment)
    {
        ValidateDate(medicalAppointment);
        medicalAppointment.Cancel();
        _context.Update(medicalAppointment);
        _context.SaveChanges();
    }

    private static void ValidateDate(MedicalAppointment medicalAppointment) 
    {
        if (medicalAppointment.CancelledDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(
                GetSystemUSer(medicalAppointment).Ssn, 
                GetDoctor(medicalAppointment).LicenseNumber,
                medicalAppointment.ScheduledDateTime
            );
        }

        if (medicalAppointment.FinishingDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(
                GetSystemUSer(medicalAppointment).Ssn,
                GetDoctor(medicalAppointment).LicenseNumber,
                medicalAppointment.ScheduledDateTime
            );
        }
    }

    private static SystemUser GetSystemUSer(MedicalAppointment medicalAppointment)
    {
        if (medicalAppointment is null) throw new NullReferenceException();

        Patient? patient = medicalAppointment.Patient;
        if (patient is null) throw new NullReferenceException();

        SystemUser? systemUser = patient.SystemUser;
        if (systemUser is null) throw new NullReferenceException();
        return systemUser;
    }

    private static Doctor GetDoctor(MedicalAppointment medicalAppointment)
    {
        if (medicalAppointment is null) throw new NullReferenceException();

        Doctor? doctor = medicalAppointment.Doctor;
        if (doctor is null) throw new NullReferenceException();
        return doctor;
    }

}
