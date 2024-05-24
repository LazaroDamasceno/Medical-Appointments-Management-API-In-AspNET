using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsManagementAPI.Patients.FindBySsn;

public interface IFindPatientBySsnService
{
    Patient Find([Required, StringLength(9)] string ssn);
}
