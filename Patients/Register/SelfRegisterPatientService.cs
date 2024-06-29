using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MedicalAppointmentsManagementAPI.Patients.Register;

public class SelfRegisterPatientService : ISelfRegisterPatientService
{

    private readonly AppDbContext _context;
    private readonly IPatientBuilder _patientBuilder;
    private readonly ISystemUserBuilder _systemUserBuilder;

    public SelfRegisterPatientService(
        AppDbContext context, 
        IPatientBuilder patientBuilder, 
        ISystemUserBuilder systemUserBuilder
    ) {
        _context = context;
        _patientBuilder = patientBuilder;
        _systemUserBuilder = systemUserBuilder;
    }

    public void SelfRegister([Required] SelfRegisterPatientDTO dto)
    {
        var transaction = new TransactionScope();
        IsPatientAlreadyRegistered(dto.SystemUserDTO.Ssn);
        SystemUser systemUser  = _systemUserBuilder.Create(dto.SystemUserDTO).Build();
        _context.Add(systemUser);
        Patient patient = _patientBuilder.Create(dto.Address, systemUser).Build();
        _context.Add(patient);
        _context.SaveChanges();
        transaction.Complete();
    }

    private void IsPatientAlreadyRegistered(string ssn)
    {
        if (_context.SystemUsers.Any(e => e.Ssn == ssn))
        {
            throw new DuplicatedPatientException(ssn);
        }
    }

}
