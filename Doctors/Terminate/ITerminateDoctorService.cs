using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Terminate;

public interface ITerminateDoctorService
{
    void Terminate([Required, StringLength(7)] string doctorLicenseNumber);
}
