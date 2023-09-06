using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DataLayer;
using SchoolManagementSystem.DataLayer.Repositories.Classes;
using SchoolManagementSystem.DataLayer.Repositories.Students;
using SchoolManagementSystem.DataLayer.Repositories.StudentsClasses;
using SchoolManagementSystem.DataLayer.Repositories.Subjects;
using SchoolManagementSystem.DataLayer.Repositories.Teachers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentClassRepository, StudentClassRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();