# ModularMonolithTemplate

Plantilla base para desarrollar aplicaciones empresariales con arquitectura de monolito modular en .NET, con enfoque en separación de módulos de negocio, escalabilidad y preparación para microservicios.

---

## ✨ Características principales

- Arquitectura modular con separación clara por bounded context
- Clean Architecture y CQRS con MediatR
- Entity Framework Core 9 (Code First)
- Identity con soporte para 2FA
- SignalR para notificaciones en tiempo real
- Patrón Outbox para consistencia eventual entre módulos
- Logging estructurado con Serilog

---

## 🚀 Primeros pasos

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tuusuario/ModularMonolithTemplate.git
   cd ModularMonolithTemplate
   ```

2. Restaura los paquetes NuGet:

   ```bash
   dotnet restore
   ```

3. Ejecuta las migraciones y levanta la base de datos:

   ```bash
   dotnet ef database update --project src/Modules/{ModuleName}/ModularMonolithTemplate.{ModuleName}.Infrastructure
   ```

4. Ejecuta el proyecto:

   ```bash
   dotnet run --project src/Presentation/API/ModularMonolithTemplate.API
   ```

---

## ✅ Pendiente / En desarrollo

- Panel de administración para revisar eventos fallidos del Outbox
- UI con integración en tiempo real de notificaciones via SignalR
- Soporte completo para reintento y auditoría de eventos técnicos

---
