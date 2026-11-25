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
            lblSubResumen.Text = T("Analiza el avance de los proyectos y el tiempo dedicado.");
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
            lblHorasProyTitulo.Text = T("Horas por proyecto");
            lblHorasProySub.Text = T("Reales frente a estimadas");
            lblHorasEstTitulo.Text = T("Horas estimadas");
            lblHorasRegTitulo.Text = T("Horas registradas");
            lblUsoTitulo.Text = T("Uso de horas");
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

            // Horas por proyecto (cuatro proyectos)
            Label[] nombres = { lblHorasNombre1, lblHorasNombre2, lblHorasNombre3, lblHorasNombre4 };
            Label[] valores = { lblHorasValor1, lblHorasValor2, lblHorasValor3, lblHorasValor4 };
            ProgressBar[] barras = { pbHoras1, pbHoras2, pbHoras3, pbHoras4 };

            for (int i = 0; i < 4; i++)
            {
                bool hay = i < Datos.Proyectos.Count;
                nombres[i].Visible = valores[i].Visible = barras[i].Visible = hay;
                if (!hay) continue;
                Proyecto p = Datos.Proyectos[i];
                int estimadas = Math.Max(1, p.HorasEstimadas);
                nombres[i].Text = p.Nombre;
                valores[i].Text = T("{0} h / {1} h", p.HorasReales, p.HorasEstimadas);
                barras[i].Maximum = estimadas;
                barras[i].Value = Math.Min(p.HorasReales, estimadas);
            }

            // Resumen de horas
            int uso = Datos.HorasEstimadasTotal <= 0 ? 0 : (int)Math.Min(100, Math.Round(100 * Datos.HorasRegistradasTotal / Datos.HorasEstimadasTotal));
            lblHorasEstValor.Text = Datos.HorasEstimadasTotal.ToString("0", cultura) + " h";
            lblHorasRegValor.Text = Datos.HorasRegistradasTotal.ToString("N1", cultura) + " h";
            lblUsoValor.Text = uso + "%";
            pbUso.Maximum = 100;
            pbUso.Value = uso;
        }

        private void panelDonaResumen_Paint(object sender, PaintEventArgs e)
        {
            Diseno.DibujarDona(e.Graphics, panelDonaResumen.ClientRectangle, valoresEstados, coloresEstados);
        }
    }
}
