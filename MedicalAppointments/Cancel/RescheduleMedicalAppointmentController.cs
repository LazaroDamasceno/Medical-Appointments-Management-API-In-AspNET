using MedicalAppointmentsManagementAPI.MedicalAppointments.Reschedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
[Route("api/v1/medical-appointments/rescheduled")]
[ApiController]
public class RescheduleMedicalAppointmentController : ControllerBase
{

    private readonly IRescheduleMedicalAppointmentService _service;

    public RescheduleMedicalAppointmentController(IRescheduleMedicalAppointmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Reschedule([Required,FromBody] RescheduleMedicalAppointmentDTO dto)
    {
        _service.Reschedule(dto);
        return StatusCode(201);
    }

}
