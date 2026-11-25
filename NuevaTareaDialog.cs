using System;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    // Pide los datos de una tarea nueva.
    public class NuevaTareaDialog : FormularioSimple
    {
        private readonly TextBox txtTitulo;
        private readonly ComboBox cmbProyecto;
        private readonly ComboBox cmbPrioridad;
        private readonly ComboBox cmbResponsable;
        private readonly DateTimePicker dtpLimite;

        public string Titulo { get { return txtTitulo.Text.Trim(); } }
        public int IdProyecto { get { return Datos.Proyectos[cmbProyecto.SelectedIndex].Id; } }
        public string Prioridad { get { return new[] { "Alta", "Media", "Baja" }[cmbPrioridad.SelectedIndex]; } }
        public int IdResponsable { get { return cmbResponsable.SelectedIndex < 0 ? 0 : Servicio.Usuarios[cmbResponsable.SelectedIndex].IdUser; } }
        public DateTime Limite { get { return dtpLimite.Value.Date; } }

        public NuevaTareaDialog() : base(T("Crear tarea"))
        {
            txtTitulo = Texto(T("Título de la tarea:"));
            cmbProyecto = Lista(T("Proyecto"), Datos.Proyectos.Select(p => p.Nombre));
            cmbPrioridad = Lista(T("Prioridad"), new[] { T("Alta"), T("Media"), T("Baja") });
            cmbPrioridad.SelectedIndex = 1;
            cmbResponsable = Lista(T("Responsable"), Servicio.Usuarios.Select(u => u.NameUser + " " + u.LastnameUser));
            int yo = Servicio.Usuarios.FindIndex(u => u.IdUser == Servicio.IdUsuario);
            if (yo >= 0) cmbResponsable.SelectedIndex = yo;
            dtpLimite = Fecha(T("Fecha límite"), DateTime.Today.AddDays(7));
            Final(T("Crear tarea"));
        }
    }
}
