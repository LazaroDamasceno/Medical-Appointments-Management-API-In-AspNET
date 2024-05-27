using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByPatient;
[Route("api/v1/medical-appointments/scheduled/by-patient")]
[ApiController]
public class FindScheduledMedicalAppointmentsByPatientController : ControllerBase
{

    private readonly IFindScheduledMedicalAppointmentsByPatientService _service;

    public FindScheduledMedicalAppointmentsByPatientController(IFindScheduledMedicalAppointmentsByPatientService service)
    {
        _service = service;
    }

    [HttpGet("{ssn}")]
    public IActionResult Find([Required, StringLength(9)] string ssn, [Required, FromBody] BetweenDateTimesDTO dateTimesDTO)
    {
        return Ok(_service.Find(ssn, dateTimesDTO));
    }

}
