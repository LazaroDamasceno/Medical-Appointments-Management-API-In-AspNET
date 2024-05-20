namespace MedicalAppointmentsManagementAPI.Patient.FindBySsn;

public class PatientNotExeception(string ssn) 
    : Exception($"Patient who SSN is {ssn} was not found.")
{
}
