﻿using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using System.ComponentModel.DataAnnotations;

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
        MedicalAppointment medicalAppointment = _findMedicalAppointment.FindByDoctor(dto.DoctorLicenseNumber, dto.ScheduledDateTime);
        if (medicalAppointment.MedicalNote is not "") throw new FinishedMedicalAppointmentException(dto.DoctorLicenseNumber, dto.ScheduledDateTime);
        medicalAppointment.AddMedicalNote(dto.Note);
        medicalAppointment.Finish();
        _context.Update(medicalAppointment);
        _context.SaveChanges();
    }

}
