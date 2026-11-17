using System;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form7 : Form
    {
        private string rolSeleccionado = "Usuario";

        public Form7()
        {
            InitializeComponent();
            Traducir();
            SeleccionarRol("Usuario");
        }

        private void Traducir()
        {
            Text = T("Planea - Iniciar sesión");
            lblBienvenida.Text = T("Bienvenido a Planea");
            lblSubtituloLogin.Text = T("Inicia sesión para continuar");
            lblEntrarComo.Text = T("Entrar como");
            btnRolUsuario.Text = T("Usuario");
            btnRolAdministrador.Text = T("Administrador");
            lblEmail.Text = T("Correo electrónico");
            lblPassword.Text = T("Contraseña");
            btnIniciarSesion.Text = T("Iniciar sesión");
            lblSinCuenta.Text = T("¿No tienes cuenta?");
            btnCrearCuenta.Text = T("Crear cuenta");
        }

        private void btnRolUsuario_Click(object sender, EventArgs e)
        {
            SeleccionarRol("Usuario");
        }

        private void btnRolAdministrador_Click(object sender, EventArgs e)
        {
            SeleccionarRol("Administrador");
        }

        private void SeleccionarRol(string rol)
        {
            rolSeleccionado = rol;
            EstilarRol(btnRolUsuario, rol == "Usuario");
            EstilarRol(btnRolAdministrador, rol == "Administrador");
        }

        private static void EstilarRol(Button boton, bool activo)
        {
            boton.BackColor = activo ? Color.FromArgb(37, 99, 235) : Color.White;
            boton.ForeColor = activo ? Color.White : Color.FromArgb(17, 24, 39);
            boton.FlatAppearance.BorderSize = activo ? 0 : 1;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Sin validación de momento: la comprobación se conectará a la API y a la base de datos.
            Datos.Rol = rolSeleccionado;
            DialogResult = DialogResult.OK;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show(T("El registro de cuentas estará disponible cuando se conecte la base de datos."),
                T("Próximamente"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
