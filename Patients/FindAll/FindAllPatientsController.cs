using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentsManagementAPI.Patients.FindAll;
[Route("api/v1/[controller]")]
[ApiController]
public class FindAllPatientsController : ControllerBase
{

    private readonly FindAllPatientsService _service;

    public FindAllPatientsController(FindAllPatientsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_service.FindAll());
    }

}
