using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Transfer;

public interface ITransferMedicalAppointmentService
{
    void Transfer([Required] TransferMedicalAppointmentDTO dto);
}
