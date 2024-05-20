using MedicalAppointmentsManagementAPI.SystemUsers;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;

public interface IDoctorUpdateService
{
    void Update([Required, StringLength(7)] string doctorLicenseNumber, [Required] UpdateSystemUserDTO dto);
}
