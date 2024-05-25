using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Reschedule;

public interface IRescheduleMedicalAppointmentService
{
    public void Reschedule([Required] RescheduleMedicalAppointmentDTO dto);
}
