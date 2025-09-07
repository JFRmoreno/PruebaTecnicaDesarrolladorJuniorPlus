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

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configurar el pipeline de la aplicación.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();