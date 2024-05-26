using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;

public class UpdateDoctorService : IUpdateDoctorService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;

    public UpdateDoctorService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumber)
    {
        _context = context;
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
    }

    public void Update([Required] UpdateDoctorDTO dto)
    {
        Doctor doctor = _findDoctorByLicenseNumber.Find(dto.DoctorLicenseNumber);
        SystemUser systemUser = _context.SystemUsers.Find(doctor.SystemUserId) ?? throw new NullReferenceException();
        systemUser.Update(dto.SystemUserDTO);
        _context.Update(systemUser);
        _context.SaveChanges();
    }

}
