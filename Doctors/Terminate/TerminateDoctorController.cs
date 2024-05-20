using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Terminate;
[Route("api/v1/doctors")]
[ApiController]
public class TerminateDoctorController : ControllerBase
{

    private readonly TerminateDoctorService _service;

    public TerminateDoctorController(TerminateDoctorService service)
    {
        _service = service;
    }

    [HttpPatch]
    public IActionResult Terminate([Required, StringLength(7)] string doctorLicenseNumber)
    {
        _service.Terminate(doctorLicenseNumber);
        return StatusCode(204);
    }

}
