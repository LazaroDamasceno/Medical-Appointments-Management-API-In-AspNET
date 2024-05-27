using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByPatient;
[Route("api/v1/medical-appointments/finished/by-patient")]
[ApiController]
public class FindFinishedMedicalAppointmentsByPatientController : ControllerBase
{

    private readonly IFindFinishedMedicalAppointmentsByPatientService _service;

    [HttpGet("{ssn}")]
    public IActionResult Find([Required, StringLength(9)] string ssn, [Required, FromBody] BetweenDateTimesDTO dateTimesDTO)
    {
        return Ok(_service.Find(ssn, dateTimesDTO));
    }

}
