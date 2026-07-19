using Microsoft.EntityFrameworkCore;
using SistemaAula.Infrastructure.Contexto;
using SistemaAula.Infrastructure.Repositorio;

var builder = WebApplication.CreateBuilder(args);


// Conexión con la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// Registrar repositorio genérico
builder.Services.AddScoped(typeof(GenericRepositorio<>));


// Agregar controladores
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configuración de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();