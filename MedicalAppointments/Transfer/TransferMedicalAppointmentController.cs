using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Transfer;
[Route("api/v1/medical-appointments/transfered")]
[ApiController]
public class TransferMedicalAppointmentController : ControllerBase
{

    private readonly ITransferMedicalAppointmentService _service;

    public TransferMedicalAppointmentController(ITransferMedicalAppointmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Transfer([Required, FromBody] TransferMedicalAppointmentDTO dto)
    {
        _service.Transfer(dto);
        return StatusCode(201);
    }

}
