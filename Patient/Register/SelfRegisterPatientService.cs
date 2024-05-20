using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patient.Register;

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
        SystemUserEntity systemUser  = SystemUserEntity.CreateInstance(dto.SystemUserDTO);
        _context.Add(systemUser);
        PatientEntity patient = PatientEntity.CreateInstance(dto.Address, systemUser);
        _context.Add(patient);
        _context.SaveChanges();
    }

}
