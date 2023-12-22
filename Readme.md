# C# Atmira Test
***
#Jairo Andres Camargo Vargas

## Table of Contents
1. [General Info](#general-info)
2. [Technologies](#technologies)
3. [Installation](#installation)

## Table of Contents
<a name="general-info"></a>

## General Info
***
* Se hizo la aplicación con una arquitectura a capas segmentando cada parte de la aplicación.
* Se uso inyección de dependencias para des-acoplar las capas.
* Se implementó el patrón repository para la base de datos.
* Se implementó un ORM para la conexión de bases de datos. 
* En su seguridad se uso JWT para su autenticación.



## Technologies
***
Estas son las tecnologias que se usaron:
* Automapper
* Entityframework
* IOC
* Microsoft.AspNetCore.Mvc.Versioning

## Installation
***
Para la instalación tiene que ejecutar los siguientes comandos,
* Restaurar las dependencias
* Limpiar el proyecto
* Compilar
* Entrar al proyecto de la base de datos
* Persistir la base de datos 
```
$ dotnet restore
$ dotnet clean
$ dotnet build
$ cd Database/
$ dotnet ef database update
```