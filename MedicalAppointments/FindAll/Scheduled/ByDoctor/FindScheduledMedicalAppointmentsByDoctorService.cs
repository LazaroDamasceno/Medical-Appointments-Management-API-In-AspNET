﻿using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.ValidateDateTimes;
using MedicalAppointmentsManagementAPI.Patients;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByDoctor;

public class FindScheduledMedicalAppointmentsByDoctorService : IFindScheduledMedicalAppointmentsByDoctorService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumberService;
    private readonly IValidateDateTimesService _validateDateTimes;

    public FindScheduledMedicalAppointmentsByDoctorService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumberService, IValidateDateTimesService validateDateTimes)
    {
        _context = context;
        _findDoctorByLicenseNumberService = findDoctorByLicenseNumberService;
        _validateDateTimes = validateDateTimes;
    }

    public List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber, [Required] BetweenDateTimesDTO dateTimesDTO)
    {
        _validateDateTimes.ValidateDateTimes(dateTimesDTO);
        Doctor doctor = _findDoctorByLicenseNumberService.Find(doctorLicenseNumber);
        return [
            .. _context
            .MedicalAppointments
            .Include(e => e.Patient)
            .Include(e => e.Doctor)
            .Include(e => e.Patient.SystemUser)
            .Include(e => e.Doctor.SystemUser)
            .Where(
                e => e.ScheduledDateTime >= dateTimesDTO.FirstDateTime
                && e.ScheduledDateTime <= dateTimesDTO.LastDateTime
                && e.FinishingDateTime == null
                && e.CancelledDateTime == null
                && e.Doctor == doctor
            )];
    }

}
