# ProyectoDeskstop - Planea

Aplicación de escritorio en C# con Windows Forms (.NET 8).

## Estructura
- `Form1`: ventana principal con el menú lateral. Muestra cada página dentro del área de contenido.
- `Form2` Inicio: resumen con estadísticas, proyectos recientes, estado de tareas y próximas tareas.
- `Form3` Proyectos: buscador, filtro por estado, tarjetas y creación de proyectos.
- `Form4` Tareas: pestañas por estado, filtro por proyecto, tabla, creación y eliminación de tareas.
- `Form5` Resumen: estadísticas, estado de tareas y horas por proyecto.
- `Form6` Ajustes: perfil (cambiar nombre y rol). Las demás secciones están en desarrollo.
- `Ui.cs`: colores y controles comunes.
- `Datos.cs`: datos de ejemplo y estado compartido, en memoria (no se guardan al cerrar).

## Ejecutar
Al iniciar aparece el inicio de sesión (solo visual, sin base de datos todavía). Elige "Usuario" o "Administrador" y pulsa "Iniciar sesión".
También puedes ejecutar `dotnet run` en la carpeta del proyecto.
