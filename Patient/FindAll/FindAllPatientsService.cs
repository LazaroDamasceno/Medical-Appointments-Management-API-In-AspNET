using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI.Patient.FindAll;

public class FindAllPatientsService : IFindAllPatientsService
{

    private AppDbContext _context;

    public FindAllPatientsService(AppDbContext context)
    {
        _context = context;
    }

    public List<PatientEntity> FindAll()
    {
        return [.. _context.Patients.Include(e => e.SystemUser)];
    }
}
