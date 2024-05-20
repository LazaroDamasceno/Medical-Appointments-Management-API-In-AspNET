using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Patients;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.SystemUsers;

public class UpdateSystemUserService
{

    private readonly AppDbContext _context;

    public UpdateSystemUserService(AppDbContext context)
    {
        _context = context;
    }

    public void Update([Required] Patient patient, [Required] UpdateSystemUserDTO dto)
    {
        SystemUser? systemUser = patient.SystemUser;
        systemUser.Update(dto);
        _context.Update(systemUser);
        _context.SaveChanges();
    }

    public void Update([Required] Doctor doctor, [Required] UpdateSystemUserDTO dto)
    {
        SystemUser? systemUser = doctor.SystemUser;
        systemUser.Update(dto);
        _context.Update(systemUser);
        _context.SaveChanges();
    }

}
