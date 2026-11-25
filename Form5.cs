using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form5 : Form
    {
        private int[] valoresEstados = new int[4];
        private readonly Color[] coloresEstados = { Color.FromArgb(15, 39, 71), Color.FromArgb(37, 99, 235), Color.FromArgb(220, 38, 38), Color.FromArgb(147, 197, 253) };

        public Form5()
        {
            InitializeComponent();
            Traducir();
            CargarDatos();
        }

        private void Traducir()
        {
            lblRendimiento.Text = T("RENDIMIENTO DEL EQUIPO");
            lblTituloResumen.Text = T("Resumen y estadísticas");
            lblSubResumen.Text = T("Analiza el avance de los proyectos y sus tareas.");
            lblStatTitulo1.Text = T("Total de tareas");
            lblStatTitulo2.Text = T("Tareas finalizadas");
            lblStatTitulo3.Text = T("En progreso");
            lblStatTitulo4.Text = T("Tasa de finalización");
            lblEstadoResTitulo.Text = T("Estado de las tareas");
            lblEstadoResSub.Text = T("Distribución por estado");
            lblEstadoNombre1.Text = T("Pendientes");
            lblEstadoNombre2.Text = T("En progreso");
            lblEstadoNombre3.Text = T("Bloqueadas");
            lblEstadoNombre4.Text = T("Finalizadas");
        }

        private void CargarDatos()
        {
            var cultura = Cultura();

            int total = Datos.Tareas.Count;
            int fin = Datos.Tareas.Count(t => t.Estado == "Finalizada");
            int enProg = Datos.Tareas.Count(t => t.Estado == "En progreso");
            int pend = Datos.Tareas.Count(t => t.Estado == "Pendiente");
            int bloq = Datos.Tareas.Count(t => t.Estado == "Bloqueada");
            int tasa = total == 0 ? 0 : (int)Math.Round(100.0 * fin / total);

            lblStatValor1.Text = total.ToString();
            lblStatValor2.Text = fin.ToString();
            lblStatValor3.Text = enProg.ToString();
            lblStatValor4.Text = tasa + "%";

            // Estado de las tareas
            valoresEstados = new[] { pend, enProg, bloq, fin };
            lblEstadoValor1.Text = pend.ToString();
            lblEstadoValor2.Text = enProg.ToString();
            lblEstadoValor3.Text = bloq.ToString();
            lblEstadoValor4.Text = fin.ToString();
        }

        private void panelDonaResumen_Paint(object sender, PaintEventArgs e)
        {
            Diseno.DibujarDona(e.Graphics, panelDonaResumen.ClientRectangle, valoresEstados, coloresEstados);
        }
    }
}
