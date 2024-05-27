using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByDoctor;
[Route("api/v1/medical-appointments/finished/by-doctors")]
[ApiController]
public class FindFinishedMedicalAppointmentsByDoctorController : ControllerBase
{

    private readonly IFindFinishedMedicalAppointmentsByDoctorService _service;

    public FindFinishedMedicalAppointmentsByDoctorController(IFindFinishedMedicalAppointmentsByDoctorService service)
    {
        _service = service;
    }

    [HttpGet("doctorLicenseNumber")]
    public IActionResult Find([Required, StringLength(7)] string doctorLicenseNumber, [Required, FromBody] BetweenDateTimesDTO dateTimesDTO)
    {
        return Ok(_service.Find(doctorLicenseNumber, dateTimesDTO));
    }

}
