using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;

[ApiController]
[Route("api/v1/medical-appointments")]
public class FindAllMedicalAppointmentsController : ControllerBase
{

    private readonly IFindAllMedicalAppointmentsService _service;

    public FindAllMedicalAppointmentsController(IFindAllMedicalAppointmentsService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<MedicalAppointment> FindAll()
    {
        return _service.FindAll();
    }
}
