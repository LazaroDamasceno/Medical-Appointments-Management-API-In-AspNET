using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Reschedule;

public class RescheduleMedicalAppointmentService : IRescheduleMedicalAppointmentService
{

    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;
    private readonly IFindMedicalAppointmentService _findMedicalAppointmentService;
    private readonly AppDbContext _context;

    public RescheduleMedicalAppointmentService(IFindDoctorByLicenseNumberService findDoctorByLicenseNumber, IFindMedicalAppointmentService findMedicalAppointmentService, AppDbContext context)
    {
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
        _findMedicalAppointmentService = findMedicalAppointmentService;
        _context = context;
    }

    public void Reschedule([Required] RescheduleMedicalAppointmentDTO dto)
    {
        MedicalAppointment oldMedicalAppointment = _findMedicalAppointmentService.FindByDoctor(dto.DoctorLicenseNumber, dto.OldScheduledDateTime);
        ValidateData(oldMedicalAppointment, dto);
        oldMedicalAppointment.Cancel();
        _context.Update(oldMedicalAppointment);
        Patient? patient = _context.Patients.Find(oldMedicalAppointment.PatientId);
        Doctor? doctor = _findDoctorByLicenseNumber.Find(dto.DoctorLicenseNumber);
        MedicalAppointment? newMedicalAppointment = MedicalAppointment.CreateInstance(patient, doctor, dto.NewScheduledDateTime);
        _context.Add(newMedicalAppointment);
        _context.SaveChanges();
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
