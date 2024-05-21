using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;

public class CancelMedicalAppointmentService : ICancelMedicalAppointmentService
{

    private readonly AppDbContext _context;
    private readonly FindMedicalAppointmentService _findMedicalAppointment;

    public CancelMedicalAppointmentService(AppDbContext context, FindMedicalAppointmentService findMedicalAppointment)
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

}
