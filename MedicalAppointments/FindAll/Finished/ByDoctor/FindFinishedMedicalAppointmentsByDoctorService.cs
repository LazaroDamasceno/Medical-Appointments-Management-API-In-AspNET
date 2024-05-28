using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.ValidateDateTimes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByDoctor;

public class FindFinishedMedicalAppointmentsByDoctorService : IFindFinishedMedicalAppointmentsByDoctorService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;
    private readonly IValidateDateTimesService _validateDateTimes;

    public FindFinishedMedicalAppointmentsByDoctorService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumber, IValidateDateTimesService validateDateTimes)
    {
        _context = context;
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
        _validateDateTimes = validateDateTimes;
    }

    public List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber, [Required] BetweenDateTimesDTO dateTimesDTO)
    {
        _validateDateTimes.ValidateDateTimes(dateTimesDTO);
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
                && e.FinishingDateTime != null
                && e.Doctor == doctor
            )];
    }
}
