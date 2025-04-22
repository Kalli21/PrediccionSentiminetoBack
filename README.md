# 📘 Documentación Técnica - Microservicio Gestión de Usuarios y Recursos

## 1. 🎯 Arquitectura

Este proyecto forma parte de una arquitectura basada en microservicios con comunicación RESTful. En el diagrama general del sistema se representa su posición, sin embargo, este documento se enfoca únicamente en el microservicio **Gestión de Usuarios y Recursos**.

### Documentacion del proyecto
https://drive.google.com/file/d/1xGRBZ0t0xa359LaO3jlxRNwKjo2M6xZR/view?usp=sharing
---

## 2. 🧩 Patron de diseño

El patrón de diseño utilizado es **MVC** (Modelo - Vista - Controlador), complementado con **DTOs** para la transferencia de datos. Los principales componentes que aplican este patrón son: Archivo, Categoría, Cliente, Comentario, Producto y Usuario.

---

## 3. ⚙️ Instalación y Configuración

### 3.1 Requisitos Previos

- [.NET 6 SDK]
- SQL Server (si se utiliza la base de datos en entorno local)
- Acceso a **user secrets** si se emplean claves/configuraciones sensibles

### 3.2 Instalación


# Clona el repositorio
git clone https://github.com/Kalli21/PrediccionSentiminetoBack.git
cd PrediccionSentiminetoBack

# Restaura los paquetes NuGet
dotnet restore

# Aplica migraciones (si corresponde)
dotnet ef database update

# Corre el proyecto
dotnet run
