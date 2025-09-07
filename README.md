# PruebaTecnicaDesarrolladorJuniorPlus

## Descripción

Este proyecto es una solución en .NET 8 para una prueba técnica, estructurada en varias capas: API, Aplicación, Infraestructura y Dominio.

## Paquetes NuGet utilizados

### PruebaTecnica.Api
- Swashbuckle.AspNetCore (v6.6.2)

### PruebaTecnica.Aplication
- Mapster (v7.4.0)
- MediatR (v12.5.0)
- Microsoft.Extensions.Configuration.Abstractions (v9.0.6)
- Microsoft.Extensions.DependencyInjection.Abstractions (v9.0.6)
- Microsoft.Extensions.Options.ConfigurationExtensions (v9.0.6)

### PruebaTecnica.Infrastructure
- Microsoft.EntityFrameworkCore (v9.0.6)
- Microsoft.EntityFrameworkCore.SqlServer (v9.0.6)
- Microsoft.Extensions.Configuration.Abstractions (v9.0.6)
- Microsoft.Extensions.DependencyInjection.Abstractions (v9.0.6)
- Microsoft.Extensions.Identity.Core (v9.0.6)
- Microsoft.Extensions.Options.ConfigurationExtensions (v9.0.6)

## Pasos para ejecutar el proyecto

1. **Clona el repositorio** https://github.com/JFRmoreno/PruebaTecnicaDesarrolladorJuniorPlus
2. **Abre la solución en Visual Studio 2022**

3. **Restaura los paquetes NuGet**
- Visual Studio restaurará los paquetes automáticamente al compilar.
- También puedes usar __Herramientas > Administrador de paquetes NuGet > Restaurar paquetes NuGet__.

4. **Configura la cadena de conexión a la base de datos**
- Modifica el archivo `appsettings.json` en el proyecto `PruebaTecnica.Api` para apuntar a tu instancia de SQL Server.

5. **Compila la solución**
- Usa __Compilar > Compilar solución__.

6. **Ejecuta el proyecto API**
- Establece `PruebaTecnica.Api` como proyecto de inicio.
- Presiona `F5` o usa __Depurar > Iniciar depuración__.

7. **Accede a Swagger UI**
- Una vez ejecutando, navega a `https://localhost:{puerto}/swagger` en tu navegador para explorar la API.

## Notas

- Framework objetivo: .NET 8
- Asegúrate de tener una instancia de SQL Server disponible y accesible para Entity Framework Core.
