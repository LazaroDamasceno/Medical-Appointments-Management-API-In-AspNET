﻿namespace MedicalAppointmentsManagementAPI.Doctors.Hire;

public class DuplicatedSsnException(string ssn) : 
    Exception($"SSN who number is {ssn} already exist.")
{
}
