using MedicalAppointmentsManagementAPI.Patient;
using MedicalAppointmentsManagementAPI.Patient.FindBySsn;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUser;

public class UpdateSystemUserService
{

    private readonly AppDbContext _context;
    private readonly FindPatientBySsnService _findPatientBySsn;

    public UpdateSystemUserService(AppDbContext context, FindPatientBySsnService findPatientBySsn)
    {
        _context = context;
        _findPatientBySsn = findPatientBySsn;
    }

    public void Update([Required] PatientEntity? patient, [Required] UpdateSystemUserDTO dto)
    {
        patient.SystemUser.Update(dto);
        _context.Update(patient.SystemUser);
        _context.SaveChanges();
    }

}
