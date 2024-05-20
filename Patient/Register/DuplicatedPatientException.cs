﻿namespace MedicalAppointmentsManagementAPI.Patient.Register;

public class DuplicatedPatientException(string ssn) 
    : Exception($"Patient whose SSN is {ssn} is already self-registred.")
{
}
