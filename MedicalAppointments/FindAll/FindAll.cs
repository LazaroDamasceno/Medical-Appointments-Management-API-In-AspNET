using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;

[ApiController]
[Route("api/[controller]")]
public class FindAll(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet]
    public List<MedicalAppointment> Find()
    {
        return [.. _context.MedicalAppointments];
    }
}
