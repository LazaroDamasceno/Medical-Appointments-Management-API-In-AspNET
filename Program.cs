using MedicalAppointmentsManagementAPI;
using MedicalAppointmentsManagementAPI.Doctors.FindAll;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Doctors.Hire;
using MedicalAppointmentsManagementAPI.Doctors.Terminate;
using MedicalAppointmentsManagementAPI.Doctors.Update;
using MedicalAppointmentsManagementAPI.MedicalAppointments;
using MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Cancelled.ByPatient;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByDoctor;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Finished.ByPatient;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByDoctor;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.Scheduled.ByPatient;
using MedicalAppointmentsManagementAPI.MedicalAppointments.FindAll.ValidateDateTimes;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Reschedule;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.Patients.FindAll;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using MedicalAppointmentsManagementAPI.Patients.Register;
using MedicalAppointmentsManagementAPI.Patients.Update;
using MedicalAppointmentsManagementAPI.SystemUsers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ISelfRegisterPatientService, SelfRegisterPatientService>();
builder.Services.AddScoped<IFindPatientBySsnService, FindPatientBySsnService>();
builder.Services.AddScoped<IFindAllPatientsService, FindAllPatientsService>();
builder.Services.AddScoped<IFindAllDoctorsService, FindAllDoctorsService>();
builder.Services.AddScoped<IHireDoctorService, HireDoctorService>();
builder.Services.AddScoped<ITerminateDoctorService, TerminateDoctorService>();
builder.Services.AddScoped<IFindDoctorByLicenseNumberService, FindDoctorByLicenseNumberService>();
builder.Services.AddScoped<IFindMedicalAppointmentService, FindMedicalAppointmentService>();
builder.Services.AddScoped<ICancelMedicalAppointmentService, CancelMedicalAppointmentService>();
builder.Services.AddScoped<IAddMedicalNoteService, AddMedicalNoteService>();
builder.Services.AddScoped<IScheduleMedicalAppointmentService, ScheduleMedicalAppointmentService>();
builder.Services.AddScoped<IRescheduleMedicalAppointmentService, RescheduleMedicalAppointmentService>();
builder.Services.AddScoped<IUpdatePatientService, UpdatePatientService>();
builder.Services.AddScoped<IUpdateDoctorService, UpdateDoctorService>();
builder.Services.AddScoped<IFindAllMedicalAppointmentsService, FindAllMedicalAppointmentsService>();
builder.Services.AddScoped<IFindCancelledMedicalAppointmentsByDoctorService, FindCancelledMedicalAppointmentsByDoctorService>();
builder.Services.AddScoped<IFindCancelledMedicalAppointmentsByPatientService, FindCancelledMedicalAppointmentsByPatientService>();
builder.Services.AddScoped<IFindScheduledMedicalAppointmentsByPatientService, FindScheduledMedicalAppointmentsByPatientService>();
builder.Services.AddScoped<IFindScheduledMedicalAppointmentsByDoctorService, FindScheduledMedicalAppointmentsByDoctorService>();
builder.Services.AddScoped<IFindFinishedMedicalAppointmentsByPatientService, FindFinishedMedicalAppointmentsByPatientService>();
builder.Services.AddScoped<IFindFinishedMedicalAppointmentsByDoctorService, FindFinishedMedicalAppointmentsByDoctorService>();
builder.Services.AddScoped<IValidateDateTimesService, ValidateDateTimesService>();
builder.Services.AddScoped<ISystemUserBuilder, SystemUserBuilder>();
builder.Services.AddScoped<IPatientBuilder, PatientBuilder>();
builder.Services.AddScoped<IDoctorBuilder, DoctorBuilder>();
builder.Services.AddScoped<IMedicalAppointmentBuilder, MedicalAppointmentBuilder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
