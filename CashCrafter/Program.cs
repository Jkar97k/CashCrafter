
using CashCrafter.Repository;
using CashCrafter.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder options) =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

//Repositorios
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUbicacionRepository,UbicacionRepository>();
builder.Services.AddScoped<ITipoPagoRepository, TipoPagoRepository>();
builder.Services.AddScoped<ITipoIngresoRepository, TipoIngresoRepository>();
builder.Services.AddScoped<ITipoAhorroRepository,TipoAhorroRepository>();
builder.Services.AddScoped<IIngresoRepository, IngresoRepository>();
builder.Services.AddScoped<IGastosrRepository, GastosrRepository>();
builder.Services.AddScoped<IGastoRepository, GastoRepository>();
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();

//Servicios
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUbicacionService,UbicacionService>();
builder.Services.AddScoped<ITipoPagoService, TipoPagoService>();
builder.Services.AddScoped<ITipoIngresoService, TipoIngresoService>();
builder.Services.AddScoped<ITipoAhorroService, TipoAhorroService>();
builder.Services.AddScoped<IIngresoService, IngresoService>();
builder.Services.AddScoped<IGastosRService, GastosRService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<IClaseService, ClaseService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
