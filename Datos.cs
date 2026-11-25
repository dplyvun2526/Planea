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
        public string Fecha;
    }

    // Datos compartidos por todas las páginas (en memoria).
    public static class Datos
    {
        public static string Nombre = "Alex Serra";
        public static string Email = "alex.serra@planea.es";
        public static string Rol = "Usuario";
        // El idioma elegido se recuerda entre ejecuciones (así el inicio de sesión ya sale en tu idioma).
        private static readonly string ArchivoIdioma = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Planea", "idioma.txt");

        public static string Idioma = LeerIdioma();

        private static string LeerIdioma()
        {
            try
            {
                string guardado = System.IO.File.Exists(ArchivoIdioma) ? System.IO.File.ReadAllText(ArchivoIdioma).Trim() : "";
                if (guardado == "Català" || guardado == "English") return guardado;
            }
            catch (Exception) { }
            return "Castellano";
        }

        // Se avisa a la ventana principal para volver a traducir toda la aplicación.
        public static event Action IdiomaCambiado;

        public static void CambiarIdioma(string idioma)
        {
            Idioma = idioma;
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(ArchivoIdioma));
                System.IO.File.WriteAllText(ArchivoIdioma, idioma);
            }
            catch (Exception) { }
            if (IdiomaCambiado != null)
            {
                IdiomaCambiado();
            }
        }

        public static List<Proyecto> Proyectos = new List<Proyecto>();

        public static List<Tarea> Tareas = new List<Tarea>();
    }
}
