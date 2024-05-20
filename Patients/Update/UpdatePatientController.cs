using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;
[Route("api/v1/[controller]")]
[ApiController]
public class UpdatePatientController : ControllerBase
{

    private readonly UpdatePatientService _service;

    public UpdatePatientController(UpdatePatientService service)
    {
        _service = service;
    }

    [HttpPut("ssn")]
    public IActionResult Update([Required, StringLength(9)] string ssn, [Required, FromBody] UpdatePatientDTO dto)
    {
        _service.Update(ssn, dto);
        return StatusCode(204);
    }

}
