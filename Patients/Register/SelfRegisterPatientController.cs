using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.Register;
[Route("api/v1/patients")]
[ApiController]
public class SelfRegisterPatientController : ControllerBase
{
    private readonly ISelfRegisterPatientService _service;

    public SelfRegisterPatientController(SelfRegisterPatientService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult SelfRegister([Required, FromBody] SelfRegisterPatientDTO dto)
    {
        _service.SelfRegister(dto);
        return StatusCode(201);
    }
}
