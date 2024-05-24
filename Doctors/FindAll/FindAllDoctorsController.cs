using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentsManagementAPI.Doctors.FindAll;
[Route("api/v1/doctors")]
[ApiController]
public class FindAllDoctorsController : ControllerBase
{

    private readonly IFindAllDoctorsService _service;

    public FindAllDoctorsController(IFindAllDoctorsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_service.FindAll());
    }

}
