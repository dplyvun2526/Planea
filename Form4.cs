using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form4 : Form
    {
        private string pestanaActiva = "Todas";
        private List<Tarea> mostradas = new List<Tarea>();
        private Button[] botonesPestana;
        private readonly string[] nombresPestana = { "Todas", "Pendientes", "En progreso", "Bloqueadas", "Finalizadas" };

        public Form4()
        {
            InitializeComponent();

            botonesPestana = new[] { btnTodas, btnPendientes, btnEnProgreso, btnBloqueadas, btnFinalizadas };

            Traducir();
            FiltrarTareas(this, EventArgs.Empty);
        }

        private void Traducir()
        {
            lblOrganizacion.Text = T("ORGANIZACIÓN DEL TRABAJO");
            lblTituloTareas.Text = T("Tareas");
            lblSubTareas.Text = T("Consulta, filtra y actualiza las tareas asignadas.");
            btnCrearTarea.Text = T("+ Crear tarea");
            btnEliminarTarea.Text = T("Eliminar seleccionada");

            colTarea.HeaderText = T("Tarea");
            colProyecto.HeaderText = T("Proyecto");
            colResponsable.HeaderText = T("Responsable");
            colEstado.HeaderText = T("Estado");
            colPrioridad.HeaderText = T("Prioridad");
            colHoras.HeaderText = T("Horas");
            colFecha.HeaderText = T("Fecha límite");

            int seleccion = cmbProyectoTarea.SelectedIndex < 0 ? 0 : cmbProyectoTarea.SelectedIndex;
            cmbProyectoTarea.Items.Clear();
            cmbProyectoTarea.Items.Add(T("Todos los proyectos"));
            foreach (Proyecto p in Datos.Proyectos)
            {
                cmbProyectoTarea.Items.Add(p.Nombre);
            }
            cmbProyectoTarea.SelectedIndex = seleccion;
        }

        private static bool CumplePestana(Tarea t, string pestana)
        {
            switch (pestana)
            {
                case "Pendientes": return t.Estado == "Pendiente";
                case "En progreso": return t.Estado == "En progreso";
                case "Bloqueadas": return t.Estado == "Bloqueada";
                case "Finalizadas": return t.Estado == "Finalizada";
                default: return true;
            }
        }

        // Botones de pestaña: el nombre (en castellano) está en su propiedad Tag.
        private void Pestana_Click(object sender, EventArgs e)
        {
            pestanaActiva = (string)((Button)sender).Tag;
            FiltrarTareas(sender, e);
        }

        private void FiltrarTareas(object sender, EventArgs e)
        {
            if (dgvTareas == null || botonesPestana == null) return;

            dgvTareas.Rows.Clear();
            mostradas.Clear();

            string filtro = txtBuscarTarea.Text.Trim().ToLower();
            string proyectoSel = cmbProyectoTarea.SelectedIndex <= 0 ? "" : cmbProyectoTarea.SelectedItem.ToString();

            foreach (Tarea t in Datos.Tareas)
            {
                bool coincideProyecto = proyectoSel == "" || t.Proyecto == proyectoSel;
                bool coincideNombre = filtro == "" || t.Titulo.ToLower().Contains(filtro);
                if (CumplePestana(t, pestanaActiva) && coincideProyecto && coincideNombre)
                {
                    mostradas.Add(t);
                    dgvTareas.Rows.Add(
                        t.Titulo,
                        t.Proyecto,
                        t.Responsable,
                        T(t.Estado),
                        T(t.Prioridad),
                        t.Horas,
                        t.Fecha == "Hoy" ? T("Hoy") : t.Fecha);
                }
            }

            for (int i = 0; i < botonesPestana.Length; i++)
            {
                Button b = botonesPestana[i];
                string nombre = nombresPestana[i];
                int cuenta = Datos.Tareas.Count(t => CumplePestana(t, nombre));
                bool activa = nombre == pestanaActiva;
                b.Text = T(nombre) + " (" + cuenta + ")";
                b.BackColor = activa ? Diseno.Azul : Color.White;
                b.ForeColor = activa ? Color.White : Diseno.Texto;
            }

            lblResultadosTarea.Text = mostradas.Count == 1 ? T("{0} resultado", mostradas.Count) : T("{0} resultados", mostradas.Count);
        }

        private void btnCrearTarea_Click(object sender, EventArgs e)
        {
            string titulo = Microsoft.VisualBasic.Interaction.InputBox(T("Título de la tarea:"), T("Crear tarea"), "").Trim();
            if (titulo == "")
            {
                return;
            }

            Datos.Tareas.Add(new Tarea
            {
                Titulo = titulo,
                Proyecto = "Sin proyecto",
                Responsable = Datos.Nombre,
                Estado = "Pendiente",
                Prioridad = "Media",
                Horas = "0 h",
                Fecha = "—"
            });
            FiltrarTareas(sender, e);
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            if (dgvTareas.CurrentRow == null || dgvTareas.CurrentRow.Index < 0 || dgvTareas.CurrentRow.Index >= mostradas.Count)
            {
                MessageBox.Show(T("Selecciona una tarea de la lista."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tarea t = mostradas[dgvTareas.CurrentRow.Index];
            DialogResult r = MessageBox.Show(T("¿Eliminar la tarea \"{0}\"?", t.Titulo), T("Confirmar"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Datos.Tareas.Remove(t);
                FiltrarTareas(sender, e);
            }
        }
    }
}
