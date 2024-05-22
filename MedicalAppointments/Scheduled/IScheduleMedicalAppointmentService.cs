using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;

public interface IScheduleMedicalAppointmentService
{
    void Schedule([Required] ScheduleMedicalAppointmentDTO dto);
}
