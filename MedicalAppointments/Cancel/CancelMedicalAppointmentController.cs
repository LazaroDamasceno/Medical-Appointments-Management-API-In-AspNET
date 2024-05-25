using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
[Route("api/v1/medical-appointments/cancelled")]
[ApiController]
public class CancelMedicalAppointmentController : ControllerBase
{

    private readonly ICancelMedicalAppointmentService _service;

    public CancelMedicalAppointmentController(ICancelMedicalAppointmentService service)
    {
        _service = service;
    }

    [HttpPatch]
    public IActionResult Cancel([Required] CancelMedicalAppointmentDTO dto)
    {
        _service.Cancel(dto);
        return StatusCode(204);
    }

}
