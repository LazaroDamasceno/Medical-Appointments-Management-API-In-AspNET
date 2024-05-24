using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;
[Route("api/v1/doctors")]
[ApiController]
public class HireDoctorController : ControllerBase
{
    
    private readonly IHireDoctorService _service;

    public HireDoctorController(IHireDoctorService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Hire([Required, FromBody] HireDoctorDTO dto)
    {
        _service.Hire(dto);
        return StatusCode(201);
    }

}
