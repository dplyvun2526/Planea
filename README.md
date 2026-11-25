# Planea — aplicación de escritorio

Aplicación de gestión de proyectos y tareas en C# con Windows Forms (.NET 8). Trabaja contra la API [Planea_Api](https://github.com/seda-123/Planea_Api), que guarda los datos en la base de datos SQL Server del equipo.

## Ponerla en marcha
Los pasos completos (descargar, arrancar la API y la app, y qué probar) están en [PROBAR.md](PROBAR.md).

## Qué hace
- Inicio de sesión y registro de cuentas.
- Roles: solo los administradores crean proyectos y gestionan sus equipos.
- Cada usuario ve únicamente los proyectos en los que está, con todas sus tareas.
- Tareas: crear (con responsable), cambiar estado y eliminar.
- Inicio y Resumen con estadísticas.
- Idiomas: castellano, catalán e inglés (se recuerda el elegido).

## Estructura
- `Form1`: ventana principal con el menú lateral.
- `Form2` Inicio · `Form3` Proyectos · `Form4` Tareas · `Form5` Resumen · `Form6` Ajustes · `Form7` inicio de sesión.
- `ApiService.cs`: llamadas HTTP a la API y conversión de sus datos a los de la interfaz.
- `Datos.cs`: datos cargados en memoria y preferencias.
- `FormularioSimple.cs`, `NuevaTareaDialog.cs`, `EquipoDialog.cs`: diálogos.
- `Idiomas.cs`: traducciones. `Diseno.cs`: colores y dibujo.
- `datos-iniciales.sql`: cómo crear el primer administrador.

## Pendiente
- Dependencias entre tareas, costes y facturación.
- La pantalla de Proyectos muestra como máximo 4 tarjetas (usa el buscador y el filtro para ver el resto).
- Cambiar el nombre en Ajustes solo afecta a la sesión actual.
