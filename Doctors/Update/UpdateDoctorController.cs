using MedicalAppointmentsManagementAPI.SystemUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;
[Route("api/v1/[controller]")]
[ApiController]
public class UpdateDoctorController : ControllerBase
{

    private readonly UpdateDoctorService _service;

    public UpdateDoctorController(UpdateDoctorService service)
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
