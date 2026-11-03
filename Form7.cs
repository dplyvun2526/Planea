using System;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Ui;

namespace ProyectoDeskstop
{
    public partial class Form7 : Form
    {
        private string rolSeleccionado = "Usuario";
        private Button btnUsuario;
        private Button btnAdministrador;
        private TextBox txtEmail;
        private TextBox txtPass;

        public Form7()
        {
            InitializeComponent();
            ConstruirUI();
        }

        private void ConstruirUI()
        {
            Panel tarjeta = Tarjeta(40, 30, 340, 470);
            Controls.Add(tarjeta);

            Label logo = Caja("P", 144, 26, 52);
            logo.BackColor = Marino;
            logo.ForeColor = Color.White;
            logo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            tarjeta.Controls.Add(logo);

            Label titulo = Lbl("Bienvenido a Planea", 14F, true, 0, 92, Texto);
            titulo.AutoSize = false;
            titulo.Size = new Size(340, 28);
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            tarjeta.Controls.Add(titulo);

            Label subtitulo = Lbl("Inicia sesión para continuar", 9F, false, 0, 122, Gris);
            subtitulo.AutoSize = false;
            subtitulo.Size = new Size(340, 20);
            subtitulo.TextAlign = ContentAlignment.MiddleCenter;
            tarjeta.Controls.Add(subtitulo);

            tarjeta.Controls.Add(Lbl("Entrar como", 9F, true, 30, 165, Texto));

            btnUsuario = Boton("Usuario", 30, 188, 145, 34, false);
            btnUsuario.Click += (s, e) => SeleccionarRol("Usuario");
            tarjeta.Controls.Add(btnUsuario);

            btnAdministrador = Boton("Administrador", 165, 188, 145, 34, false);
            btnAdministrador.Click += (s, e) => SeleccionarRol("Administrador");
            tarjeta.Controls.Add(btnAdministrador);

            tarjeta.Controls.Add(Lbl("Correo electrónico", 9F, false, 30, 235, Texto));
            txtEmail = new TextBox { Location = new Point(30, 256), Size = new Size(280, 25), Font = new Font("Segoe UI", 10F) };
            tarjeta.Controls.Add(txtEmail);

            tarjeta.Controls.Add(Lbl("Contraseña", 9F, false, 30, 292, Texto));
            txtPass = new TextBox { Location = new Point(30, 313), Size = new Size(280, 25), Font = new Font("Segoe UI", 10F), PasswordChar = '•' };
            tarjeta.Controls.Add(txtPass);

            Button btnEntrar = Boton("Iniciar sesión", 30, 358, 280, 38, true);
            btnEntrar.Click += (s, e) => IniciarSesion();
            tarjeta.Controls.Add(btnEntrar);

            tarjeta.Controls.Add(Lbl("¿No tienes cuenta?", 9F, false, 62, 418, Gris));

            Button btnRegistro = new Button
            {
                Text = "Crear cuenta",
                Location = new Point(180, 412),
                Size = new Size(100, 26),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Azul,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.Click += (s, e) => MessageBox.Show(
                "El registro de cuentas estará disponible cuando se conecte la base de datos.",
                "Próximamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tarjeta.Controls.Add(btnRegistro);

            AcceptButton = btnEntrar;
            SeleccionarRol("Usuario");
        }

        private void SeleccionarRol(string rol)
        {
            rolSeleccionado = rol;
            EstilarRol(btnUsuario, rol == "Usuario");
            EstilarRol(btnAdministrador, rol == "Administrador");
        }

        private static void EstilarRol(Button boton, bool activo)
        {
            boton.BackColor = activo ? Azul : Color.White;
            boton.ForeColor = activo ? Color.White : Texto;
            boton.FlatAppearance.BorderSize = activo ? 0 : 1;
        }

        private void IniciarSesion()
        {
            // Sin validación de momento: la comprobación de usuario se conectará a la API y a la base de datos.
            Datos.Rol = rolSeleccionado;
            DialogResult = DialogResult.OK;
        }
    }
}
