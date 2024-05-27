using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByDoctor;
[Route("api/v1/medical-appointments/scheduled/by-doctor")]
[ApiController]
public class FindScheduledMedicalAppointmentsByDoctorServiceController : ControllerBase
{

    private readonly IFindScheduledMedicalAppointmentsByDoctorService _service;

    public FindScheduledMedicalAppointmentsByDoctorServiceController(IFindScheduledMedicalAppointmentsByDoctorService service)
    {
        _service = service;
    }

    [HttpGet("doctorLicenseNumber")]
    public IActionResult Find([Required, StringLength(7)] string doctorLicenseNumber, [Required] BetweenDateTimesDTO dateTimesDTO)
    {
        return Ok(_service.Find(doctorLicenseNumber, dateTimesDTO));
    }

}
