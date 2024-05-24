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
builder.Services.AddScoped<ITransferMedicalAppointmentService, TransferMedicalAppointmentService>();

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
