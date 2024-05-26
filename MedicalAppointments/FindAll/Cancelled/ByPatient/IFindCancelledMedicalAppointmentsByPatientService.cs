using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled.ByPatient;

public interface IFindCancelledMedicalAppointmentsByPatientService
{
    List<MedicalAppointment> Find([Required, StringLength(9)] string ssn);
}
