using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public interface IHireDoctorService
{
    void Hire([Required] HireDoctorDTO dto);
}
