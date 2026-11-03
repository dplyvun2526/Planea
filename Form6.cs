using System;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Ui;

namespace ProyectoDeskstop
{
    public partial class Form6 : Form
    {
        private Button[] botonesSeccion;
        private Panel panelSeccion;
        private TextBox txtNombre;
        private Label lblEstado;

        public Form6()
        {
            InitializeComponent();
            ConstruirUI();
        }

        private void ConstruirUI()
        {
            Controls.Add(Lbl("TU ESPACIO", 9F, true, 30, 20, Azul));
            Controls.Add(Lbl("Ajustes", 22F, false, 30, 40, Texto));
            Controls.Add(Lbl("Configura tu perfil y las preferencias de Planea.", 10F, false, 30, 85, Gris));

            string[] secciones = { "Perfil", "Idioma", "Notificaciones", "Preferencias" };
            botonesSeccion = new Button[secciones.Length];
            for (int i = 0; i < secciones.Length; i++)
            {
                string nombre = secciones[i];
                Button b = Boton(nombre, 30, 130 + i * 45, 200, 36, false);
                b.TextAlign = ContentAlignment.MiddleLeft;
                b.Tag = nombre;
                b.Click += (s, e) => SeleccionarSeccion(nombre);
                botonesSeccion[i] = b;
                Controls.Add(b);
            }

            panelSeccion = new Panel
            {
                Location = new Point(250, 130),
                Size = new Size(710, 400),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(panelSeccion);

            SeleccionarSeccion("Perfil");
        }

        private void SeleccionarSeccion(string seccion)
        {
            foreach (Button b in botonesSeccion)
            {
                bool activa = (string)b.Tag == seccion;
                b.BackColor = activa ? Color.FromArgb(219, 234, 254) : Color.White;
            }

            panelSeccion.Controls.Clear();
            if (seccion == "Perfil")
            {
                ConstruirPerfil();
            }
            else
            {
                panelSeccion.Controls.Add(Lbl("Esta sección todavía está en desarrollo.", 10F, false, 20, 20, Gris));
            }
        }

        private void ConstruirPerfil()
        {
            panelSeccion.Controls.Add(Lbl("Perfil", 12F, true, 20, 18, Texto));
            panelSeccion.Controls.Add(Lbl("Información visible para el resto del equipo", 8.5F, false, 20, 42, Gris));

            panelSeccion.Controls.Add(Caja(Iniciales(Datos.Nombre), 20, 80, 56));
            panelSeccion.Controls.Add(Lbl(Datos.Nombre, 10F, true, 90, 84, Texto));
            panelSeccion.Controls.Add(Lbl(Datos.Email, 8.5F, false, 90, 108, Gris));
            panelSeccion.Controls.Add(Chip(Datos.Rol, 90, 130));

            panelSeccion.Controls.Add(Lbl("Nombre a mostrar:", 9F, false, 20, 185, Texto));
            txtNombre = new TextBox { Location = new Point(20, 208), Size = new Size(300, 23), Text = Datos.Nombre };
            panelSeccion.Controls.Add(txtNombre);

            Button guardar = Boton("Guardar", 335, 206, 110, 27, true);
            guardar.Click += (s, e) => GuardarNombre();
            panelSeccion.Controls.Add(guardar);

            lblEstado = Lbl("", 9F, false, 20, 245, Azul);
            panelSeccion.Controls.Add(lblEstado);

            panelSeccion.Controls.Add(Lbl("Vista del rol (para comprobar las acciones disponibles):", 9F, false, 20, 285, Texto));
            RadioButton rbUsuario = new RadioButton { Text = "Usuario", Location = new Point(20, 310), AutoSize = true, Checked = Datos.Rol == "Usuario" };
            RadioButton rbAdmin = new RadioButton { Text = "Administrador", Location = new Point(120, 310), AutoSize = true, Checked = Datos.Rol == "Administrador" };
            rbUsuario.CheckedChanged += (s, e) => { if (rbUsuario.Checked) Datos.Rol = "Usuario"; };
            rbAdmin.CheckedChanged += (s, e) => { if (rbAdmin.Checked) Datos.Rol = "Administrador"; };
            panelSeccion.Controls.Add(rbUsuario);
            panelSeccion.Controls.Add(rbAdmin);

            Button cerrar = Boton("Cerrar sesión", 20, 350, 150, 30, false);
            cerrar.ForeColor = Rojo;
            cerrar.Click += (s, e) => Application.Exit();
            panelSeccion.Controls.Add(cerrar);
        }

        private void GuardarNombre()
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre == "")
            {
                lblEstado.ForeColor = Rojo;
                lblEstado.Text = "El nombre no puede estar vacío.";
                return;
            }

            Datos.Nombre = nombre;
            lblEstado.ForeColor = Azul;
            lblEstado.Text = "Cambios guardados. El menú se actualiza al cambiar de página.";
        }
    }
}
