using EvalySI_App.Data;
using Microsoft.AspNetCore.Session;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Obtener la cadena de conexión
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Registrar TODOS los DAOs para inyección de dependencias
builder.Services.AddScoped<daoDatosGenerales>(_ => new(connectionString));
builder.Services.AddScoped<daoEstudios>(_ => new(connectionString));
builder.Services.AddScoped<daoHistorialLaboral>(_ => new(connectionString));
builder.Services.AddScoped<daoEconomia>(_ => new(connectionString));
builder.Services.AddScoped<daoSalud>(_ => new(connectionString));
builder.Services.AddScoped<daoLegal>(_ => new(connectionString));
builder.Services.AddScoped<daoPsicologia>(_ => new(connectionString));
builder.Services.AddScoped<daoConclusiones>(_ => new(connectionString));
builder.Services.AddScoped<daoAdmin>(_ => new(connectionString));
builder.Services.AddScoped<daoLogin>(_ => new(connectionString));



// Configuración para usar Sesiones
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // La sesión expira después de 60 minutos de inactividad
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseSession(); // Habilitar el middleware de sesión

app.UseAuthentication(); // Autenticación
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Index}/{id?}");

app.Run();
