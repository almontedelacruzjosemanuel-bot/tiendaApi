# tiendaApi

API REST desarrollada con ASP.NET Core y .NET 10 para la gestión de productos de una tienda.

El proyecto utiliza Dapper para el acceso a datos, SQL Server/Azure SQL Database como sistema de almacenamiento y Azure App Service para el despliegue de la aplicación.

## Tecnologías utilizadas

* C#
* .NET 10
* ASP.NET Core Web API
* Dapper 2.1.79
* Microsoft.Data.SqlClient 7.0.2
* SQL Server
* Azure SQL Database
* Azure App Service
* GitHub Actions
* GitHub
* REST API

## Funcionalidades

La API permite realizar las operaciones básicas de un CRUD sobre productos:

* Obtener todos los productos
* Obtener un producto por su ID
* Crear un producto
* Actualizar un producto
* Eliminar un producto

## Arquitectura del proyecto

```text
tiendaApi/
│
├── Controllers/
│   └── ProductosController.cs
│
├── Data/
│   ├── DbConnection.cs
│   └── ProductoRepository.cs
│
├── Models/
│   └── Producto.cs
│
├── Properties/
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── tiendaApi.csproj
├── tiendaApi.http
├── .gitignore
└── README.md
```

### Controllers

Contiene los controladores de la API. Los controladores reciben las solicitudes HTTP y utilizan el repositorio para ejecutar las operaciones correspondientes.

### Data

Contiene las clases relacionadas con el acceso a datos.

`DbConnection.cs` se encarga de crear las conexiones con SQL Server.

`ProductoRepository.cs` contiene las consultas SQL y utiliza Dapper para interactuar con la base de datos.

### Models

Contiene los modelos utilizados por la aplicación.

El modelo principal es `Producto`.

```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}
```

## Base de datos

La aplicación utiliza una base de datos llamada `tiendaApiDB` en Azure SQL Database.

La tabla principal es `Productos`.

```sql
CREATE TABLE Productos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);
```

Datos utilizados para las pruebas:

```sql
INSERT INTO Productos (Nombre, Precio, Stock)
VALUES
('Mouse Logitech', 25.50, 30),
('Teclado Logitech', 40.00, 15),
('Monitor Samsung', 250.00, 10);
```

## Endpoints

La ruta principal de productos es:

```text
/api/productos
```

### Obtener todos los productos

```http
GET /api/productos
```

Ejemplo de respuesta:

```json
[
    {
        "id": 1,
        "nombre": "Mouse Logitech",
        "precio": 25.50,
        "stock": 30
    },
    {
        "id": 2,
        "nombre": "Teclado Logitech",
        "precio": 40.00,
        "stock": 15
    },
    {
        "id": 3,
        "nombre": "Monitor Samsung",
        "precio": 250.00,
        "stock": 10
    }
]
```

### Obtener un producto por ID

```http
GET /api/productos/{id}
```

Ejemplo:

```http
GET /api/productos/1
```

### Crear un producto

```http
POST /api/productos
```

Body:

```json
{
    "nombre": "Laptop Lenovo",
    "precio": 750.00,
    "stock": 8
}
```

### Actualizar un producto

```http
PUT /api/productos/{id}
```

Ejemplo:

```http
PUT /api/productos/1
```

Body:

```json
{
    "nombre": "Mouse Logitech G502",
    "precio": 55.00,
    "stock": 20
}
```

### Eliminar un producto

```http
DELETE /api/productos/{id}
```

Ejemplo:

```http
DELETE /api/productos/1
```

## Pruebas con VS Code

El proyecto incluye el archivo `tiendaApi.http`, que permite realizar solicitudes HTTP directamente desde Visual Studio Code utilizando la extensión REST Client.

Ejemplo:

```http
@tiendaApi_HostAddress = https://tiendaapi-fvanc4hhezd2fpa4.centralus-01.azurewebsites.net/api

### Obtener todos los productos
GET {{tiendaApi_HostAddress}}/productos
Accept: application/json

### Obtener un producto
GET {{tiendaApi_HostAddress}}/productos/1
Accept: application/json

### Crear producto
POST {{tiendaApi_HostAddress}}/productos
Content-Type: application/json

{
    "nombre": "Laptop Lenovo",
    "precio": 750.00,
    "stock": 8
}

### Actualizar producto
PUT {{tiendaApi_HostAddress}}/productos/1
Content-Type: application/json

{
    "nombre": "Mouse Logitech G502",
    "precio": 55.00,
    "stock": 20
}

### Eliminar producto
DELETE {{tiendaApi_HostAddress}}/productos/1
```

## Configuración de la conexión

Para el entorno local se utiliza SQL Server Express.

El archivo `appsettings.json` contiene la configuración para la conexión local:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=.\\SQLEXPRESS;Database=tiendaApi;Trusted_Connection=True;TrustServerCertificate=True;"
    }
}
```

En Azure App Service, la conexión a Azure SQL Database se configura mediante una variable de entorno:

```text
ConnectionStrings__DefaultConnection
```

La conexión de producción se configura directamente en Azure y las credenciales no se almacenan en el repositorio.

## Despliegue en Azure

La API está desplegada utilizando Azure App Service.

Recursos utilizados:

```text
Azure
│
├── Resource Group
│   └── Azure-test
│
├── App Service
│   └── tiendaApi
│
├── App Service Plan
│   └── ASP-Azuretest-877c
│
├── SQL Server
│   └── tiendapi.database.windows.net
│
└── SQL Database
    └── tiendaApiDB
```

URL de la API desplegada:

```text
https://tiendaapi-fvanc4hhezd2fpa4.centralus-01.azurewebsites.net
```

Endpoint principal:

```text
https://tiendaapi-fvanc4hhezd2fpa4.centralus-01.azurewebsites.net/api/productos
```

## Paquetes principales

El proyecto utiliza los siguientes paquetes:

```text
Dapper 2.1.79
Microsoft.Data.SqlClient 7.0.2
Microsoft.AspNetCore.OpenApi 10.0.11
```

### Dapper

Dapper se utiliza como micro ORM para ejecutar consultas SQL y mapear los resultados de la base de datos a objetos de C#.

### Microsoft.Data.SqlClient

Se utiliza para establecer las conexiones con SQL Server y Azure SQL Database.

## Conceptos aplicados

Durante el desarrollo del proyecto se aplicaron los siguientes conceptos:

* Desarrollo de APIs REST
* ASP.NET Core
* Inyección de dependencias
* Patrón Repository
* Dapper
* SQL Server
* Azure SQL Database
* Azure App Service
* Variables de entorno
* Git
* GitHub
* GitHub Actions
* Integración
* Despliegue
* Operaciones CRUD

## Objetivo del proyecto

El objetivo del proyecto es desarrollar una API REST sencilla utilizando .NET y C#, conectarla a una base de datos mediante Dapper y realizar su despliegue en Microsoft Azure.

El proyecto sirve como práctica para comprender el desarrollo de APIs, acceso a datos, bases de datos SQL, control de versiones y procesos de despliegue en la nube.

## Autor

José Manuel De La Cruz Almonte 100628387
