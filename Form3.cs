using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form3 : Form
    {
        private readonly string[] claves = { "Todos", "En progreso", "En revisión", "Planificado" };
        private Panel[] tarjetas;
        private Label[] letras;
        private Label[] estados;
        private Label[] nombres;
        private Label[] descripciones;
        private Label[] responsables;
        private Label[] detalles;
        private ProgressBar[] progresos;

        // Proyectos que cumplen el buscador y el filtro (las tarjetas muestran los 4 primeros).
        private List<Proyecto> visibles = new List<Proyecto>();

        public Form3()
        {
            InitializeComponent();

            tarjetas = new[] { panelProyecto1, panelProyecto2, panelProyecto3, panelProyecto4 };
            letras = new[] { lblInicial1, lblInicial2, lblInicial3, lblInicial4 };
            estados = new[] { lblEstado1, lblEstado2, lblEstado3, lblEstado4 };
            nombres = new[] { lblNombre1, lblNombre2, lblNombre3, lblNombre4 };
            descripciones = new[] { lblDesc1, lblDesc2, lblDesc3, lblDesc4 };
            responsables = new[] { lblResp1, lblResp2, lblResp3, lblResp4 };
            detalles = new[] { lblDetalle1, lblDetalle2, lblDetalle3, lblDetalle4 };
            progresos = new[] { pbProgreso1, pbProgreso2, pbProgreso3, pbProgreso4 };

            Traducir();
            txtBuscarProyecto.PlaceholderText = T("Buscar proyecto por nombre...");
            CrearBotonCrear();
            ActivarClicEnTarjetas();
            FiltrarProyectos(this, EventArgs.Empty);
        }

        private void Traducir()
        {
            lblProyEtiqueta.Text = T("ESPACIO DE TRABAJO");
            lblProyTitulo.Text = T("Proyectos");
            lblProySub.Text = T("Consulta y realiza el seguimiento de todos los proyectos. Haz clic en uno para gestionar su equipo.");

            int seleccion = cmbEstadoProyecto.SelectedIndex < 0 ? 0 : cmbEstadoProyecto.SelectedIndex;
            cmbEstadoProyecto.Items.Clear();
            foreach (string clave in claves)
            {
                cmbEstadoProyecto.Items.Add(T(clave));
            }
            cmbEstadoProyecto.SelectedIndex = seleccion;
        }

        private void CrearBotonCrear()
        {
            Button crear = new Button
            {
                Text = T("+ Crear proyecto"),
                Location = new Point(470, 130),
                Size = new Size(170, 32),
                BackColor = Diseno.Azul,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            crear.FlatAppearance.BorderSize = 0;
            crear.Click += CrearProyecto_Click;
            crear.Visible = Datos.Rol == "Administrador"; // solo los administradores crean proyectos
            Controls.Add(crear);
        }

        // Al hacer clic en una tarjeta (o en cualquiera de sus textos) se abre la gestión del equipo.
        private void ActivarClicEnTarjetas()
        {
            for (int i = 0; i < tarjetas.Length; i++)
            {
                int indice = i;
                EventHandler abrir = (s, e) => AbrirEquipo(indice);
                tarjetas[i].Cursor = Cursors.Hand;
                tarjetas[i].Click += abrir;
                foreach (Control c in tarjetas[i].Controls)
                {
                    c.Click += abrir;
                }
            }
        }

        private void AbrirEquipo(int indice)
        {
            if (indice >= visibles.Count) return;
            if (Datos.Rol != "Administrador") return; // solo los administradores gestionan equipos
            using (EquipoDialog d = new EquipoDialog(visibles[indice]))
            {
                d.ShowDialog(this);
            }
            RecargarDesdeApi();
        }

        private void CrearProyecto_Click(object sender, EventArgs e)
        {
            using (FormularioSimple f = new FormularioSimple(T("Crear proyecto")))
            {
                TextBox nombre = f.Texto(T("Nombre del proyecto"));
                TextBox descripcion = f.Texto(T("Descripción"));
                DateTimePicker inicio = f.Fecha(T("Fecha de inicio"), DateTime.Today);
                DateTimePicker entrega = f.Fecha(T("Fecha de entrega"), DateTime.Today.AddMonths(1));
                f.Final(T("Crear proyecto"));
                if (f.ShowDialog(this) != DialogResult.OK) return;

                if (nombre.Text.Trim() == "")
                {
                    MessageBox.Show(T("El nombre es obligatorio."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (entrega.Value.Date < inicio.Value.Date)
                {
                    MessageBox.Show(T("La entrega no puede ser anterior al inicio."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    Servicio.CrearProyecto(nombre.Text.Trim(), descripcion.Text.Trim(), inicio.Value.Date, entrega.Value.Date);
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            RecargarDesdeApi();
        }

        private void RecargarDesdeApi()
        {
            try
            {
                Servicio.Cargar();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FiltrarProyectos(this, EventArgs.Empty);
        }

        // Aplica el buscador y el filtro de estado y pinta los 4 primeros resultados.
        private void FiltrarProyectos(object sender, EventArgs e)
        {
            if (tarjetas == null) return;

            string filtro = txtBuscarProyecto.Text.Trim().ToLower();
            int indice = cmbEstadoProyecto.SelectedIndex;
            string estadoSel = indice >= 0 && indice < claves.Length ? claves[indice] : "Todos";

            visibles = new List<Proyecto>();
            foreach (Proyecto p in Datos.Proyectos)
            {
                bool coincideEstado = estadoSel == "Todos" || p.Estado == estadoSel;
                bool coincideNombre = filtro == "" || p.Nombre.ToLower().Contains(filtro);
                if (coincideEstado && coincideNombre) visibles.Add(p);
            }

            for (int i = 0; i < tarjetas.Length; i++)
            {
                tarjetas[i].Visible = i < visibles.Count;
                if (i >= visibles.Count) continue;

                Proyecto p = visibles[i];
                letras[i].Text = p.Inicial;
                estados[i].Text = T(p.Estado);
                estados[i].BackColor = Diseno.ColorEstado(p.Estado);
                nombres[i].Text = p.Nombre;
                descripciones[i].Text = p.Descripcion;
                responsables[i].Text = T("Responsable: {0}", p.Responsable);
                detalles[i].Text = T("Tareas: {0}/{1}   ·   Entrega: {2}", p.Completadas, p.Total, p.Entrega);
                progresos[i].Maximum = 100;
                progresos[i].Value = p.Progreso;
            }

            lblCantidadProyectos.Text = visibles.Count == 1 ? T("{0} proyecto", visibles.Count) : T("{0} proyectos", visibles.Count);
            if (visibles.Count > tarjetas.Length)
            {
                lblCantidadProyectos.Text += " (" + T("mostrando {0}", tarjetas.Length) + ")";
            }
        }
    }
}
