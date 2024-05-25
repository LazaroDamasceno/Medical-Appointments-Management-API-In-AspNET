using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;

public interface ICancelMedicalAppointmentService
{
    void Cancel([Required] CancelMedicalAppointmentDTO dto);
}
