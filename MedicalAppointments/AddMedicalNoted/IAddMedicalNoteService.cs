using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;

public interface IAddMedicalNoteService
{
    void AddMedicalNoted([Required] MedicalNoteDTO dto);
}
