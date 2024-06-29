using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Reschedule;

public class RescheduleMedicalAppointmentService : IRescheduleMedicalAppointmentService
{

    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;
    private readonly IFindMedicalAppointmentService _findMedicalAppointmentService;
    private readonly AppDbContext _context;
    private readonly IMedicalAppointmentBuilder _medicalAppointmentBuilder;

    public RescheduleMedicalAppointmentService(
        IFindDoctorByLicenseNumberService findDoctorByLicenseNumber, 
        IFindMedicalAppointmentService findMedicalAppointmentService, 
        AppDbContext context,
        IMedicalAppointmentBuilder medicalAppointmentBuilder
    ) {
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
        _findMedicalAppointmentService = findMedicalAppointmentService;
        _context = context;
        _medicalAppointmentBuilder = medicalAppointmentBuilder;
    }

    public void Reschedule([Required] RescheduleMedicalAppointmentDTO dto)
    {
        var transaction = new TransactionScope();
        MedicalAppointment oldMedicalAppointment = _findMedicalAppointmentService
            .FindByDoctor(dto.DoctorLicenseNumber, dto.OldScheduledDateTime);
        ValidateData(oldMedicalAppointment, dto);
        oldMedicalAppointment.Cancel();
        _context.Update(oldMedicalAppointment);
        Patient? patient = _context.Patients.Find(oldMedicalAppointment.PatientId);
        Doctor? doctor = _findDoctorByLicenseNumber.Find(dto.DoctorLicenseNumber);
        MedicalAppointment? newMedicalAppointment = _medicalAppointmentBuilder.Create(dto.NewScheduledDateTime, patient, doctor).Build();
        _context.Add(newMedicalAppointment);
        _context.SaveChanges();
        transaction.Complete();
    }

    private static void ValidateData(MedicalAppointment medicalAppointment, RescheduleMedicalAppointmentDTO dto)
    {
        if (medicalAppointment.CancelledDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(dto.DoctorLicenseNumber, dto.OldScheduledDateTime);
        }
        if (medicalAppointment.FinishingDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(dto.DoctorLicenseNumber, dto.OldScheduledDateTime.ToString());
        }
    }

}
