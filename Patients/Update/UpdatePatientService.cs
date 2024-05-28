using MedicalAppointmentsManagementAPI.Doctors;
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
        Patient patient = _findPatientBySsn.Find(dto.Ssn);
        patient.Update(dto.Address);
        _context.Update(patient);
        SystemUser? systemUser = _context.SystemUsers.Find(patient.SystemUserId);
        systemUser.Update(dto.SystemUser);
        _context.Update(systemUser);
        _context.SaveChanges();
    }

}
