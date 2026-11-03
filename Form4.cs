using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Ui;

namespace ProyectoDeskstop
{
    public partial class Form4 : Form
    {
        private readonly string[] pestanas = { "Todas", "Pendientes", "En progreso", "Bloqueadas", "Finalizadas" };
        private Button[] botonesPestana;
        private string pestanaActiva = "Todas";
        private TextBox txtBuscar;
        private ComboBox cmbProyecto;
        private Label lblResultados;
        private DataGridView dgv;
        private List<Tarea> mostradas = new List<Tarea>();

        public Form4()
        {
            InitializeComponent();
            ConstruirUI();
        }

        private void ConstruirUI()
        {
            Controls.Add(Lbl("ORGANIZACIÓN DEL TRABAJO", 9F, true, 30, 20, Azul));
            Controls.Add(Lbl("Tareas", 22F, false, 30, 40, Texto));
            Controls.Add(Lbl("Consulta, filtra y actualiza las tareas asignadas.", 10F, false, 30, 85, Gris));

            Button crear = Boton("+ Crear tarea", 760, 40, 170, 36, true);
            crear.Click += (s, e) => CrearTarea();
            Controls.Add(crear);

            botonesPestana = new Button[pestanas.Length];
            for (int i = 0; i < pestanas.Length; i++)
            {
                string nombre = pestanas[i];
                Button b = Boton(nombre, 30 + i * 125, 125, 118, 30, false);
                b.Click += (s, e) =>
                {
                    pestanaActiva = nombre;
                    RenderizarTareas();
                };
                botonesPestana[i] = b;
                Controls.Add(b);
            }

            txtBuscar = new TextBox { Location = new Point(30, 170), Size = new Size(260, 23) };
            cmbProyecto = new ComboBox { Location = new Point(305, 169), Size = new Size(200, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbProyecto.Items.Add("Todos los proyectos");
            foreach (Proyecto p in Datos.Proyectos)
            {
                cmbProyecto.Items.Add(p.Nombre);
            }
            cmbProyecto.SelectedIndex = 0;

            Button eliminar = Boton("Eliminar seleccionada", 760, 167, 200, 28, false);
            eliminar.Click += (s, e) => EliminarSeleccionada();

            lblResultados = Lbl("", 9F, false, 520, 173, Gris);

            dgv = new DataGridView
            {
                Location = new Point(30, 205),
                Size = new Size(930, 490),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            dgv.Columns.Add("tarea", "Tarea");
            dgv.Columns.Add("proyecto", "Proyecto");
            dgv.Columns.Add("responsable", "Responsable");
            dgv.Columns.Add("estado", "Estado");
            dgv.Columns.Add("prioridad", "Prioridad");
            dgv.Columns.Add("horas", "Horas");
            dgv.Columns.Add("fecha", "Fecha límite");

            Controls.Add(txtBuscar);
            Controls.Add(cmbProyecto);
            Controls.Add(eliminar);
            Controls.Add(lblResultados);
            Controls.Add(dgv);

            txtBuscar.TextChanged += (s, e) => RenderizarTareas();
            cmbProyecto.SelectedIndexChanged += (s, e) => RenderizarTareas();
            RenderizarTareas();
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

        private void RenderizarTareas()
        {
            dgv.Rows.Clear();
            mostradas.Clear();

            string filtro = txtBuscar.Text.Trim().ToLower();
            string proyectoSel = cmbProyecto.SelectedIndex <= 0 ? "" : cmbProyecto.SelectedItem.ToString();

            foreach (Tarea t in Datos.Tareas)
            {
                bool coincideProyecto = proyectoSel == "" || t.Proyecto == proyectoSel;
                bool coincideNombre = filtro == "" || t.Titulo.ToLower().Contains(filtro);
                if (CumplePestana(t, pestanaActiva) && coincideProyecto && coincideNombre)
                {
                    mostradas.Add(t);
                    dgv.Rows.Add(t.Titulo, t.Proyecto, t.Responsable, t.Estado, t.Prioridad, t.Horas, t.Fecha);
                }
            }

            foreach (Button b in botonesPestana)
            {
                string nombre = b.Text;
                int cuenta = Datos.Tareas.Count(t => CumplePestana(t, pestanas[Array.IndexOf(botonesPestana, b)]));
                b.Text = pestanas[Array.IndexOf(botonesPestana, b)] + " (" + cuenta + ")";
                bool activa = pestanas[Array.IndexOf(botonesPestana, b)] == pestanaActiva;
                b.BackColor = activa ? Azul : Color.White;
                b.ForeColor = activa ? Color.White : Texto;
            }

            lblResultados.Text = mostradas.Count + (mostradas.Count == 1 ? " resultado" : " resultados");
        }

        private void CrearTarea()
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
            RenderizarTareas();
        }

        private void EliminarSeleccionada()
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0 || dgv.CurrentRow.Index >= mostradas.Count)
            {
                MessageBox.Show("Selecciona una tarea de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tarea t = mostradas[dgv.CurrentRow.Index];
            DialogResult r = MessageBox.Show("¿Eliminar la tarea \"" + t.Titulo + "\"?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Datos.Tareas.Remove(t);
                RenderizarTareas();
            }
        }
    }
}
