namespace MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;

public class FinishedMedicalAppointmentException(string doctorLicenseNumber, DateTime dateTime)
    : Exception($"""
                    Medical appointment whose doctor's license number is {doctorLicenseNumber} and scheduled date time is {dateTime} already has medical notes.
               """)
{  }