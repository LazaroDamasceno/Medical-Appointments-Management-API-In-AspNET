using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;

public interface IFindDoctorByLicenseNumberService
{
    Doctor Find([Required, StringLength(7)] string doctorLicenseNumber);
}
