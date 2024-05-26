using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Update;

public interface IUpdateDoctorService
{
    void Update([Required] UpdateDoctorDTO dto);
}
