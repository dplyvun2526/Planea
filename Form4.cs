using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoDeskstop
{
    public partial class Form4 : Form
    {
        private string pestanaActiva = "Todas";
        private List<Tarea> mostradas = new List<Tarea>();
        private Button[] botonesPestana;

        public Form4()
        {
            InitializeComponent();

            botonesPestana = new[] { btnTodas, btnPendientes, btnEnProgreso, btnBloqueadas, btnFinalizadas };

            cmbProyectoTarea.Items.Add("Todos los proyectos");
            foreach (Proyecto p in Datos.Proyectos)
            {
                cmbProyectoTarea.Items.Add(p.Nombre);
            }
            cmbProyectoTarea.SelectedIndex = 0;

            FiltrarTareas(this, EventArgs.Empty);
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

        // Botones de pestaña: el nombre de cada pestaña está en su propiedad Tag.
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
                    dgvTareas.Rows.Add(t.Titulo, t.Proyecto, t.Responsable, t.Estado, t.Prioridad, t.Horas, t.Fecha);
                }
            }

            foreach (Button b in botonesPestana)
            {
                string nombre = (string)b.Tag;
                int cuenta = Datos.Tareas.Count(t => CumplePestana(t, nombre));
                bool activa = nombre == pestanaActiva;
                b.Text = nombre + " (" + cuenta + ")";
                b.BackColor = activa ? Ui.Azul : Color.White;
                b.ForeColor = activa ? Color.White : Ui.Texto;
            }

            lblResultadosTarea.Text = mostradas.Count + (mostradas.Count == 1 ? " resultado" : " resultados");
        }

        private void btnCrearTarea_Click(object sender, EventArgs e)
        {
            string titulo = Microsoft.VisualBasic.Interaction.InputBox("Título de la tarea:", "Crear tarea", "").Trim();
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
                MessageBox.Show("Selecciona una tarea de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tarea t = mostradas[dgvTareas.CurrentRow.Index];
            DialogResult r = MessageBox.Show("¿Eliminar la tarea \"" + t.Titulo + "\"?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Datos.Tareas.Remove(t);
                FiltrarTareas(sender, e);
            }
        }
    }
}
