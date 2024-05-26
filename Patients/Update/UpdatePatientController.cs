using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Update;
[Route("api/v1/patients")]
[ApiController]
public class UpdatePatientController : ControllerBase
{

    private readonly IUpdatePatientService _service;

    public UpdatePatientController(IUpdatePatientService service)
    {
        _service = service;
    }

    [HttpPut]
    public IActionResult Update([Required, FromBody] UpdatePatientDTO dto)
    {
        _service.Update(dto);
        return StatusCode(204);
    }

}
