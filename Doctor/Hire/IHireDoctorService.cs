using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctor.Hire;

public interface IHireDoctorService
{
    void Hire([Required] HireDoctorDTO dto);
}
