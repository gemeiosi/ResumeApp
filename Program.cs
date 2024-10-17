using Microsoft.EntityFrameworkCore;
using ResumeApp.Data.Interfaces;
using ResumeApp.Data.Services;
using ResumeApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICandidateService, CandidateService>();
builder.Services.AddTransient<IDegreeService, DegreeService>();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("ResumeMngDB")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
