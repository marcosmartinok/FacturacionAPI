# Sistema de Gestión de Facturas

Este repositorio contiene una aplicación de gestión de facturas, personas y empresas diseñada utilizando Entity Framework Core para la persistencia de datos. La solución está dividida en dos proyectos principales, ambos utilizando .NET 6.0.

## Estructura de la Solución

La solución se compone de los siguientes proyectos:

- `FacturasABM`: Un proyecto ASP.NET Core que contiene los controladores.
- `FacturasABM.Core`: Una biblioteca de clases (Class Library) que contiene las entidades, la lógica de la API y servicios.

## Entidades

Basándose en el diagrama de clases proporcionado, el sistema maneja las siguientes entidades:

- `Persona`: Representa a una persona física con su información personal.
- `Empresa`: Representa a una entidad empresarial con su información correspondiente.
- `Factura`: Contiene la información de las facturas emitidas tanto para personas como empresas.
- `LineaFactura`: Detalla los ítems individuales que componen una factura.

## Características

- ABM (Alta, Baja, Modificación) de Personas y Empresas.
- Creación y gestión de Facturas.
- Asociación de Facturas con Personas o Empresas.
- Gestión de líneas de detalle de cada Factura.

## Tecnologías Utilizadas

- ASP.NET Core 6.0 para la creación de endpoints de la API.
- Entity Framework Core 6.0 para el ORM (Object-Relational Mapping) y manejo de la base de datos.
- DTOs (Data Transfer Objects) para la transferencia de datos en la creación de facturas.
