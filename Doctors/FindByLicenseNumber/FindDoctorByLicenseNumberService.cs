using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;

public class FindDoctorByLicenseNumberService : IFindDoctorByLicenseNumberService
{

    private readonly AppDbContext _context;

    public FindDoctorByLicenseNumberService(AppDbContext context)
    {
        _context = context;
    }

    public Doctor Find([Required, StringLength(7)] string doctorLicenseNumber)
    {
        if (!_context.Doctors.Any(e => e.LicenseNumber == doctorLicenseNumber)) 
        {
            throw new DoctorNotFoundException(doctorLicenseNumber);
        }
        return _context.Doctors.First(e => e.LicenseNumber == doctorLicenseNumber);
    }

}
