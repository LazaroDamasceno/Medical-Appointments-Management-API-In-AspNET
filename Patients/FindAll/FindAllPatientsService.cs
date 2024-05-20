using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI.Patients.FindAll;

public class FindAllPatientsService : IFindAllPatientsService
{

    private AppDbContext _context;

    public FindAllPatientsService(AppDbContext context)
    {
        _context = context;
    }

    public List<Patient> FindAll()
    {
        return [.. _context.Patients.Include(e => e.SystemUser)];
    }
}
