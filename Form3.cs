using System;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Ui;

namespace ProyectoDeskstop
{
    public partial class Form3 : Form
    {
        private Label lblCantidad;
        private TextBox txtBuscar;
        private ComboBox cmbEstado;
        private FlowLayoutPanel panelCards;

        public Form3()
        {
            InitializeComponent();
            ConstruirUI();
        }

        private void ConstruirUI()
        {
            Controls.Add(Lbl("ESPACIO DE TRABAJO", 9F, true, 30, 20, Azul));
            Controls.Add(Lbl("Proyectos", 22F, false, 30, 40, Texto));
            Controls.Add(Lbl("Consulta y realiza el seguimiento de todos los proyectos.", 10F, false, 30, 85, Gris));

            Button crear = Boton("+ Crear proyecto", 760, 40, 170, 36, true);
            crear.Click += (s, e) => CrearProyecto();
            Controls.Add(crear);

            txtBuscar = new TextBox { Location = new Point(30, 135), Size = new Size(250, 23) };
            cmbEstado = new ComboBox { Location = new Point(295, 134), Size = new Size(160, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEstado.Items.AddRange(new object[] { "Todos", "En progreso", "En revisión", "Planificado" });
            cmbEstado.SelectedIndex = 0;
            lblCantidad = Lbl("", 9F, false, 800, 138, Gris);
            panelCards = new FlowLayoutPanel
            {
                Location = new Point(30, 175),
                Size = new Size(930, 540),
                AutoScroll = true,
                BackColor = Fondo
            };

            Controls.Add(txtBuscar);
            Controls.Add(cmbEstado);
            Controls.Add(lblCantidad);
            Controls.Add(panelCards);

            txtBuscar.TextChanged += (s, e) => RenderizarProyectos();
            cmbEstado.SelectedIndexChanged += (s, e) => RenderizarProyectos();
            RenderizarProyectos();
        }

        private void RenderizarProyectos()
        {
            panelCards.Controls.Clear();

            string filtro = txtBuscar.Text.Trim().ToLower();
            string estadoSel = cmbEstado.SelectedItem == null ? "Todos" : cmbEstado.SelectedItem.ToString();
            int mostrados = 0;

            foreach (Proyecto p in Datos.Proyectos)
            {
                bool coincideEstado = estadoSel == "Todos" || p.Estado == estadoSel;
                bool coincideNombre = filtro == "" || p.Nombre.ToLower().Contains(filtro);
                if (coincideEstado && coincideNombre)
                {
                    panelCards.Controls.Add(CrearTarjeta(p));
                    mostrados++;
                }
            }

            lblCantidad.Text = mostrados + (mostrados == 1 ? " proyecto" : " proyectos");
        }

        private Panel CrearTarjeta(Proyecto p)
        {
            Panel c = Tarjeta(0, 0, 430, 170);
            c.Margin = new Padding(0, 0, 20, 20);
            c.Controls.Add(Caja(p.Inicial, 15, 15, 40));
            c.Controls.Add(Chip(p.Estado, 300, 18));
            c.Controls.Add(Lbl(p.Nombre, 11F, true, 15, 68, Texto));
            c.Controls.Add(Lbl(p.Descripcion, 8.5F, false, 15, 92, Gris));
            c.Controls.Add(Lbl("Responsable: " + p.Responsable, 9F, false, 15, 115, Texto));
            c.Controls.Add(Lbl("Tareas: " + p.Completadas + "/" + p.Total + "   ·   Entrega: " + p.Entrega, 8.5F, false, 15, 137, Gris));
            ProgressBar barra = new ProgressBar { Maximum = 100, Value = p.Progreso, Location = new Point(15, 157), Size = new Size(400, 6) };
            c.Controls.Add(barra);
            return c;
        }

        private void CrearProyecto()
        {
            string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre del proyecto:", "Crear proyecto", "").Trim();
            if (nombre == "")
            {
                return;
            }

            Datos.Proyectos.Add(new Proyecto
            {
                Nombre = nombre,
                Descripcion = "Proyecto nuevo.",
                Responsable = Datos.Nombre,
                Inicial = nombre.Substring(0, 1).ToUpper(),
                Estado = "Planificado",
                Entrega = "—",
                Completadas = 0,
                Total = 0,
                HorasReales = 0,
                HorasEstimadas = 0
            });
            RenderizarProyectos();
        }
    }
}
