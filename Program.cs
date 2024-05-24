using MedicalAppointmentsManagementAPI;
using MedicalAppointmentsManagementAPI.Doctors.FindAll;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Doctors.Hire;
using MedicalAppointmentsManagementAPI.Doctors.Terminate;
using MedicalAppointmentsManagementAPI.MedicalAppointments.AddMedicalNoted;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Cancel;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Find;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Scheduled;
using MedicalAppointmentsManagementAPI.MedicalAppointments.Transfer;
using MedicalAppointmentsManagementAPI.Patients.FindAll;
using MedicalAppointmentsManagementAPI.Patients.FindBySsn;
using MedicalAppointmentsManagementAPI.Patients.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<SelfRegisterPatientService>();
builder.Services.AddScoped<FindPatientBySsnService>();
builder.Services.AddScoped<FindAllPatientsService>();
builder.Services.AddScoped<FindAllDoctorsService>();
builder.Services.AddScoped<HireDoctorService>();
builder.Services.AddScoped<TerminateDoctorService>();
builder.Services.AddScoped<FindDoctorByLicenseNumberService>();
builder.Services.AddScoped<FindMedicalAppointmentService>();
builder.Services.AddScoped<CancelMedicalAppointmentService>();
builder.Services.AddScoped<AddMedicalNoteService>();
builder.Services.AddScoped<ScheduleMedicalAppointmentService>();
builder.Services.AddScoped<TransferMedicalAppointmentService>();

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
