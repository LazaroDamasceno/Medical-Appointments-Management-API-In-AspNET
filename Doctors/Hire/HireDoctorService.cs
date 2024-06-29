using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public class HireDoctorService : IHireDoctorService
{

    private readonly AppDbContext _context;
    private readonly IDoctorBuilder _doctorBuilder;
    private readonly ISystemUserBuilder _systemUserBuilder;

    public HireDoctorService(AppDbContext context, IDoctorBuilder doctorBuilder, ISystemUserBuilder systemUserBuilder)
    {
        _context = context;
        _doctorBuilder = doctorBuilder;
        _systemUserBuilder = systemUserBuilder;
    }

    public void Hire([Required] HireDoctorDTO dto)
    {
        var transaction = new TransactionScope();
        ValidateData(dto.DoctorLicenseNumber, dto.SystemUserDTO.Ssn);
        SystemUser systemUser = _systemUserBuilder.Create(dto.SystemUserDTO).Build();
        _context.Add(systemUser);
        Doctor doctor = _doctorBuilder.Create(dto.DoctorLicenseNumber, systemUser).Build();
        _context.Add(doctor);
        _context.SaveChanges();
        transaction.Complete();
    }

    private void ValidateData(string doctorLicenseNumber, string ssn)
    {
        if (_context.Doctors.Any(e => e.LicenseNumber == doctorLicenseNumber))
        {
            throw new DuplicatedDoctorException(doctorLicenseNumber);
        }
        if (_context.SystemUsers.Any(e => e.Ssn == ssn))
        {
            throw new DuplicatedSsnException(ssn);
        }
    }

}
