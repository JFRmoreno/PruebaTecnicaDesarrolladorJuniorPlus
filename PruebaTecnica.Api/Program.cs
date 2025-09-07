using PruebaTecnica.Aplication;
using PruebaTecnica.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores.
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios de la capa de aplicación con la configuración.
builder.Services.AddAplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configurar el pipeline de la aplicación.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
