# ApiNgMovies 🎬

API RESTful desarrollada en ASP.NET Core 9 para la gestión de películas, pensada para integrarse con un frontend Angular. Permite administrar entidades como películas, géneros, actores y cines.

## 🚀 Características

- CRUD completo para:
  - Películas
  - Actores
  - Cines
  - Géneros
- Uso de Entity Framework Core con SQL Server
- Mapeo geoespacial con `NetTopologySuite`
- Inyección de dependencias y servicios personalizados
- Cache de respuestas HTTP
- Soporte para CORS (Cross-Origin Resource Sharing)
- Documentación interactiva con Swagger
- Integración con AutoMapper
- Servidor de archivos estáticos

## 🛠️ Tecnologías utilizadas

- [.NET 9](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [NetTopologySuite](https://nettopologysuite.github.io/)
- [Swashbuckle / Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

## 📁 Estructura del proyecto

```
ApiNgMovies/
├── Controllers/
├── Entidades/
├── Servicios/
├── Utilitario/
├── AppDbContext.cs
├── Program.cs
├── appsettings.json
├── ApiNgMovies.csproj
```

## ⚙️ Configuración

1. Clona el repositorio:
   ```bash
   git clone https://github.com/emanuelarias9/ApiNgMovies.git
   cd ApiNgMovies
   ```

2. Configura tu archivo `appsettings.Development.json` con tu cadena de conexión:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BD;Trusted_Connection=True;"
     },
     "origenesPermitidos": "http://localhost:4200"
   }
   ```

3. Ejecuta migraciones (si usas EF Core CLI):
   ```bash
   dotnet ef database update
   ```

4. Ejecuta la API:
   ```bash
   dotnet run
   ```

## 📦 Endpoints

Accede a la documentación completa de los endpoints en:
```
https://localhost:7066/swagger
```

## 📷 Subida de Archivos

Este proyecto permite la carga y gestión de imágenes en la carpeta `wwwroot`.

## 🔐 Seguridad

Actualmente, la API no implementa autenticación. Se recomienda agregar JWT o IdentityServer para ambientes de producción.

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Puedes usarlo y modificarlo libremente.

---

## ✨ Autor

Emanuel Arias  
Desarrollador Full Stack  
Barranquilla, Colombia
