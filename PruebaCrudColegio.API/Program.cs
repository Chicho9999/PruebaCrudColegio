using Microsoft.EntityFrameworkCore;
using PruebaCrudColegio.Application;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure;
using PruebaCrudColegio.Infrastructure.Repositories;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddScoped<PruebaCrudColegioContext>();

//Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentGradeService, StudentGradeService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();

//Repositories
builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<Grade>, Repository<Grade>>();
builder.Services.AddScoped<IRepository<StudentGrade>, Repository<StudentGrade>>();
builder.Services.AddScoped<IRepository<Professor>, Repository<Professor>>();

builder.Services.AddDbContext<PruebaCrudColegioContext>(options =>
{
    options.UseSqlServer();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

app.UseAuthorization();

app.MapControllers();

app.Run();
