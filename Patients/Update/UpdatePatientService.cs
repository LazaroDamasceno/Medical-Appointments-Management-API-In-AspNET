using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;

public class UpdatePatientService : IUpdatePatientService
{

    private readonly AppDbContext _context;
    private readonly IFindPatientBySsnService _findPatientBySsn;

    public UpdatePatientService(AppDbContext context, IFindPatientBySsnService findPatientBySsn)
    {
        _context = context;
        _findPatientBySsn = findPatientBySsn;
    }

    public void Update([Required] UpdatePatientDTO dto)
    {
        Patient patient = _findPatientBySsn.Find(dto.SystemUser.Ssn);
        patient.Update(dto.Address);
        _context.Update(patient);
        SystemUser? systemUser = GetSystemUser(patient);
        _context.Update(systemUser);
        _context.SaveChanges();
    }

    private static SystemUser GetSystemUser(Patient patient)
    {
        return patient.SystemUser ?? throw new NullReferenceException();
    }

}
