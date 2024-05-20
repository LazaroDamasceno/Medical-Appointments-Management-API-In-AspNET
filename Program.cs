using MedicalAppointmentsManagementAPI;
using MedicalAppointmentsManagementAPI.Doctor.FindAll;
using MedicalAppointmentsManagementAPI.Patient.FindAll;
using MedicalAppointmentsManagementAPI.Patient.FindBySsn;
using MedicalAppointmentsManagementAPI.Patient.Register;
using MedicalAppointmentsManagementAPI.Patient.Update;
using MedicalAppointmentsManagementAPI.SystemUser;

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
