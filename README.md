# PruebaTecnicaDesarrolladorJuniorPlus

## Descripción

Este proyecto es una solución en .NET 8 para una prueba técnica, estructurada en varias capas: API, Aplicación, Infraestructura y Dominio. Permite la gestión de productos mediante operaciones CRUD, siguiendo buenas prácticas de arquitectura y desarrollo en .NET.

## Estructura del Proyecto

- **PruebaTecnica.Api**: Exposición de endpoints RESTful para la gestión de productos. Incluye Swagger para documentación y pruebas.
- **PruebaTecnica.Aplication**: Lógica de negocio, servicios y DTOs. Utiliza patrones como CQRS y Mediator.
- **PruebaTecnica.Infrastructure**: Implementación de acceso a datos con Entity Framework Core y configuración de dependencias.
- **PruebaTecnica.Domain**: Entidades y contratos de dominio.
- **PruebaTecnica.Test**: Pruebas unitarias, usando MSTest y Moq.

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

### PruebaTecnica.Test
- MSTest (v3.6.4)
- Moq (v4.20.72)
- Microsoft.NET.Test.Sdk (v17.12.0)

## Pruebas Unitarias

- Las capas cuentan con pruebas unitarias siguiendo las prácticas de MSTest y Moq.
- Se cubren escenarios exitosos, errores, nulos y excepciones.
- Los DTOs y entidades se instancian con valores de prueba en cada test.
- Para ejecutar las pruebas, usa __Prueba > Ejecutar todas las pruebas__ en Visual Studio.

## Pasos para ejecutar el proyecto

1. **Clona el repositorio**  
   [https://github.com/JFRmoreno/PruebaTecnicaDesarrolladorJuniorPlus](https://github.com/JFRmoreno/PruebaTecnicaDesarrolladorJuniorPlus)

2. **Ejecuta los scripts en la base de datos**  
   [https://github.com/JFRmoreno/Script-SQL-Server-](https://github.com/JFRmoreno/Script-SQL-Server-)
3. **Dirigete al siguiente repositorio**
https://github.com/JFRmoreno/PruebaTecnicaDesarrolladorJuniorPlusAngular   
4. **Abre la solución en Visual Studio 2022**

5. **Restaura los paquetes NuGet**
   - Visual Studio restaurará los paquetes automáticamente al compilar.
   - También puedes usar __Herramientas > Administrador de paquetes NuGet > Restaurar paquetes NuGet__.

6. **Configura la cadena de conexión a la base de datos**
   - Modifica el archivo `appsettings.Development` en el proyecto `PruebaTecnica.Api` para apuntar a tu instancia de SQL Server.

7. **Compila la solución**
   - Usa __Compilar > Compilar solución__.

8. **Ejecuta el proyecto API**
   - Establece `PruebaTecnica.Api` como proyecto de inicio.
   - Presiona `F5` o usa __Depurar > Iniciar depuración__.

9. **Accede a Swagger UI**
   - Una vez ejecutando, navega a `https://localhost:{puerto}/swagger` en tu navegador para explorar la API.

## Buenas Prácticas Implementadas

- Inyección de dependencias en todas las capas.
- Separación de responsabilidades y uso de DTOs.
- Pruebas unitarias exhaustivas y documentadas.
- Uso de patrones CQRS y Mediator para la lógica de negocio.
- Configuración centralizada y segura de la cadena de conexión.

## Notas

- Framework objetivo: .NET 8
- Asegúrate de tener una instancia de SQL Server disponible y accesible para Entity Framework Core.
- El proyecto está listo para ampliarse y adaptarse a nuevas funcionalidades siguiendo la arquitectura propuesta.
