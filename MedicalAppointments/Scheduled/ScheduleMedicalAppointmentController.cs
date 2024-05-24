using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;
[Route("api/v1/medical-appointments/new")]
[ApiController]
public class ScheduleMedicalAppointment : ControllerBase
{

    private readonly IScheduleMedicalAppointmentService _service;

    public ScheduleMedicalAppointment(IScheduleMedicalAppointmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Schedule([Required, FromBody] ScheduleMedicalAppointmentDTO dto)
    {
        _service.Schedule(dto);
        return StatusCode(201);
    }

}
