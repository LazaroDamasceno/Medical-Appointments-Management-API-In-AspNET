using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;
[Route("api/v1/doctors")]
[ApiController]
public class UpdateDoctorController : ControllerBase
{

    private readonly IUpdateDoctorService _service;

    public UpdateDoctorController(IUpdateDoctorService service)
    {
        _service = service;
    }

    [HttpPut]
    public IActionResult Update([Required] UpdateDoctorDTO dto)
    {
        _service.Update(dto);
        return StatusCode(204);
    }

}
