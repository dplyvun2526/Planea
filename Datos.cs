using System;
using System.Collections.Generic;

namespace ProyectoDeskstop
{
    public class Proyecto
    {
        public string Nombre;
        public string Descripcion;
        public string Responsable;
        public string Inicial;
        public string Estado;
        public string Entrega;
        public int Completadas;
        public int Total;
        public int HorasReales;
        public int HorasEstimadas;

        public int Progreso
        {
            get { return Total == 0 ? 0 : (int)Math.Round(100.0 * Completadas / Total); }
        }
    }

    public class Tarea
    {
        public string Titulo;
        public string Proyecto;
        public string Responsable;
        public string Estado;
        public string Prioridad;
        public string Horas;
        public string Fecha;
    }

    // Datos compartidos por todas las páginas (en memoria).
    public static class Datos
    {
        public static string Nombre = "Alex Serra";
        public static string Email = "alex.serra@planea.es";
        public static string Rol = "Usuario";

        public const double HorasEstimadasTotal = 624;
        public const double HorasRegistradasTotal = 486.5;

        public static List<Proyecto> Proyectos = new List<Proyecto>
        {
            new Proyecto { Nombre = "Rediseño web corporativa", Descripcion = "Nueva experiencia digital y migración de contenidos.", Responsable = "Lucía Martín", Inicial = "R", Estado = "En progreso", Entrega = "28 jun", Completadas = 18, Total = 24, HorasReales = 156, HorasEstimadas = 200 },
            new Proyecto { Nombre = "App de clientes", Descripcion = "Aplicación móvil para el portal de clientes.", Responsable = "Diego Ruiz", Inicial = "A", Estado = "En progreso", Entrega = "15 jul", Completadas = 14, Total = 32, HorasReales = 122, HorasEstimadas = 164 },
            new Proyecto { Nombre = "Campaña verano", Descripcion = "Planificación y activos para la campaña estacional.", Responsable = "Marta Soler", Inicial = "C", Estado = "En revisión", Entrega = "21 jun", Completadas = 15, Total = 16, HorasReales = 114, HorasEstimadas = 120 },
            new Proyecto { Nombre = "Portal interno RRHH", Descripcion = "Centralización de procesos y documentación interna.", Responsable = "Hugo Vidal", Inicial = "P", Estado = "Planificado", Entrega = "30 ago", Completadas = 5, Total = 20, HorasReales = 64, HorasEstimadas = 150 }
        };

        public static List<Tarea> Tareas = new List<Tarea>
        {
            new Tarea { Titulo = "Validar prototipo con dirección", Proyecto = "Rediseño web corporativa", Responsable = "Lucía Martín", Estado = "En progreso", Prioridad = "Alta", Horas = "4 h / 6 h", Fecha = "Hoy" },
            new Tarea { Titulo = "Preparar componentes de navegación", Proyecto = "App de clientes", Responsable = "Diego Ruiz", Estado = "Pendiente", Prioridad = "Media", Horas = "0 h / 8 h", Fecha = "20 jun" },
            new Tarea { Titulo = "Revisar copys de campaña", Proyecto = "Campaña verano", Responsable = "Marta Soler", Estado = "Bloqueada", Prioridad = "Alta", Horas = "—", Fecha = "21 jun" },
            new Tarea { Titulo = "Documentar flujo de solicitudes", Proyecto = "Portal interno RRHH", Responsable = "Hugo Vidal", Estado = "En progreso", Prioridad = "Media", Horas = "—", Fecha = "—" },
            new Tarea { Titulo = "Optimizar imágenes del catálogo", Proyecto = "Rediseño web corporativa", Responsable = "Nora Gil", Estado = "Finalizada", Prioridad = "Baja", Horas = "—", Fecha = "—" },
            new Tarea { Titulo = "Configurar eventos de analítica", Proyecto = "App de clientes", Responsable = "Diego Ruiz", Estado = "Pendiente", Prioridad = "Alta", Horas = "—", Fecha = "—" }
        };
    }
}
