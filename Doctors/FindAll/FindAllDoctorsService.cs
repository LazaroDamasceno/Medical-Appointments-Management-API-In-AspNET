using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI.Doctors.FindAll;

public class FindAllDoctorsService : IFindAllDoctorsService
{
    private readonly AppDbContext _context;

    public FindAllDoctorsService(AppDbContext context)
    {
        _context = context;
    }

    public List<Doctor> FindAll()
    {
        return [.. _context.Doctors.Include(e => e.SystemUser)];
    }

}
