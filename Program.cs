using Microsoft.EntityFrameworkCore;
using Sessions_app.Data;
using Sessions_app.Service;
using Sessions_app.Services;
using Sessions_app.Models;
using Sessions_app.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add session configuration
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.Name = "_ApplicationSession";
    options.Cookie.IsEssential = true;
});

// Configure database context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});

// Add repositories and services
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<PacienteService>();

// Add Medico services
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<MedicoService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

// Configure routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "customRoute",
    pattern: "{controller=Paciente}/{action=Index}/{id?}");

app.Run();