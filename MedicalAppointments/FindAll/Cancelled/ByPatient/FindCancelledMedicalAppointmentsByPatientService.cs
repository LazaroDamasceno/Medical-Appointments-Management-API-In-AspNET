using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled.ByPatient;

public class FindCancelledMedicalAppointmentsByPatientService : IFindCancelledMedicalAppointmentsByPatientService
{

    private readonly AppDbContext _context;
    private readonly IFindPatientBySsnService _findPatientBySsn;

    public FindCancelledMedicalAppointmentsByPatientService(AppDbContext context, IFindPatientBySsnService findPatientBySsn)
    {
        _context = context;
        _findPatientBySsn = findPatientBySsn;
    }

    public List<MedicalAppointment> Find([Required, StringLength(9)] string ssn)
    {
        Patient patient = _findPatientBySsn.Find(ssn);
        return [
            .. _context
            .MedicalAppointments
            .Include(e => e.Patient)
            .Include(e => e.Doctor)
            .Include(e => e.Patient.SystemUser)
            .Include(e => e.Doctor.SystemUser)
            .Where(
                e => e.Patient == patient 
                && e.CancelledDateTime != null
            )
        ];
    }
}
