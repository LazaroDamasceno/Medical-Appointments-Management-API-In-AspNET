using MedicalAppointmentsManagementAPI.SystemUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;
[Route("api/v1/[controller]")]
[ApiController]
public class DoctorUpdateController : ControllerBase
{

    private readonly DoctorUpdateService _service;

    public DoctorUpdateController(DoctorUpdateService service)
    {
        _service = service;
    }

    [HttpPut("doctorLicenseNumber")]
    public IActionResult Update([Required, StringLength(7)] string doctorLicenseNumber, [Required, FromBody] UpdateSystemUserDTO dto)
    {
        _service.Update(doctorLicenseNumber, dto);
        return StatusCode(204);
    }

}
