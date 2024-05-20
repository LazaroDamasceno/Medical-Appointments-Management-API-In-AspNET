using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctor.Hire;
[Route("api/v1/[controller]")]
[ApiController]
public class HireDoctorController : ControllerBase
{
    
    private readonly HireDoctorService _service;

    public HireDoctorController(HireDoctorService service)
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
