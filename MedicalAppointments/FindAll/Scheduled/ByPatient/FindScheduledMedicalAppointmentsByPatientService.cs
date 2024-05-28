using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.ValidateDateTimes;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByPatient;

public class FindScheduledMedicalAppointmentsByPatientService : IFindScheduledMedicalAppointmentsByPatientService
{

    private readonly AppDbContext _context;
    private readonly IFindPatientBySsnService _findPatientBySsn;
    private readonly IValidateDateTimesService _validateDateTimes;

    public FindScheduledMedicalAppointmentsByPatientService(AppDbContext context, IFindPatientBySsnService findPatientBySsn, IValidateDateTimesService validateDateTimes)
    {
        _context = context;
        _findPatientBySsn = findPatientBySsn;
        _validateDateTimes = validateDateTimes;
    }

    public List<MedicalAppointment> Find([Required, StringLength(9)] string ssn, [Required] BetweenDateTimesDTO dateTimesDTO)
    {
        _validateDateTimes.ValidateDateTimes(dateTimesDTO);
        Patient patient = _findPatientBySsn.Find(ssn);
        return [
            .. _context
            .MedicalAppointments
            .Include(e => e.Patient)
            .Include(e => e.Doctor)
            .Include(e => e.Patient.SystemUser)
            .Include(e => e.Doctor.SystemUser)
            .Where(
                e => e.ScheduledDateTime >= dateTimesDTO.FirstDateTime
                && e.ScheduledDateTime <= dateTimesDTO.LastDateTime
                && e.FinishingDateTime == null
                && e.CancelledDateTime == null
                && e.Patient == patient
            )
        ];
    }

}
