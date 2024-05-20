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
        patient.SystemUser.Update(dto);
        _context.Update(patient.SystemUser);
        _context.SaveChanges();
    }

    public void Update([Required] Doctor doctor, [Required] UpdateSystemUserDTO dto)
    {
        doctor.SystemUser.Update(dto);
        _context.Update(doctor.SystemUser);
        _context.SaveChanges();
    }

}
