using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled;

public class FindCancelledMedicalAppointmentsByDoctorService : IFindCancelledMedicalAppointmentsByDoctorService
{

    private readonly AppDbContext _context;
    private readonly IFindDoctorByLicenseNumberService _findDoctorByLicenseNumber;

    public FindCancelledMedicalAppointmentsByDoctorService(AppDbContext context, IFindDoctorByLicenseNumberService findDoctorByLicenseNumber)
    {
        _context = context;
        _findDoctorByLicenseNumber = findDoctorByLicenseNumber;
    }

    public List<MedicalAppointment> Find([Required, StringLength(7)] string doctorLicenseNumber)
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
                e => e.Doctor == doctor
                && e.CancelledDateTime != null
            )
        ];
    }

}
