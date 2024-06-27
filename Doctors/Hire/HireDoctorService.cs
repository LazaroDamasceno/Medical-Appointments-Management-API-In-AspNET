using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public class HireDoctorService : IHireDoctorService
{

    private readonly AppDbContext _context;

    public HireDoctorService(AppDbContext context)
    {
        _context = context;
    }

    public void Hire([Required] HireDoctorDTO dto)
    {
        var transaction = new TransactionScope();
        ValidateData(dto.DoctorLicenseNumber, dto.SystemUserDTO.Ssn);
        SystemUser systemUser = new SystemUserBuilder(dto.SystemUserDTO).Build();
        _context.Add(systemUser);
        Doctor doctor = new DoctorBuilder(dto.DoctorLicenseNumber, systemUser).Build();
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
