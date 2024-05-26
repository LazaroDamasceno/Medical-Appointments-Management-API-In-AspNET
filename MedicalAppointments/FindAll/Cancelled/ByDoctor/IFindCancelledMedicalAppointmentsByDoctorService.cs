using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled;

public interface IFindCancelledMedicalAppointmentsByDoctorService
{
    List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber);
}
