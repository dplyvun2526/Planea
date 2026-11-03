using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoDeskstop
{
    public partial class Form1 : Form
    {
        private Form paginaActual;
        private Button[] botonesMenu;

        public Form1()
        {
            InitializeComponent();
            botonesMenu = new[] { btnInicio, btnProyectos, btnTareas, btnResumen, btnAjustes };
            MostrarPagina(new Form2(), btnInicio);
        }

        // Muestra una página (Form) dentro del área de contenido y actualiza la cabecera.
        private void MostrarPagina(Form pagina, Button botonActivo)
        {
            foreach (Button b in botonesMenu)
            {
                b.BackColor = Ui.Marino;
                b.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
            botonActivo.BackColor = Ui.MarinoActivo;
            botonActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblTituloPagina.Text = botonActivo.Text.Trim();
            lblUsuario.Text = Datos.Nombre;
            lblRol.Text = Datos.Rol;
            picAvatar.Text = Ui.Iniciales(Datos.Nombre);

            if (paginaActual != null)
            {
                panelContenido.Controls.Remove(paginaActual);
                paginaActual.Dispose();
            }

            pagina.TopLevel = false;
            pagina.FormBorderStyle = FormBorderStyle.None;
            pagina.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(pagina);
            paginaActual = pagina;
            pagina.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarPagina(new Form2(), btnInicio);
        }

        private void btnProyectos_Click(object sender, EventArgs e)
        {
            MostrarPagina(new Form3(), btnProyectos);
        }

        private void btnTareas_Click(object sender, EventArgs e)
        {
            MostrarPagina(new Form4(), btnTareas);
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            MostrarPagina(new Form5(), btnResumen);
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            MostrarPagina(new Form6(), btnAjustes);
        }
    }
}
