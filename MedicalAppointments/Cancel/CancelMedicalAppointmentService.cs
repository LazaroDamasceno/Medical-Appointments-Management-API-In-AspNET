using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    public void Cancel([Required] CancelMedicalAppointmentDTO dto)
    {
        var transaction = new TransactionScope();
        MedicalAppointment medicalAppointment = _findMedicalAppointment.FindByPatient(dto.Ssn, dto.ScheduledDateTime);
        ValidateData(medicalAppointment, dto.Ssn, dto.ScheduledDateTime);
        medicalAppointment.Cancel();
        _context.Update(medicalAppointment);
        _context.SaveChanges();
        transaction.Complete();
    }

    private static void ValidateData(MedicalAppointment medicalAppointment, string ssn, DateTime dateTime)
    {
        if (medicalAppointment.CancelledDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(ssn, dateTime);
        }
        if (medicalAppointment.FinishingDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(ssn, dateTime.ToString());
        }
    }

    public void Cancel([Required] MedicalAppointment medicalAppointment)
    {
        var transaction = new TransactionScope();
        ValidateDate(medicalAppointment);
        medicalAppointment.Cancel();
        _context.Update(medicalAppointment);
        _context.SaveChanges();
        transaction.Complete();
    }

    private static void ValidateDate(MedicalAppointment medicalAppointment) 
    {
        if (medicalAppointment.CancelledDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(
                GetSystemUSer(medicalAppointment).Ssn,
                medicalAppointment.ScheduledDateTime
            );
        }

        if (medicalAppointment.FinishingDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(
                GetSystemUSer(medicalAppointment).Ssn,
                medicalAppointment.ScheduledDateTime.ToString()
            );
        }
    }

    private static SystemUser GetSystemUSer(MedicalAppointment medicalAppointment)
    {
        return medicalAppointment.Patient?.SystemUser ??  throw new NullReferenceException();
    }

}
