using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentsManagementAPI.Patients.FindAll;
[Route("api/v1/patients")]
[ApiController]
public class FindAllPatientsController : ControllerBase
{

    private readonly IFindAllPatientsService _service;

    public FindAllPatientsController(IFindAllPatientsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_service.FindAll());
    }

}
