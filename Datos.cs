using System;
using System.Collections.Generic;

namespace ProyectoDeskstop
{
    public class Proyecto
    {
        public int Id;
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
        public int Id;
        public int IdProyecto;
        public ApiTarea Original; // datos tal cual vienen de la API (para poder actualizarla)
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
        public static string Idioma = "Castellano";
        public static bool NotifTareas = true;
        public static bool NotifFechas = true;
        public static bool NotifProyectos = false;

        // Se avisa a la ventana principal para volver a traducir toda la aplicación.
        public static event Action IdiomaCambiado;

        public static void CambiarIdioma(string idioma)
        {
            Idioma = idioma;
            if (IdiomaCambiado != null)
            {
                IdiomaCambiado();
            }
        }

        public static double HorasEstimadasTotal = 0;
        public static double HorasRegistradasTotal = 0;

        public static List<Proyecto> Proyectos = new List<Proyecto>();

        public static List<Tarea> Tareas = new List<Tarea>();
    }
}
