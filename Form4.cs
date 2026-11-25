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
            CrearBotonEstado();

            Traducir();
            txtBuscarTarea.PlaceholderText = T("Buscar tarea por título...");
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
            if (Datos.Proyectos.Count == 0)
            {
                MessageBox.Show(T("Primero tiene que existir un proyecto."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NuevaTareaDialog dialogo = new NuevaTareaDialog())
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK) return;
                if (dialogo.Titulo == "")
                {
                    MessageBox.Show(T("El título es obligatorio."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Servicio.CrearTarea(dialogo.Titulo, dialogo.IdProyecto, dialogo.Prioridad, dialogo.Limite, dialogo.IdResponsable);
                    Servicio.Cargar();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            FiltrarTareas(sender, e);
        }

        private void CrearBotonEstado()
        {
            Button b = new Button
            {
                Text = T("Estado y horas"),
                Location = new Point(630, 167),
                Size = new Size(120, 28),
                BackColor = Color.White,
                ForeColor = Diseno.Texto,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            b.Click += CambiarEstado_Click;
            Controls.Add(b);
            b.BringToFront();
        }

        private void CambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvTareas.CurrentRow == null || dgvTareas.CurrentRow.Index < 0 || dgvTareas.CurrentRow.Index >= mostradas.Count)
            {
                MessageBox.Show(T("Selecciona una tarea de la lista."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tarea t = mostradas[dgvTareas.CurrentRow.Index];
            string[] estados = { "Pendiente", "En progreso", "Finalizada" }; // la BD solo tiene Pendiente, En progreso y Completada
            using (FormularioSimple f = new FormularioSimple(T("Estado y horas")))
            {
                ComboBox combo = f.Lista(t.Titulo, System.Linq.Enumerable.Select(estados, s => T(s)));
                combo.SelectedIndex = Math.Max(0, Array.IndexOf(estados, t.Estado));
                NumericUpDown horas = f.Numero(T("Horas totales trabajadas hasta ahora"), t.HorasTotales);
                f.Final(T("Guardar"));
                if (f.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    Servicio.CambiarEstado(t, estados[combo.SelectedIndex]);
                    if (horas.Value != t.HorasTotales) Servicio.GuardarHoras(t, horas.Value);
                    Servicio.Cargar();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
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
                try
                {
                    Servicio.EliminarTarea(t);
                    Servicio.Cargar();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FiltrarTareas(sender, e);
            }
        }
    }
}
