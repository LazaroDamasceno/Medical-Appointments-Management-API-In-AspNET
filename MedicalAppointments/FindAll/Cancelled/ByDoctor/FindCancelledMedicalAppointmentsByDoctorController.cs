using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled;
[Route("api/v1/medical-appointments/cancelled/by-doctor")]
[ApiController]
public class FindCancelledMedicalAppointmentsByDoctorController : ControllerBase
{

    private readonly IFindCancelledMedicalAppointmentsByDoctorService _service;

    public FindCancelledMedicalAppointmentsByDoctorController(IFindCancelledMedicalAppointmentsByDoctorService service)
    {
        _service = service;
    }

    [HttpGet("{doctorLicenseNumber}")]
    public IActionResult Find([Required, StringLength(7)] string doctorLicenseNumber)
    {
        return Ok(_service.Find(doctorLicenseNumber));
    }

}
