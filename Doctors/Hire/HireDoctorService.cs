using MedicalAppointmentsManagementAPI.SystemUser;
using System.ComponentModel.DataAnnotations;

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
        ValidateData(dto.DoctorLicenseNumber, dto.SystemUserDTO.Ssn);
        SystemUser systemUser = SystemUser.CreateInstance(dto.SystemUserDTO); ;
        _context.Add(systemUser);
        Doctor doctor = Doctor.CreateInstance(dto.DoctorLicenseNumber, systemUser);
        _context.Add(doctor);
        _context.SaveChanges();
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
