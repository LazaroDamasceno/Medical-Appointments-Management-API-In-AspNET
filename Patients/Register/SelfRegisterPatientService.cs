using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Register;

public class SelfRegisterPatientService : ISelfRegisterPatientService
{

    private AppDbContext _context;

    public SelfRegisterPatientService(AppDbContext context)
    {
        _context = context;
    }

    public void SelfRegister([Required] SelfRegisterPatientDTO dto)
    {
        if (_context.SystemUsers.Any(e => e.Ssn == dto.SystemUserDTO.Ssn)) 
        {
            throw new DuplicatedPatientException(dto.SystemUserDTO.Ssn);
        }
        SystemUser systemUser  = SystemUser.CreateInstance(dto.SystemUserDTO);
        _context.Add(systemUser);
        Patient patient = Patient.CreateInstance(dto.Address, systemUser);
        _context.Add(patient);
        _context.SaveChanges();
    }

}
