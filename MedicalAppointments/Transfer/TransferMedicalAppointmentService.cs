using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.SystemUsers;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Transfer;

public class TransferMedicalAppointmentService : ITransferMedicalAppointmentService
{

    private readonly IFindMedicalAppointmentService _findMedicalAppointment;
    private readonly AppDbContext _context;
    private readonly ScheduleMedicalAppointmentService _scheduleMedicalAppointment;

    public TransferMedicalAppointmentService(IFindMedicalAppointmentService findMedicalAppointment, 
                                        AppDbContext context, 
                                        ScheduleMedicalAppointmentService scheduleMedicalAppointment
    ) {
        _findMedicalAppointment = findMedicalAppointment;
        _context = context;
        _scheduleMedicalAppointment = scheduleMedicalAppointment;
    }

    public void Transfer(TransferMedicalAppointmentDTO dto)
    {
        MedicalAppointment medicalAppointment = _findMedicalAppointment.Find(dto.DoctorLicenseNumber, dto.OldScheduledDateTime);
        ValidateDate(medicalAppointment);
        medicalAppointment.Cancel();
        var patient = GetPatient(medicalAppointment);
        var doctor = GetDoctor(medicalAppointment);
        medicalAppointment = MedicalAppointment.CreateInstance(patient, doctor, dto.NewScheduledDateTime);
        _context.Add(medicalAppointment);
        _context.SaveChanges();
    }

    private static void ValidateDate(MedicalAppointment medicalAppointment)
    {
        if (medicalAppointment is null) throw new NullReferenceException();
        Patient? patient = medicalAppointment.Patient;
        if (patient is null) throw new NullReferenceException();
        SystemUser? systemUser = patient.SystemUser;
        if (systemUser is null) throw new NullReferenceException();

        if (medicalAppointment.CancelledDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(
                systemUser.Ssn,
                GetDoctor(medicalAppointment).LicenseNumber,
                medicalAppointment.ScheduledDateTime
            );
        }

        if (medicalAppointment.FinishingDateTime is not null)
        {
            throw new CancelledMedicalAppointmentException(
                systemUser.Ssn,
                GetDoctor(medicalAppointment).LicenseNumber,
                medicalAppointment.ScheduledDateTime.ToString()
            );
        }
    }

    private static Patient GetPatient(MedicalAppointment medicalAppointment)
    {
        if (medicalAppointment is null) throw new NullReferenceException();

        Patient? patient = medicalAppointment.Patient;
        if (patient is null) throw new NullReferenceException();

        return patient;
    }

    private static Doctor GetDoctor(MedicalAppointment medicalAppointment)
    {
        if (medicalAppointment is null) throw new NullReferenceException();
        
        Doctor? doctor = medicalAppointment.Doctor;
        if (doctor is null) throw new NullReferenceException();
        return doctor;
    }

}
