using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoDeskstop
{
    public partial class Form6 : Form
    {
        private bool cargando = true;

        public Form6()
        {
            InitializeComponent();
            CargarPerfil();
            cargando = false;
        }

        private void CargarPerfil()
        {
            txtNombre.Text = Datos.Nombre;
            lblPerfilNombre.Text = Datos.Nombre;
            lblAvatarPerfil.Text = Ui.Iniciales(Datos.Nombre);
            lblPerfilRol.Text = Datos.Rol;
            rbUsuario.Checked = Datos.Rol == "Usuario";
            rbAdministrador.Checked = Datos.Rol == "Administrador";
        }

        // Los botones del menú de ajustes muestran el perfil o un aviso de sección en desarrollo.
        private void btnSeccion_Click(object sender, EventArgs e)
        {
            Button pulsado = (Button)sender;
            string seccion = (string)pulsado.Tag;

            foreach (Button b in new[] { btnSecPerfil, btnSecIdioma, btnSecNotificaciones, btnSecPreferencias })
            {
                bool activa = b == pulsado;
                b.BackColor = activa ? Color.FromArgb(219, 234, 254) : Color.White;
                b.ForeColor = activa ? Color.FromArgb(37, 99, 235) : Color.FromArgb(17, 24, 39);
                b.Font = new Font("Segoe UI", 9.5F, activa ? FontStyle.Bold : FontStyle.Regular);
            }

            panelPerfil.Visible = seccion == "Perfil";
            panelOtraSeccion.Visible = seccion != "Perfil";
            lblOtraSeccion.Text = "La sección \"" + seccion + "\" todavía está en desarrollo.";
        }

        private void btnGuardarNombre_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre == "")
            {
                lblGuardado.ForeColor = Ui.Rojo;
                lblGuardado.Text = "El nombre no puede estar vacío.";
                return;
            }

            Datos.Nombre = nombre;
            lblPerfilNombre.Text = nombre;
            lblAvatarPerfil.Text = Ui.Iniciales(nombre);
            lblGuardado.ForeColor = Ui.Azul;
            lblGuardado.Text = "Cambios guardados. El menú se actualiza al cambiar de página.";
        }

        private void rbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUsuario.Checked && !cargando)
            {
                Datos.Rol = "Usuario";
                lblPerfilRol.Text = Datos.Rol;
            }
        }

        private void rbAdministrador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdministrador.Checked && !cargando)
            {
                Datos.Rol = "Administrador";
                lblPerfilRol.Text = Datos.Rol;
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación. Volver al inicio de sesión se hará cuando exista la API.
            Application.Exit();
        }
    }
}
