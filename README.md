# 🖥️ UaiOS - Sistema Operativo Multiusuario en C#

## 📘 Descripción General

**UaiOS** es un sistema operativo multiusuario desarrollado en C# que permite a distintos clientes conectarse a una única instancia en la nube para manipular un sistema de archivos virtual a través de una consola de línea de comandos (CLI).

Este proyecto fue desarrollado como parte de la evaluación práctica para la materia **Ingeniería de Software** en la Universidad Abierta Interamericana.

Cada usuario cuenta con un entorno privado donde puede gestionar archivos y directorios utilizando comandos similares a los de sistemas operativos reales.

---

## 🧠 Patrones de Diseño Aplicados

- [**Singleton**](https://refactoring.guru/design-patterns/singleton)  
  Utilizado para el manejo de sesión del usuario. Solo puede haber una instancia de sesión activa durante el uso del sistema.

- [**Composite**](https://refactoring.guru/design-patterns/composite)  
  Implementado para modelar la estructura jerárquica de archivos y directorios. Permite tratar de forma uniforme tanto archivos como carpetas.


---

## 🛠️ Funcionalidades Implementadas

Una vez autenticado, el usuario accede a una consola interactiva donde puede ingresar comandos del sistema operativo virtual:

### Comandos disponibles:

| Comando                     | Descripción                                                                 |
|----------------------------|-----------------------------------------------------------------------------|
| `MD <nombre>`              | Crea un nuevo directorio dentro del directorio actual                      |
| `CD <nombre>`              | Cambia al subdirectorio con el nombre especificado                         |
| `MF <nombre> <tamaño>`     | Crea un nuevo archivo con el tamaño dado                                   |
| `LS`                       | Lista el contenido del directorio actual e imprime tamaño total             |
| `DI`                       | Cierra la sesión y vuelve al login                                          |

---

## 🧩 Arquitectura del Sistema

El sistema fue desarrollado con una **arquitectura de 4 capas**, separando responsabilidades de manera clara:

1. **BE (Business Entities):**  
   Define las clases del dominio, como `Usuario`, `Archivo` y `Directorio`.

2. **BLL (Business Logic Layer):**  
   Implementa la lógica de negocio y reglas del sistema operativo. Contiene las clases que utilizan los patrones `Singleton` y `Composite`.

3. **DAL (Data Access Layer):**  
   Encargada de la comunicación con la base de datos mediante stored procedures. Define operaciones como alta de usuario, recuperación de estructura, etc.

4. **CLI (Command Line Interface):**  
   Proporciona la interfaz con el usuario. Permite ingresar comandos, mostrar rutas actuales, y operar sobre el sistema de archivos de forma textual.

---

## 🗃️ Base de Datos

La base de datos del sistema fue diseñada utilizando **solo 3 tablas**:

1. `Usuarios`  
   - Almacena credenciales y datos de usuario.

2. `Componentes`  
   - Representa archivos y directorios con sus propiedades (nombre, tipo, tamaño, etc.).

3. `RelacionesComponentes`  
   - Define las relaciones padre-hijo entre componentes, modelando la jerarquía.

En el folder `/script/` se encuentran los archivos `.sql` necesarios para crear las tablas y ejecutar los **stored procedures** correspondientes en sqlServer para el funcionamiento completo del sistema operativo UaiOS.


