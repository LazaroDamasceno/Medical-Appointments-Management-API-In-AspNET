using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;

public class DoctorUpdateService : IDoctorUpdateService
{

    private readonly FindDoctorByLicenseNumberService _findDoctorByLicenseNumber;
    private readonly AppDbContext _context;

    public DoctorUpdateService(FindDoctorByLicenseNumberService findDoctorByLicenseNumber, AppDbContext context)
    {
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
        _context = context;
    }

    public void Update([Required, StringLength(7)] string doctorLicenseNumber, [Required] UpdateSystemUserDTO dto)
    {
        Doctor doctor = _findDoctorByLicenseNumber.Find(doctorLicenseNumber);
        SystemUser? systemUser = doctor.SystemUser;
        systemUser.Update(dto);
        _context.Update(systemUser);
        _context.SaveChanges();
    }
}
