using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;

public interface ICancelMedicalAppointmentService
{
    void Cancel(
        [Required, StringLength(9)] string ssn, 
        [Required, StringLength(7)] string doctorLicenseNumber, 
        [Required] DateTime scheduledDateTime
    );
}
