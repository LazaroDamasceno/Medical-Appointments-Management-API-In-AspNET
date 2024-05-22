using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;
[Route("api/v1/medical-appointments")]
[ApiController]
public class ScheduleMedicalAppointment : ControllerBase
{

    private readonly ScheduleMedicalAppointmentService _service;

    public ScheduleMedicalAppointment(ScheduleMedicalAppointmentService service)
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
