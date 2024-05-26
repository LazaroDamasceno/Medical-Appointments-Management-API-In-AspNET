
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;

public class FindAllMedicalAppointmentsService : IFindAllMedicalAppointmentsService
{

    private readonly AppDbContext _context;

    public FindAllMedicalAppointmentsService(AppDbContext context)
    {
        _context = context;
    }

    public List<MedicalAppointment> FindAll()
    {
        return [
            .. _context
            .MedicalAppointments
            .Include(e => e.Patient)
            .Include(e => e.Doctor)
            .Include(e => e.Patient.SystemUser)
            .Include(e => e.Doctor.SystemUser)
        ];
    }
}
