using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;

[ApiController]
[Route("api/[controller]")]
public class FindAll(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet]
    public List<MedicalAppointment> Find()
    {
        return [.. _context.MedicalAppointments.Include(e => e.Patient).Include(e => e.Doctor)];
    }
}
