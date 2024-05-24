using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Doctors.Terminate;

public class TerminateDoctorService : ITerminateDoctorService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumberService;

    public TerminateDoctorService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumberService)
    {
        _context = context;
        _findDoctorByLicenseNumberService = findDoctorByLicenseNumberService;
    }

    public void Terminate([Required, StringLength(7)] string doctorLicenseNumber)
    {
        Doctor doctor = _findDoctorByLicenseNumberService.Find(doctorLicenseNumber);
        if (doctor.TerminationDateTime is not null) 
        {
            throw new DoctorTerminationException(doctorLicenseNumber);
        }
        doctor.Terminate();
        _context.Update(doctor);
        _context.SaveChanges();
    }

}
