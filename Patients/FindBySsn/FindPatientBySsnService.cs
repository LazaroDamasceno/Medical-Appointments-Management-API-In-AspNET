using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.FindBySsn;

public class FindPatientBySsnService : ControllerBase
{

    private readonly AppDbContext _context;

    public FindPatientBySsnService(AppDbContext context)
    {
        _context = context;
    }

    public Patient Find([Required, StringLength(9)] string ssn)
    {
        var user = _context.SystemUsers.FirstOrDefault(e => e.Ssn == ssn);
        if (user is null)
        {
            throw new PatientNotExeception(ssn);
        }
        return _context.Patients.First(e => e.SystemUser == user);
    }

}
