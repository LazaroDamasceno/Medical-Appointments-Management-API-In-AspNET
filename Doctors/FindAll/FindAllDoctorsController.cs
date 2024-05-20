using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentsManagementAPI.Doctors.FindAll;
[Route("api/v1/doctors")]
[ApiController]
public class FindAllDoctorsController : ControllerBase
{

    private readonly FindAllDoctorsService _service;

    public FindAllDoctorsController(FindAllDoctorsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_service.FindAll());
    }

}
