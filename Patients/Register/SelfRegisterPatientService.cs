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
        IsPatientAlreadyRegistered(dto.SystemUserDTO.Ssn);
        SystemUser systemUser  = new SystemUserBuilder()
            .FromDTO(dto.SystemUserDTO)
            .Build();
        _context.Add(systemUser);
        Patient patient = new PatientBuilder()
            .Address(dto.Address)
            .SystemUser(systemUser)
            .Builder();
        _context.Add(patient);
        _context.SaveChanges();
    }

    private void IsPatientAlreadyRegistered(string ssn)
    {
        if (_context.SystemUsers.Any(e => e.Ssn == ssn))
        {
            throw new DuplicatedPatientException(ssn);
        }
    }

}
