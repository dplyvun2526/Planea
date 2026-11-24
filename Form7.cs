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
            // El rol sale de la base de datos: no se elige al entrar.
            lblEntrarComo.Visible = false;
            btnRolUsuario.Visible = false;
            btnRolAdministrador.Visible = false;
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
            if (txtEmail.Text.Trim() == "" || txtPassword.Text == "")
            {
                MessageBox.Show(T("Introduce tu correo y tu contraseña."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (!Servicio.IniciarSesion(txtEmail.Text, txtPassword.Text))
                {
                    MessageBox.Show(T("Correo o contraseña incorrectos."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Servicio.Cargar();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            using (FormularioSimple f = new FormularioSimple(T("Crear cuenta")))
            {
                TextBox nombre = f.Texto(T("Nombre"));
                TextBox apellidos = f.Texto(T("Apellidos"));
                TextBox correo = f.Texto(T("Correo electrónico"));
                TextBox clave = f.Texto(T("Contraseña"), true);
                TextBox clave2 = f.Texto(T("Repite la contraseña"), true);
                f.Final(T("Crear cuenta"));
                if (f.ShowDialog(this) != DialogResult.OK) return;

                if (nombre.Text.Trim() == "" || apellidos.Text.Trim() == "" || !correo.Text.Contains("@") || clave.Text == "")
                {
                    MessageBox.Show(T("Rellena todos los campos con un correo válido."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (clave.Text != clave2.Text)
                {
                    MessageBox.Show(T("Las contraseñas no coinciden."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    Servicio.Registrar(nombre.Text.Trim(), apellidos.Text.Trim(), correo.Text.Trim(), clave.Text);
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtEmail.Text = correo.Text.Trim();
                MessageBox.Show(T("Cuenta creada. Ya puedes iniciar sesión."), "Planea", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
