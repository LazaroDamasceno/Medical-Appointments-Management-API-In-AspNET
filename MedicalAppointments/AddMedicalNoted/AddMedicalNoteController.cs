using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;
[Route("api/v1/medical-appointments")]
[ApiController]
public class AddMedicalNoteController : ControllerBase
{

    private readonly IAddMedicalNoteService _service;

    public AddMedicalNoteController(IAddMedicalNoteService service)
    {
        _service = service;
    }

    [HttpPatch]
    public IActionResult AddMedicalNoted([Required] MedicalNoteDTO dto) 
    {
        _service.AddMedicalNoted(dto);
        return StatusCode(204);
    }

}
