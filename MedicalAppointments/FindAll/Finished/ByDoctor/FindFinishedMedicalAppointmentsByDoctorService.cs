using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByDoctor;

public class FindFinishedMedicalAppointmentsByDoctorService : IFindFinishedMedicalAppointmentsByDoctorService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;

    public FindFinishedMedicalAppointmentsByDoctorService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumber)
    {
        _context = context;
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
    }

    public List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber, [Required] BetweenDateTimesDTO dateTimesDTO)
    {
        Doctor doctor = _findDoctorByLicenseNumber.Find(doctorLicenseNumber);
        return [
            .. _context
            .MedicalAppointments
            .Include(e => e.Patient)
            .Include(e => e.Doctor)
            .Include(e => e.Patient.SystemUser)
            .Include(e => e.Doctor.SystemUser)
            .Where(
                e => e.ScheduledDateTime <= dateTimesDTO.FirstDateTime
                && e.ScheduledDateTime >= dateTimesDTO.LastDateTime
                && e.Doctor == doctor
            )];
    }
}
