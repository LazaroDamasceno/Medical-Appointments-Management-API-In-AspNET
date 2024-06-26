using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;

public class AddMedicalNoteService : IAddMedicalNoteService
{

    private readonly IFindMedicalAppointmentService _findMedicalAppointment;
    private readonly AppDbContext _context;

    public AddMedicalNoteService(IFindMedicalAppointmentService findMedicalAppointment, AppDbContext context)
    {
        _findMedicalAppointment = findMedicalAppointment;
        _context = context;
    }

    public void AddMedicalNoted([Required] MedicalNoteDTO dto)
    {
        var transaction = new TransactionScope();
        MedicalAppointment medicalAppointment = _findMedicalAppointment.FindByDoctor(dto.DoctorLicenseNumber, dto.ScheduledDateTime);
        if (medicalAppointment.MedicalNote is not null) throw new FinishedMedicalAppointmentException(dto.DoctorLicenseNumber, dto.ScheduledDateTime);
        medicalAppointment.AddMedicalNote(dto.Note);
        medicalAppointment.Finish();
        _context.Update(medicalAppointment);
        _context.SaveChanges();
        transaction.Complete();
    }

}
