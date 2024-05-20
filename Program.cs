using MedicalAppointmentsManagementAPI;
using MedicalAppointmentsManagementAPI.Doctors.FindAll;
using MedicalAppointmentsManagementAPI.Doctors.FindByLicenseNumber;
using MedicalAppointmentsManagementAPI.Doctors.Hire;
using MedicalAppointmentsManagementAPI.Doctors.Terminate;
using MedicalAppointmentsManagementAPI.Doctors.Update;
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
builder.Services.AddTransient<UpdateSystemUserService>();
builder.Services.AddTransient<UpdatePatientService>();
builder.Services.AddTransient<SelfRegisterPatientService>();
builder.Services.AddTransient<FindPatientBySsnService>();
builder.Services.AddTransient<FindAllPatientsService>();
builder.Services.AddTransient<FindAllDoctorsService>();
builder.Services.AddTransient<HireDoctorService>();
builder.Services.AddTransient<TerminateDoctorService>();
builder.Services.AddTransient<FindDoctorByLicenseNumberService>();
builder.Services.AddTransient<UpdateDoctorService>();

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
