using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled.ByPatient;
[Route("api/v1/medical-appointments/cancelled/by-patient")]
[ApiController]
public class FindCancelledMedicalAppointmentsByPatientController : ControllerBase
{

    private readonly IFindCancelledMedicalAppointmentsByPatientService _service;

    public FindCancelledMedicalAppointmentsByPatientController(IFindCancelledMedicalAppointmentsByPatientService service)
    {
        _service = service;
    }

    [HttpGet("ssn")]
    public IActionResult Find([Required, StringLength(9)] string ssn)
    {
        return Ok(_service.Find(ssn));
    }

}
