using System;
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
            CargarProyectos();
            FiltrarProyectos(this, EventArgs.Empty);
        }

        private void Traducir()
        {
            lblProyEtiqueta.Text = T("ESPACIO DE TRABAJO");
            lblProyTitulo.Text = T("Proyectos");
            lblProySub.Text = T("Consulta y realiza el seguimiento de todos los proyectos.");

            int seleccion = cmbEstadoProyecto.SelectedIndex < 0 ? 0 : cmbEstadoProyecto.SelectedIndex;
            cmbEstadoProyecto.Items.Clear();
            foreach (string clave in claves)
            {
                cmbEstadoProyecto.Items.Add(T(clave));
            }
            cmbEstadoProyecto.SelectedIndex = seleccion;
        }

        private void CargarProyectos()
        {
            for (int i = 0; i < tarjetas.Length && i < Datos.Proyectos.Count; i++)
            {
                Proyecto p = Datos.Proyectos[i];
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
        }

        // Muestra solo las tarjetas que cumplen el buscador y el filtro de estado.
        private void FiltrarProyectos(object sender, EventArgs e)
        {
            if (tarjetas == null) return;

            string filtro = txtBuscarProyecto.Text.Trim().ToLower();
            int indice = cmbEstadoProyecto.SelectedIndex;
            string estadoSel = indice >= 0 && indice < claves.Length ? claves[indice] : "Todos";
            int mostrados = 0;

            for (int i = 0; i < tarjetas.Length && i < Datos.Proyectos.Count; i++)
            {
                Proyecto p = Datos.Proyectos[i];
                bool coincideEstado = estadoSel == "Todos" || p.Estado == estadoSel;
                bool coincideNombre = filtro == "" || p.Nombre.ToLower().Contains(filtro);
                tarjetas[i].Visible = coincideEstado && coincideNombre;
                if (tarjetas[i].Visible) mostrados++;
            }

            lblCantidadProyectos.Text = mostrados == 1 ? T("{0} proyecto", mostrados) : T("{0} proyectos", mostrados);
        }
    }
}
