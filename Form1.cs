using System;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form1 : Form
    {
        private Form paginaActual;
        private Button[] botonesMenu;
        private Button botonActivo;

        public Form1()
        {
            InitializeComponent();
            botonesMenu = new[] { btnInicio, btnProyectos, btnTareas, btnResumen, btnAjustes };
            Datos.IdiomaCambiado += OnIdiomaCambiado;
            Traducir();
            MostrarPagina(new Form2(), btnInicio);
        }

        private void Traducir()
        {
            btnInicio.Text = T("Inicio");
            btnProyectos.Text = T("Proyectos");
            btnTareas.Text = T("Tareas");
            btnResumen.Text = T("Resumen");
            btnAjustes.Text = T("Ajustes");
        }

        // Muestra una página dentro del área de contenido y actualiza la cabecera y el bloque de usuario.
        private void MostrarPagina(Form pagina, Button boton)
        {
            botonActivo = boton;

            foreach (Button b in botonesMenu)
            {
                b.BackColor = Color.FromArgb(15, 39, 71);
                b.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
            boton.BackColor = Color.FromArgb(30, 64, 110);
            boton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblTituloPagina.Text = boton.Text;
            ActualizarUsuario();

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

        private void ActualizarUsuario()
        {
            string iniciales = Diseno.Iniciales(Datos.Nombre);
            lblUsuario.Text = Datos.Nombre;
            lblRol.Text = T(Datos.Rol);
            lblAvatar.Text = iniciales;
            lblUsuarioMenu.Text = Datos.Nombre;
            lblRolMenu.Text = T(Datos.Rol);
            lblAvatarMenu.Text = iniciales;
        }

        // Al cambiar el idioma se vuelve a dibujar la cabecera y la página actual.
        private void OnIdiomaCambiado()
        {
            BeginInvoke(new Action(() =>
            {
                // Se recargan los datos para que las fechas salgan en el idioma nuevo.
                try { Servicio.Cargar(); } catch (ApiException) { }
                Traducir();
                MostrarPagina(CrearPagina(botonActivo), botonActivo);
            }));
        }

        private Form CrearPagina(Button boton)
        {
            if (boton == btnProyectos) return new Form3();
            if (boton == btnTareas) return new Form4();
            if (boton == btnResumen) return new Form5();
            if (boton == btnAjustes) return new Form6();
            return new Form2();
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

        // Al pulsar el nombre o el avatar del usuario (cabecera o menú lateral) se abre Ajustes.
        private void AbrirAjustes(object sender, EventArgs e)
        {
            MostrarPagina(new Form6(), btnAjustes);
        }
    }
}
