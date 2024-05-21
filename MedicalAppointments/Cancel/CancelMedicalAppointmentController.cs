using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
[Route("api/v1/medical-appointments/cancelled")]
[ApiController]
public class CancelMedicalAppointmentController : ControllerBase
{

    private readonly CancelMedicalAppointmentService _service;

    public CancelMedicalAppointmentController(CancelMedicalAppointmentService service)
    {
        _service = service;
    }

    public IActionResult Cancel([Required, StringLength(9)] string ssn, [Required, StringLength(7)] string doctorLicenseNumber, [Required] DateTime scheduledDateTime)
    {
        _service.Cancel(ssn, doctorLicenseNumber, scheduledDateTime);
        return StatusCode(204);
    }

}
