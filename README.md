# TaskManager Application

Esta es una guía para configurar y ejecutar la aplicación TaskManager en tu entorno local.

## Requisitos Previos

Asegúrate de tener instalados los siguientes requisitos previos antes de continuar:

- Node.js y npm (Node Package Manager).
- Angular CLI.
- .NET SDK.
- SQL Server.

## Configuración del Backend (.NET)

1. Clona el repositorio desde GitHub:  
``` git clone https://github.com/Yair-Martinez/DMS-PruebaTecnica.git ```

2. Navega al directorio del backend:  
``` cd TaskManager.Backend/TaskManager.Backend ```

3. Abre el archivo appsettings.json y configura la cadena de conexión a tu base de datos SQL Server.

4. Ejecuta las migraciones para crear la base de datos:  
``` dotnet ef database update ```

5. Inicia el servidor backend:  
``` dotnet run ```

El servidor se ejecutará en http://localhost:{PORT} (El puerto puede variar).  


## Configuración del Frontend (Angular)

1. Navega al directorio del frontend:  
``` cd TaskManager.Frontend ```

2. Instala las dependencias:  
``` npm install ```

3. Abre el archivo src/environments/environment.ts y configura la URL de la API backend.  

``` 
export const environment = {
  production: false,
  apiUrl: 'http://localhost:{PORT}', // URL de la API backend
}; 
```

4. Inicia la aplicación frontend:  
``` ng serve ```

El frontend estará disponible en http://localhost:4200.  


## Uso de la Aplicación
Ahora puedes acceder a la aplicación TaskManager en tu navegador web:  

- Frontend: http://localhost:4200
- Backend API: http://localhost:{PORT}

Asegúrate de que tanto el backend como el frontend estén en funcionamiento antes de utilizar la aplicación.

## Problemas y Contribuciones
Si encuentras problemas o deseas contribuir a este proyecto, por favor crea un informe de problemas en GitHub o envía una solicitud de extracción.
