using MedicalAppointmentsManagementAPI.Patient.FindBySsn;
using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;

public class UpdatePatientService : IUpdatePatientService
{

    private readonly AppDbContext _context;
    private readonly FindPatientBySsnService _findPatientBySsn;
    private readonly UpdateSystemUserService _updateSystemUser;

    public UpdatePatientService(AppDbContext context, FindPatientBySsnService findPatientBySsn, UpdateSystemUserService updateSystem)
    {
        _context = context;
        _findPatientBySsn = findPatientBySsn;
        _updateSystemUser = updateSystem;
    }

    public void Update([Required, StringLength(9)] string ssn, [Required] UpdatePatientDTO dto)
    {
        Patient patient = _findPatientBySsn.Find(ssn);
        patient.UpdateAddress(dto.Address);
        _context.Update(patient);
        _context.SaveChanges();
        _updateSystemUser.Update(patient, dto.Dto);
    }
}
